namespace RCG.CoreApp.Services.Product
{
    using CsvHelper;
    using CsvHelper.Configuration;
    using LinqKit;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using RCG.CoreApp.AppResources;
    using RCG.CoreApp.DTO;
    using RCG.CoreApp.DTO.Mapper;
    using RCG.CoreApp.Interfaces.Product;
    using RCG.CoreApp.Interfaces.Repositories;
    using RCG.CoreApp.Interfaces.Shared;
    using RCG.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IApplConfigsRepository _applConfigsRepository;
        private readonly IDateTimeService _dateTimeService;

        public ProductService(
            IProductRepository productRepository,
            IDateTimeService dateTimeService,
            IApplConfigsRepository applConfigsRepository)
        {
            _productRepository = productRepository;
            _dateTimeService = dateTimeService;
            _applConfigsRepository = applConfigsRepository;
        }

        public async Task<GridResponseDto<AddProductDto>> GetPagedProductList(int pageNumber, int pageSize, string search = null)
        {
            search ??= string.Empty;
            var predicate = this.BuildFilter(search.ToLower());
            var gridResponseModel = new GridResponseDto<AddProductDto>();
            gridResponseModel.Rows = await _productRepository.GetQuery(out int totalCount, pageNumber, pageSize, predicate)
              .Select(a => new AddProductDto
              {
                  ProductId = a.Id,
                  Style = a.Sku,
                  AvailableLength = !string.IsNullOrEmpty(a.Length) ? a.Length : Resource.BlankEntryLbl,
                  AvrageWeight = !string.IsNullOrEmpty(a.Weight) ? a.Weight : Resource.BlankEntryLbl,
                  Price = a.Price,
                  UpdatedOn = a.LastModifiedOn.Value.ToString(Resource.UpdatedOnDateFromat)
              }).ToListAsync();

            gridResponseModel.TotalCount = totalCount;
            gridResponseModel.PageNumber = pageNumber;
            gridResponseModel.PageSize = pageSize;

            return gridResponseModel;
        }

        public async Task<ProductMain> AddProductMainAsync(ProductMainDto productMainDto)
        {
            var productMain = new ProductMain
            {
                CreatedBy = productMainDto.Username,
                CreatedOn = _dateTimeService.NowUtc,
                FileActualname = productMainDto.FileActualname,
                FileTempname = productMainDto.FileTempname,
                LastModifiedBy = productMainDto.Username,
                LastModifiedOn = _dateTimeService.NowUtc,
            };

            var productList = await _productRepository.AddProductMainAsync(productMain);
            return productList;
        }

        public async Task<ProductMainDto> ImportPriceListAsync(string filePath)
        {
            var roductMainDto = new ProductMainDto();
            List<AddProductDto> productList = null;
            await Task.Run(() =>
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.ToLower(),
                    TrimOptions = TrimOptions.Trim,
                };

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<PriceListMapper>();
                    productList = csv.GetRecords<AddProductDto>().ToList();
                }

                var saveFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Resource.PathUploads;
                if (!Directory.Exists(saveFilePath))
                {
                    Directory.CreateDirectory(saveFilePath);
                }

                var fileExt = Path.GetExtension(filePath);
                roductMainDto.FileTempname = Guid.NewGuid().ToString() + fileExt;
                roductMainDto.FileActualname = Path.GetFileName(filePath);

                File.Copy(filePath, saveFilePath + roductMainDto.FileTempname);

            });

            var emtySkuList = productList.Where(a => string.IsNullOrEmpty(a.Style));
            productList = productList.
                Where(a => !string.IsNullOrEmpty(a.Style)).
                GroupBy(p => p.Style).Select(g => g.FirstOrDefault()).ToList();
            productList.AddRange(emtySkuList);
            roductMainDto.ProductList = productList;
            return roductMainDto;
        }

        public async Task<Products> SetProductModelAsync(AddProductDto item)
        {
            Products product = null;
            await Task.Run(() =>
            {
                product = new Products
                {
                    Sku = item.Style?.Trim(),
                    Length = item.AvailableLength?.Trim(),
                    Weight = item.AvrageWeight,
                    Price = item.Price,
                    CreatedBy = item.User,
                    CreatedOn = _dateTimeService.NowUtc,
                    LastModifiedBy = item.User,
                    LastModifiedOn = _dateTimeService.NowUtc,
                };

                if (item.ProductId > 0)
                {
                    product.Id = item.ProductId;
                }

                if (item.ProductMainId > 0)
                {
                    product.ProductMainId = item.ProductMainId;
                }
            });

            return product;
        }

        public async Task<bool> AddProductBulkAsync(List<Products> productList, List<Products> productListForDelete = null)
        {
            var success = await this._productRepository.AddProductBulkAsync(productList, productListForDelete);
            await this.GenerateProductJsonFileAsync();
            return success;
        }

        public async Task<bool> AddProductAsync(AddProductDto priceListDto)
        {
            var product = await this.SetProductModelAsync(priceListDto);
            var success = await this._productRepository.AddOrUpdateProductAsync(product);
            await this.GenerateProductJsonFileAsync();
            return success;
        }

        public bool IsProductExist(string styleName)
        {
            var isProductExist = this._productRepository.IsProductExist(styleName);
            return isProductExist;
        }

        public bool IsNumber(string value)
        {
            value = Regex.Replace(value, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
            var isNumber = decimal.TryParse(value, out decimal result);
            return isNumber;
        }

        public AddProductDto ValidateProductSave(AddProductDto addProductDto, bool isImport)
        {
            bool isValid = true;
            var messageList = new List<string>();
            if (string.IsNullOrWhiteSpace(addProductDto.Style))
            {
                messageList.Add(string.Format(Resource.PleaseEnterLbl, Resource.SKULbl));
                isValid = false;
            }
            if (!string.IsNullOrWhiteSpace(addProductDto.Style) && addProductDto.Style.Length > 25)
            {
                messageList.Add("SKU cannot be longer than 25 characters");
                isValid = false;
            }
            if (!isImport && !string.IsNullOrEmpty(addProductDto.Style) &&
               addProductDto.ProductId == 0 &&
               this.IsProductExist(addProductDto.Style))
            {
                messageList.Add("SKU already exist");
                isValid = false;
            }
            ////if (!string.IsNullOrEmpty(addProductDto.AvailableLength)
            ////   && !this.IsNumber(addProductDto.AvailableLength))
            ////{
            ////    messageList.Add("Please enter a valid Length");
            ////    isValid = false;
            ////}
            if (!string.IsNullOrEmpty(addProductDto.AvrageWeight)
               && !this.IsNumber(addProductDto.AvrageWeight))
            {
                messageList.Add("Please enter a valid Weight");
                isValid = false;
            }
            if (string.IsNullOrEmpty(addProductDto.Price)
              || !this.IsNumber(addProductDto.Price))
            {
                messageList.Add("Please enter a valid Price");
                isValid = false;
            }

            addProductDto.IsValid = isValid;
            addProductDto.ValidationMessage = isImport ? string.Join("|", messageList) : messageList.FirstOrDefault();
            return addProductDto;
        }

        public async Task<List<Products>> GetProductsBySkuListAync(List<string> skuList)
        {
            var productList = await this._productRepository.GetProductsBySkuListAync(skuList);
            return productList;
        }

        public async Task<bool> CreateCSVAsync(List<AddProductDto> failedProductList, string filePath)
        {
            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<ExportProductsMapper>();
            await csv.WriteRecordsAsync(failedProductList);
            return true;
        }

        public bool ValidateCSV(string fileName)
        {
            List<string> headerList = null;
            bool hasRecord = false;
            bool isValid = true;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
                TrimOptions = TrimOptions.Trim,
            };
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                if (csv.Parser.Count > 0)
                {
                    csv.ReadHeader();
                    headerList = csv.HeaderRecord.ToList();
                    hasRecord = csv.GetRecords<dynamic>().Any();
                }
            }

            if (!hasRecord || !headerList.Exists(x => x.ToLower() == "sku") || !headerList.Exists(x => x.ToLower() == "price"))
            {
                isValid = false;
            }

            return isValid;

        }

        public async Task<bool> DeleteProductByIdAsync(long productId)
        {
            bool result = await this._productRepository.DeleteProductByIdAsync(productId);
            await this.GenerateProductJsonFileAsync();
            return result;
        }

        public async Task<bool> GenerateProductJsonFileAsync()
        {
            var allProducts = await this._productRepository.GetAllProductsAsync();
            var indexFilePath = await this._applConfigsRepository.GetApplConfigValueAsync(Enums.EnumMaster.ApplConfig.IndesignIndexFileSavePath);

            if (allProducts != null && allProducts.Any() && indexFilePath != null && !string.IsNullOrEmpty(indexFilePath.Value))
            {
                var productRootJsonDto = new ProductRootJsonDto();
                productRootJsonDto.IndexFilePath = indexFilePath.Value;
                productRootJsonDto.Products = allProducts.Select(a => new ProductJsonDto
                {
                    Product = a.Sku,
                    Length = a.Length,
                    Price = a.Price,
                    Weight = a.Weight
                }).ToList();

                var filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Resource.PathIndesignDataFile;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                filePath += Resource.IndesignDataFileName;
                var json = JsonConvert.SerializeObject(productRootJsonDto);
                File.WriteAllText(filePath, json);
                return true;
            }

            return false;
        }

        private decimal ConvertToDecimal(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = Regex.Replace(value, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                decimal.TryParse(value, out decimal result);
                return result;
            }
            else
            {
                return 0;
            }
        }

        private Expression<Func<Products, bool>> BuildFilter(string search)
        {
            var predicate = PredicateBuilder.New<Products>();
            if (!string.IsNullOrEmpty(search))
            {
                predicate = predicate.Or(x => x.Sku.ToLower().Contains(search));
            }

            predicate.And(a => !string.IsNullOrEmpty(a.Sku));
            return predicate;
        }
    }
}

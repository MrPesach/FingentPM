namespace RCG.CoreApp.Services.Product
{
    using CsvHelper;
    using LinqKit;
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
        private readonly IDateTimeService _dateTimeService;

        public ProductService(
            IProductRepository productRepository,
            IDateTimeService dateTimeService)
        {
            _productRepository = productRepository;
            _dateTimeService = dateTimeService;
        }

        public async Task<List<AddProductDto>> GetPagedProductList(int pageNumber, int pageSize, string search = null)
        {
            search = search ?? string.Empty;
            var predicate = this.BuildFilter(search.ToLower());
            var productList = await _productRepository.GetPagedListAsync(pageNumber, pageSize, predicate);
            var productListDto = productList.Select(a => new AddProductDto
            {
                ProductId = a.Id,
                Style = a.Sku,
                AvailableLength = a.Length.ToString(),
                AvrageWeight = a.Weight.ToString(),
                Price = a.Price.ToString(),
                UpdatedOn = a.LastModifiedOn.Value.ToString("MM/dd/yyyy")

            }).ToList();

            return productListDto;
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
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<PriceListMapper>();
                    productList = csv.GetRecords<AddProductDto>().ToList();
                }

                string appPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + @"\Resources\UploadedFiles\";
                if (!Directory.Exists(appPath))
                {
                    Directory.CreateDirectory(appPath);
                }

                var fileExt = Path.GetExtension(filePath);
                roductMainDto.FileTempname = Guid.NewGuid().ToString() + fileExt;
                roductMainDto.FileActualname = Path.GetFileName(filePath);

                File.Copy(filePath, appPath + roductMainDto.FileTempname);

            });

            productList = productList.GroupBy(p => p.Style).Select(g => g.FirstOrDefault()).ToList();
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
                    Sku = item.Style.Trim(),
                    Length = this.ConvertToDecimal(item.AvailableLength),
                    Weight = this.ConvertToDecimal(item.AvrageWeight),
                    Price = this.ConvertToDecimal(item.Price),
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
            return success;
        }

        public async Task<bool> AddProductAsync(AddProductDto priceListDto)
        {
            var product = await this.SetProductModelAsync(priceListDto);
            var success = await this._productRepository.AddProductAsync(product);
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
            if (string.IsNullOrEmpty(addProductDto.Style))
            {
                messageList.Add("Please enter Style Name");
                isValid = false;
            }
            if (!isImport && !string.IsNullOrEmpty(addProductDto.Style) &&
               addProductDto.ProductId == 0 &&
               this.IsProductExist(addProductDto.Style))
            {
                messageList.Add("Style Name already exist");
                isValid = false;
            }
            if (!string.IsNullOrEmpty(addProductDto.AvailableLength)
               && !this.IsNumber(addProductDto.AvailableLength))
            {
                messageList.Add("Please enter a valid Available Length");
                isValid = false;
            }
            if (!string.IsNullOrEmpty(addProductDto.AvrageWeight)
               && !this.IsNumber(addProductDto.AvrageWeight))
            {
                messageList.Add("Please enter a valid Average Weight");
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

        public async Task<bool> CreateCSVAsync(List<AddProductDto> failedProductList)
        {
            var filePath = @"D:\Mehaboob\Project Documents\RCG\Failed CSV\" + Guid.NewGuid().ToString() + ".csv";
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ExportProductsMapper>();
                await csv.WriteRecordsAsync(failedProductList);
                return true;
            }
        }

        public bool ValidateCSV(string fileName)
        {
            List<string> headerList = null;
            bool hasRecord = false;
            bool isValid = true;
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                headerList = csv.HeaderRecord.ToList();
                hasRecord = csv.GetRecords<dynamic>().Any();
            }

            if (!hasRecord || !headerList.Exists(x => x == "STYLE#") || !headerList.Exists(x => x == "TRIPLE KEY UNIT PRICE IN USD"))
            {
                isValid = false;
            }

            return isValid;

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

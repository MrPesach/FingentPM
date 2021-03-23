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
    using static System.Net.Mime.MediaTypeNames;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IDateTimeService _dateTimeService;

        public ProductService(IProductRepository productRepository, IDateTimeService dateTimeService)
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
            List<PriceListDto> priceList = null;
            await Task.Run(() =>
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<PriceListMapper>();
                    priceList = csv.GetRecords<PriceListDto>().ToList();
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

            roductMainDto.PriceList = priceList;
            return roductMainDto;
        }

        public async Task<Products> SetProductModelAsync(PriceListDto item)
        {
            Products product = null;
            await Task.Run(() =>
            {
                if (this.ValidatePriceList(item))
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
                        ProductMainId = item.ProductMainId,
                    };

                    if (item.ProductId > 0)
                    {
                        product.Id = item.ProductId;
                    }
                }
            });

            return product;
        }

        public async Task<bool> AddProductBulkAsync(List<Products> productList)
        {
            var success = await this._productRepository.AddProductBulkAsync(productList);
            return success;
        }

        public async Task<bool> AddProductAsync(PriceListDto priceListDto)
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

        private bool ValidatePriceList(PriceListDto priceListDto)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(priceListDto.Style) ||
                (!string.IsNullOrEmpty(priceListDto.AvailableLength) && !this.IsNumber(priceListDto.AvailableLength)) ||
                string.IsNullOrEmpty(priceListDto.Price) || !this.IsNumber(priceListDto.Price) ||
                string.IsNullOrEmpty(priceListDto.AvrageWeight) || !this.IsNumber(priceListDto.AvrageWeight))
            {
                isValid = false;
            }
            return isValid;
        }

        public bool IsNumber(string value)
        {
            value = Regex.Replace(value, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
            var isNumber = decimal.TryParse(value, out decimal result);
            return isNumber;
        }

        private decimal ConvertToDecimal(string value)
        {
            value = Regex.Replace(value, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
            decimal.TryParse(value, out decimal result);
            return result;
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

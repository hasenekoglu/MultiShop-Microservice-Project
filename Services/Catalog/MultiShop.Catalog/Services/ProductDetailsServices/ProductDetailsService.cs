using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailsServices
{
    public class ProductDetailsService :IProductDetailsService
    {
        private readonly IMongoCollection<ProductDetails> _productCollection;
        private readonly IMapper _mapper;

        public ProductDetailsService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<ProductDetails>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productCollection.Find(i => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var values = _mapper.Map<ProductDetails>(createProductDetailDto);
            await _productCollection.InsertOneAsync(values); 
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = _mapper.Map<ProductDetails>(updateProductDetailDto);
            await _productCollection.FindOneAndReplaceAsync(i => i.ProductId == updateProductDetailDto.ProductId, values);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productCollection.DeleteOneAsync(i => i.ProductDetailId == id);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values = await _productCollection.Find<ProductDetails>(i => i.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);
        }
    }
}

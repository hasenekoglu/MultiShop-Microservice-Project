using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailsServices;


namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailsService _ProductDetailService;

        public ProductDetailsController(IProductDetailsService ProductDetailService)
        {
            _ProductDetailService = ProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _ProductDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var values =await _ProductDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _ProductDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("ProductDetail was successfully added");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _ProductDetailService.DeleteProductDetailAsync(id);
            return Ok("ProductDetail was successfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _ProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("ProductDetail was successfully updated");
        }
    }
}

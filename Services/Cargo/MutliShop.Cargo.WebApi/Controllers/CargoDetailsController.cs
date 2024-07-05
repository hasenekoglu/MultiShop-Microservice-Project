using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetilDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MutliShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoCompanyId = createCargoDetailDto.CargoCompanyId,
                SenderCustomer = createCargoDetailDto.SenderCustomer,
                Barcode = createCargoDetailDto.Barcode,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                
            };

            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Cargo Detail successfully created");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Cargo Detail successfully deleted");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetail(int id)
        {
            var values = _cargoDetailService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                Barcode = updateCargoDetailDto.Barcode,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                CargoDetailId = updateCargoDetailDto.CargoDetailId
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Cargo Detail successfully updated");
        }
    }
}

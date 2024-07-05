using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetail;

        public CargoDetailManager(ICargoDetailDal cargoDetail)
        {
            _cargoDetail = cargoDetail;
        }

        public void TInsert(CargoDetail entity)
        {
            _cargoDetail.Insert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
            _cargoDetail.Update(entity);
        }

        public void TDelete(int id)
        {
            _cargoDetail.Delete(id);
        }

        public CargoDetail TGetById(int id)
        {
            return _cargoDetail.GetById(id);
        }

        public List<CargoDetail> TGetAll()
        {
            return _cargoDetail.GetAll();
        }
    }
}

using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);

            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            try
            {
                _brandDal.Delete(brand);
                return new SuccessResult();
            }
            catch
            {
                return new ErrorResult(Messages.UnknownError);
            }
            
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetBrandById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));
        }

        public IDataResult<List<BrandDetailDto>> GetBrandImages()
        {
            return new SuccessDataResult<List<BrandDetailDto>>(_brandDal.GetBrandImages());
        }

        public IResult Update(Brand brand)
        {
            if (brand.Id == null || brand.Id < 1)
            {
                return new ErrorResult(Messages.UnknownError);
            }
            _brandDal.Update(brand);

            return new SuccessResult();
        }
    }
}

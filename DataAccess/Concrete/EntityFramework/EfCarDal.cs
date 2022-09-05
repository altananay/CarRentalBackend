﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = co.Name, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, ImagePath = ci.ImagePath  };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             where c.BrandId == brandId
                             select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = co.Name, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, ImagePath = ci.ImagePath };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             where c.ColorId == colorId
                             select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = co.Name, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, ImagePath = ci.ImagePath };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsById(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             where c.Id == id
                             select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = co.Name, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, ImagePath = ci.ImagePath };
                return result.ToList();
            }
        }
    }
}
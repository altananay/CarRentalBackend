using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
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
    public class EfBrandDal : EfEntityRepositoryBase<Brand, RentACarContext>, IBrandDal
    {
        public List<BrandDetailDto> GetBrandImages()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from b in context.Brands
                             join bi in context.BrandImages
                             on b.Id equals bi.BrandId
                             select new BrandDetailDto { Id = b.Id, Name = b.Name, ImagePath = bi.ImagePath };
                return result.ToList();
            }
        }
    }
}

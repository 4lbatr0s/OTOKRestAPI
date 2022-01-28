using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using System;

namespace DataAccess.Concrete
{
    public class EfBrandDal: EfEntityRepositoryBase<Brand, ComponentContext> ,IBrandDal
    {

    }

}

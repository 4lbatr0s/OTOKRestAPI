using Core.Utilities.Result;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand brand);
        IDataResult<List<Brand>> GetAll();
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
        IDataResult<List<Brand>> GetAllByBrandId(int id);
        IDataResult<Brand> GetById(int id);

        IDataResult<List<Brand>> GetByBrandName(string brandName);
    }
}

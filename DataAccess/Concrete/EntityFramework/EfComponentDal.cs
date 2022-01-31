using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete
{
    public class EfComponentDal : EfEntityRepositoryBase<Component, ComponentContext>, IComponentDal
    {

    }

}

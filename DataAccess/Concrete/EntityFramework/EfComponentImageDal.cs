using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete
{
    public class EfComponentImageDal: EfEntityRepositoryBase<ComponentImage, ComponentContext>, IComponentImageDal
    {

    }

}

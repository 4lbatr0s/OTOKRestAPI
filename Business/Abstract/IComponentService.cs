using Core.Utilities.Result;
using Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IComponentService
    {
        IDataResult<List<Component>> GetAll();
        IResult Add(Component component);
        IResult Delete(Component component);
        IResult Update(Component component);
        IDataResult<List<Component>> GetAllByModel(string modelName);
        IDataResult<Component> GetById(int id);
    }
}

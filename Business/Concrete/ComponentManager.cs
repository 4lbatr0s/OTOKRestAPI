using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ComponentManager : IComponentService
    {
        private readonly IComponentDal _componentDal;
         public ComponentManager(IComponentDal componentDal)
        {
            _componentDal = componentDal;
         }

        [SecuredOperations("component.delete, admin")]
        public IResult Delete(Component component)
        {
            _componentDal.Delete(component);
            return new SuccessResult(Message.ComponentDeleted);
        }

         public IDataResult<List<Component>> GetAll()
        {
            var result = _componentDal.GetAll();
            return new SuccessDataResult<List<Component>>(result);
        }

         public IDataResult<List<Component>> GetAllByModel(string modelName)
        {
            var result = _componentDal.GetAll(c => c.ModelName == modelName);
            return new SuccessDataResult<List<Component>>(result);
        }

         public IDataResult<Component> GetById(int id)
        {
            var result = _componentDal.Get(c => c.Id == id);
            return new SuccessDataResult<Component>(result);
        }

        [SecuredOperations("component.update, admin")]
        public IResult Update(Component component)
        {
            _componentDal.Update(component);
            return new SuccessResult(Message.ComponentUpdated);
        }

         public IDataResult<List<Component>> GetByBrand(int brandId)
        {
            var result = _componentDal.GetAll(b => b.BrandId == brandId);
            return new SuccessDataResult<List<Component>>(result);
        }

        [SecuredOperations("component.add, admin")]
        public IResult Add(Component component)
        {
            _componentDal.Add(component);
            return new SuccessResult(Message.ComponentAdded);
        }


    }
}

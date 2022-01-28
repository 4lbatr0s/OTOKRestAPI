using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ComponentImageManager : IComponentImageService
    {
        private readonly IComponentImageDal _componentImageDal;
        private readonly IFileHelper _fileHelper;

        public ComponentImageManager(IComponentImageDal componentImageDal, IFormFile formFile, IFileHelper fileHelper)
        {
            _componentImageDal = componentImageDal;
            _fileHelper = fileHelper;
        }

        public IResult UploadImage(IFormFile image, ComponentImage componentImage)
        {
            componentImage.ImagePath = Paths.ImagesPath + _fileHelper.Upload(image, Paths.ImagesPath); //_fileHelper.Upload() returns fileName therefore ImagePath equals (Paths.ImagesPath + fileName)
            componentImage.Date = DateTime.Now;
            _componentImageDal.Add(componentImage); //puts componentImage into database.
            return new SuccessResult(Message.ComponentImageAdded);

        }

        public IResult Delete(ComponentImage carImage)
        {
            
            _fileHelper.Delete(Paths.ImagesPath + carImage.ImagePath);
            _componentImageDal.Delete(carImage);
            return new SuccessResult(Message.CarImageDeleted);
        }

        public IDataResult<List<ComponentImage>> GetAll()
        {
            var result = _componentImageDal.GetAll();
            return new SuccessDataResult<List<ComponentImage>>(result);
        }

   
        public IDataResult<ComponentImage> GetById(int componentImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageDoesExists(componentImage));
            if (result != null)
            {
                return new ErrorDataResult<ComponentImage>(GetDefaultImage(componentImage).Data);
            }
            var resultValue = _componentImageDal.Get(c => c.Id == componentImage);
            return new SuccessDataResult<ComponentImage>(resultValue);
        }

        public IResult Update(IFormFile file, ComponentImage carImage)
        {
            _fileHelper.Update(file, Paths.ImagesPath + carImage.ImagePath, Paths.ImagesPath);
            _componentImageDal.Update(carImage);
            return new SuccessResult(Message.ComponentImageUpdated);
        }

         

        private IDataResult<ComponentImage> GetDefaultImage(int componentId)
        {
            ComponentImage componentImages = new ComponentImage { ComponentId = componentId, Date = DateTime.Now, ImagePath = "Default.jpg" };
            return new SuccessDataResult<ComponentImage>();
        }

        private IResult CheckIfCarImageDoesExists(int componentImageId)
        {
            var result = _componentImageDal.Get(c => c.Id==componentImageId);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}

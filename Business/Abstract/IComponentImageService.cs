using Core.Utilities.Result;
using Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IComponentImageService
    {
        IResult UploadImage(IFormFile file, ComponentImage carImage);
        IDataResult<List<ComponentImage>> GetAll();
        IDataResult<ComponentImage> GetById(int carImageId);

        IResult Delete(ComponentImage carImage);
        IResult Update(IFormFile file, ComponentImage carImage);
    }
}

using Core.Abstract;
using System;

namespace Entities
{
    public class ComponentImage:IEntity
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}

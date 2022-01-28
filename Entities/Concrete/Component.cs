using Core.Abstract;
using System;

namespace Entities
{
    public class Component:IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public DateTime Date { get; set; }
        
        public string ModelName { get; set; }
        public int ModelYear { get; set; }

        public decimal Price { get; set; }

    }
}

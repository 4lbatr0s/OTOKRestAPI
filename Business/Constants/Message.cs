using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Message
    {
        public static string BrandAdded { get; internal set; }
        public static string BrandDeleted { get; internal set; }
        public static string BrandUpdated { get; internal set; }
        public static string ComponentDeleted { get; internal set; }
        public static string ComponentUpdated { get; internal set; }
        public static string ComponentAdded { get; internal set; }
        public static string ComponentImageAdded { get; internal set; }
        public static string CarImageDeleted { get; internal set; }
        public static string ComponentImageUpdated { get; internal set; }
    }
}

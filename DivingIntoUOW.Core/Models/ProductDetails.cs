using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivingIntoUOW.Core.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public string ProductPrice { get; set; }

        public string ProductStock { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoadMore.Models
{
   public class ItemPrice
    {
        public string Image
        {
            get;
            set;
        }
        public string Price
        {
            get;
            set;
        }

        public ItemPrice(string image,string price)
        {
            this.Image = image;
            this.Price = price;
        }
    }
}

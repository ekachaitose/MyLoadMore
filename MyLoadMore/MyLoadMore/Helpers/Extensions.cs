using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoadMore.Helpers
{
   public static class Extensions
    {
        public static void AddRage<T>(this ObservableCollection<T> oc, IEnumerable<T> collection)
        {
            //check ว่าเป็นค่าว่างหรือไม่ ถ้าไม่จะทำการวนลูปแอดทีละตัว
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            foreach (var item in collection)
            {
                oc.Add(item);
            }
        }
    }
}

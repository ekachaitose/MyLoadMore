using MyLoadMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyLoadMore
{
   public class SuccessPage : TabbedPage
    {
        public SuccessPage()
        {
            Title = "Xamarin Workshop";
            Children.Add(new FeedJSONPage());
            Children[0].Title = "REST";

            Children.Add(new PTTWebServicePage());
            Children[1].Title = "SOAP";

            if (Device.OS == TargetPlatform.iOS)
            {
                Children[0].Icon = "tab_icon_rest.png";
                Children[1].Icon = "tab_icon_soap.png";
            }
        }
    }
}

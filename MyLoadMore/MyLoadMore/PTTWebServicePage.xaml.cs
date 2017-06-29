using MyLoadMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyLoadMore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PTTWebServicePage : ContentPage
    {
        public PTTWebServicePage()
        {
            InitializeComponent();
            FeedData();
        }

        private void FeedData()
        {
            var dummyData = new List<ItemPrice>();
            dummyData.Add(new ItemPrice("oilname_91.png", "22.33"));
            dummyData.Add(new ItemPrice("oilname_91.png", "28.43"));
            dummyData.Add(new ItemPrice("oilname_91.png", "38.53"));
            listView.ItemsSource = dummyData;

        }
    }
}
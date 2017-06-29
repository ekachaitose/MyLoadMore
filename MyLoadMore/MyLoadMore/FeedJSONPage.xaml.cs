using MyLoadMore.Helpers;
using MyLoadMore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyLoadMore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedJSONPage : ContentPage,IRefreshControl
    {

        public bool isLoading;
        public ObservableCollection<Youtube> mDataArray = new ObservableCollection<Youtube>(); //เป็น list อีกรูปแบบหนึ่ง 
        public static int pageIndex = 1;
        public static int pageSize = 5;

        public FeedJSONPage()
        {
            InitializeComponent();
            BindingContext = new FeedJSONPageViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetupLoadMore();
            FeedData(true);
            listView.BindingContext = new RefreshViewModel(this);
        }

            /*
       * Load more page
       */
        void SetupLoadMore()
        {
            listView.ItemsSource = mDataArray;
            listView.ItemAppearing += (sender, e) =>
            {
                // isLoading or no data
                if (isLoading || mDataArray.Count == 0)
                    return;

                //hit bottom!
                if (e.Item == mDataArray[mDataArray.Count - 1])
                {
                    // Simulate delay
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        FeedData(false); // load more
                        return false;
                    });

                }
            };
        }
        public void FeedData(Boolean isRefresh)
        {
            //create background thread
            Task.Run(async () =>
            {
                isLoading = true;

                if (isRefresh == true)
                {
                    pageIndex = 1;
                    mDataArray.Clear();
                    ListViewFooter.IsVisible = true;
                }
                //Background theread
                UserBean userbean = new UserBean();
                userbean.Username = "admin";
                userbean.Password = "password";
                var result = await JsonService.CallPost(userbean, pageIndex++, pageSize);
                string title = result.youtubes[0].title;
                Debug.WriteLine("title:" + title);

                Device.BeginInvokeOnMainThread(() =>
                {
                    if(result.youtubes.Count < pageSize)
                    {
                        ListViewFooter.IsVisible = false;
                    }
                    // Main Thread (UI) โปรแกรมจะทำต่อเมื่อว่างงาน
                    //listView.ItemsSource = result.youtubes; การเรียกใช้แบบ hard code

                    listView.EndRefresh();
                    mDataArray.AddRage(result.youtubes);
                    isLoading = false;


                });
            });
        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            listView.SelectedItem = null;
            var item = e.Item as Youtube;
            DependencyService.Get<IYoutubePlayer>().PlayYoutube(item.id);
        }

        private void Handle_Tapped_LIKE(object sender, EventArgs e)
        {
            var label = sender as Label;
            var item = label.BindingContext as Youtube;
            DisplayAlert("CLICK", "LIKE:" + item.title, "CLOSE");
        }

        private void Handle_Tapped_COMMENT(object sender, EventArgs e)
        {
            var label = sender as Label;
            var item = label.BindingContext as Youtube;
            DisplayAlert("CLICK", "COMMENT:" + item.title, "CLOSE");
        }

     
    }

    class FeedJSONPageViewModel : INotifyPropertyChanged
    {

        public FeedJSONPageViewModel()
        {
            IncreaseCountCommand = new Command(IncreaseCount);
        }

        int count;

        string countDisplay = "You clicked 0 times.";
        public string CountDisplay
        {
            get { return countDisplay; }
            set { countDisplay = value; OnPropertyChanged(); }
        }

        public ICommand IncreaseCountCommand { get; }

        void IncreaseCount() =>
            CountDisplay = $"You clicked {++count} times";


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyLoadMore.Helpers
{
   public class RefreshViewModel : INotifyPropertyChanged
    {
        // Interface used in Page class to implement call-back method to reload data
        IRefreshControl mCallback;

        public RefreshViewModel(IRefreshControl callback)
        {
            mCallback = callback;
        }

        // Property to indicate whether loading is busy or finished already, to protect double re-load
        private bool isBusy;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy == value)
                    return;
                isBusy = value;
                PropertyChanged(this, new PropertyChangedEventArgs("isBusy"));
            }
        }

        private Command loadTweetsCommand;
        public Command LoadTweetsCommand
        {
            get
            {
                return loadTweetsCommand ?? (loadTweetsCommand = new Command(ExecuteLoadTweetsCommand, () => {
                    return !IsBusy;
                }));
            }
        }
        // Call-back to reload data by checking if loading too - before triggerring reloading
        private async void ExecuteLoadTweetsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            //LoadTweetsCommand.ChangeCanExecute();

            // Perform reload data via the delegate
            mCallback.FeedData(true);
            await Task.Delay(1000);

            IsBusy = false;
            LoadTweetsCommand.ChangeCanExecute();
        }
    }
    public interface IRefreshControl
    {
        void FeedData(Boolean isRefresh);
    }
}

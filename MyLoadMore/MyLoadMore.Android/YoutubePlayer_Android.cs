using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyLoadMore.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(YoutubePlayer_Android))]
namespace MyLoadMore.Droid
{
    public class YoutubePlayer_Android : IYoutubePlayer
    {
        public YoutubePlayer_Android()
        {
        }
        public void PlayYoutube(string id)
        {
            //ใช้เรียกชื่อขึ้นมาแสดง
            //var context = Forms.Context;
            //Toast.MakeText(context,"ID: " + id,ToastLength.Long).Show();

            var c = Forms.Context;
            var uri = Android.Net.Uri.Parse("http://www.youtube.com/watch?v=" + id);
            var i = new Intent(Intent.ActionView, uri);
            c.StartActivity(i);
        }
    }
}
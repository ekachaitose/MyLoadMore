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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using MyLoadMore;
using MyLoadMore.Droid;

[assembly: ExportRenderer(typeof(XLabel), typeof(XLabelRenderer))]
namespace MyLoadMore.Droid
{
   public class XLabelRenderer : LabelRenderer
    {
        public XLabelRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var label = (TextView)Control; // for example
            Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "DS-DIGIT.TTF");  // font name specified here
            label.Typeface = font;
        }
    }
    
}
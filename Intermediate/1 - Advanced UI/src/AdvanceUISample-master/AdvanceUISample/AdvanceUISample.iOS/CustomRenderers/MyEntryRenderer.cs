using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdvanceUISample.Controls;
using AdvanceUISample.iOS.CustomRenderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace AdvanceUISample.iOS.CustomRenderers
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.BackgroundColor = UIColor.DarkGray;
            }
        }
    }
}
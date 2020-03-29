using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AdvanceUISample.Droid.Effects;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("AdvanceUISample")]
[assembly: ExportEffect(typeof(FocusEffect), nameof(FocusEffect))]
namespace AdvanceUISample.Droid.Effects
{
    public class FocusEffect : PlatformEffect
    {
        Android.Graphics.Color focusedBackgroundColor = Android.Graphics.Color.Crimson;
        Android.Graphics.Color backgroundColor;
        protected override void OnAttached()
        {
            backgroundColor = Android.Graphics.Color.LightGreen;
            Control.SetBackgroundColor(backgroundColor);
        }

        protected override void OnDetached()
        {

        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if(args.PropertyName == VisualElement.IsFocusedProperty.PropertyName)
            {
                if(Control.Background is ColorDrawable colorDrawable && colorDrawable.Color == backgroundColor)
                {
                    Control.SetBackgroundColor(focusedBackgroundColor);
                }
                else
                {
                    Control.SetBackgroundColor(backgroundColor);
                }
            }
        } 
    }
}
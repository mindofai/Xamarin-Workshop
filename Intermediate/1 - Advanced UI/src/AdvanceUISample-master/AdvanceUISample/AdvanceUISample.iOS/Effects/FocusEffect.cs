using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AdvanceUISample.iOS.Effects;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("AdvanceUISample")]
[assembly: ExportEffect(typeof(FocusEffect), nameof(FocusEffect))]
namespace AdvanceUISample.iOS.Effects
{
    public class FocusEffect : PlatformEffect
    {
        UIColor focusedBackgroundColor = UIColor.DarkGray;
        UIColor backgroundColor;
        protected override void OnAttached()
        {
            backgroundColor = UIColor.Cyan;
            Control.BackgroundColor = backgroundColor;
        }

        protected override void OnDetached()
        {

        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == VisualElement.IsFocusedProperty.PropertyName)
            {
                if (Control.BackgroundColor == backgroundColor)
                {
                    Control.BackgroundColor = focusedBackgroundColor;
                }
                else
                {
                    Control.BackgroundColor = backgroundColor;
                }
            }
        }
    }
}
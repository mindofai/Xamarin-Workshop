using CrudLocalDb.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudLocalDb.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateItemDetailPage : ContentPage
    {
        public UpdateItemDetailPage(UpdateItemDetailViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
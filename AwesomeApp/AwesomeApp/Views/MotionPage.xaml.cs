using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AwesomeApp.ViewModels;

namespace AwesomeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MotionPage : ContentPage
    {
        readonly MotionViewModel _vm;
        public MotionPage()
        {
            InitializeComponent();
            BindingContext = _vm = new MotionViewModel();
        }

        protected override void OnAppearing()
        {
            _vm.ToggleAccelerometer();
        }
    }
}
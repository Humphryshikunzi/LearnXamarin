using LearnXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace LearnXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceOrientationView : ContentPage
    {
        public DeviceOrientationView()
        {
            InitializeComponent();
            var orient = new Button
            {
                Text = "Get Orientation",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            orient.Clicked += (sender, e) => {
                var orientation = DependencyService.Get<IDeviceOrientation>().GetOrientation();
                switch (orientation)
                {
                    case DeviceOrientations.Undefined:
                        orient.Text = "Undefined";
                        break;
                    case DeviceOrientations.Landscape:
                        orient.Text = "Landscape";
                        break;
                    case DeviceOrientations.Portrait:
                        orient.Text = "Portrait";
                        break;
                }
            };
            Content = orient;
        }
    }
}
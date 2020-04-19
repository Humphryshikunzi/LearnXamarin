using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagingCenterView : ContentPage
    {
        public MessagingCenterView()
        {
            InitializeComponent();
            Sub();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            MessagingCenter.Send<MessagingCenterView, string>(this, "Hi", "Jambo Africa");


        }
        public void Sub()
        {
            MessagingCenter.Subscribe<MessagingCenterView, string>(this, "Hi", (sender, arg) =>
            {   
                // do something whenever the "Hi" message is sent });
                AfricaMap.IsVisible = true;
                MapText.Text = arg;

            });
        }
    }

 }
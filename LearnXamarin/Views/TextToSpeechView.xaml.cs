using LearnXamarin.ViewModels;
using Microsoft.Extensions.DependencyModel;
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
    public partial class TextToSpeechView : ContentPage
    {
        public TextToSpeechView()
        {
            InitializeComponent();
            var speak = new Button()
            {
                Text = "Jambo Africa",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };
            speak.Clicked += (sender, e) =>
            {
                DependencyService.Get<ITextToSpeech>().Speak("Jambo Africa, Hello Kenya");
            };
            Content = speak;
        }
    }
}
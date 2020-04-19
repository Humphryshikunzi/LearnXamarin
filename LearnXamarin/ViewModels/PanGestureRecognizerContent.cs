using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LearnXamarin.ViewModels
{
    class PanGestureRecognizerContent : ContentView
    {
        double x, y;
        public PanGestureRecognizerContent()
        {
            // Set PanGestureRecognizer.TouchPoints to control the    
            // number of touch points needed to pan  
            var panGesture = new PanGestureRecognizer ();   
            panGesture.PanUpdated += OnPanUpdated;   
            GestureRecognizers.Add (panGesture); 
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var width = (double)App.Current.Properties["width"];
            var height = (double)App.Current.Properties["height"];
            
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    // Translate and ensure we don't pan beyond the wrapped user interface element bounds.    
                    Content.TranslationX = Math.Max(Math.Min(0, x + e.TotalX), -Math.Abs(Content.Width - width)); // width represents App.ScreenWidth
                    Content.TranslationY = Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs(Content.Height -  width)); // height represents App.ScreenHeight
                    break;
                case GestureStatus.Completed:
                    // Store the translation applied during the pan    
                    x = Content.TranslationX;
                    y = Content.TranslationY; break;
            }
        }
       
    }
}

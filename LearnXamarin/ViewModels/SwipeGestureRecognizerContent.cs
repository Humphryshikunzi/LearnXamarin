using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LearnXamarin.ViewModels
{
    class SwipeGestureRecognizerContent : ContentView
    {
        public event EventHandler<SwipedEventArgs> Swipe;
        public SwipeGestureRecognizerContent() 
        { 
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Left)); 
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Right));
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Up)); 
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Down)); 
        }
        SwipeGestureRecognizer GetSwipeGestureRecognizer(SwipeDirection direction) 
        {
            var swipe = new SwipeGestureRecognizer 
            {
                Direction = direction 
            }; 
            swipe.Swiped += (sender, e) => Swipe?.Invoke(this, e); return swipe; 
        }
    }
}

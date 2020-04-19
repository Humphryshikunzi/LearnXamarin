using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Views;
using Android.Widget;
using LearnXamarin.Droid.DependencyServices;
using LearnXamarin.ViewModels;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechImplementation))]
namespace LearnXamarin.Droid.DependencyServices
{
    public class TextToSpeechImplementation : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;
        public void Speak(string text)
        {
            toSpeak = text;
            //if (speaker == null)
            //{
            //    speaker = new TextToSpeech(MainActivity.Instance, this);
            //}
            //else
            //{
            //    speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            //}
            speaker.Speak(toSpeak, QueueMode.Flush, null, null);
        }
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }
    }
}
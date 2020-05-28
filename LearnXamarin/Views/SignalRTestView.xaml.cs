using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignalRTestView : ContentPage
    {

        HubConnection hubConnection;
        ObservableCollection<MessageModel> messages;
        public SignalRTestView()
        {
            InitializeComponent();
            messages = new ObservableCollection<MessageModel>();
            MessagesListView.ItemsSource = messages;
        }
        protected  async override void OnAppearing()
        {
            base.OnAppearing();
            // localhost for UWP/iOS or special IP for Android
            var ip = "localhost";
            if (Device.RuntimePlatform == Device.Android)
                ip = "10.0.2.2";

            hubConnection = new HubConnectionBuilder()
                //.WithUrl($"https://menopausebackendapi.azurewebsites.net/chatHub")
                .WithUrl($"http://{ip}:5000/chatHub")
                .Build();
             await Connect();


            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var finalMessage = $"{user} says {message}";
                // Update the UI
            });
        }
        public void ReceiveMessage()
        {
            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var finalMessage = $"{user} says {message}";
                // Update the UI
                messages.Add(new MessageModel() { Sender = user, Message = message });
            });
        }

        async Task Connect()
        {
            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                // Something has gone wrong
            }
        }

        async Task SendMessage(string user, string message)
        {
            try
            {
                await hubConnection.InvokeAsync("SendMessage", user, message);
            }
            catch (Exception ex)
            {
                // send failed
            }
        }

        private async void SendMessageButton_Clicked(object sender, EventArgs e)
        {
            await SendMessage(nameEntry.Text, emailEntry.Text);
        }



    }

    public class MessageModel
    {
        public  string  Sender { get; set; }
        public  string  Message { get; set; }
    }
}
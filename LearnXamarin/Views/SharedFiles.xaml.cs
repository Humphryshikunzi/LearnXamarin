using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SharedFiles : ContentPage
    {
        public SharedFiles()
        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("LearnXamrinFormsFiles",CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("CodeOfContact.txt", CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync("Jambo Africa, Hello Kenya.Hope everyone is fine here," +
                " I just wanted to inform you that the sun has risen, Kindly wake up and get to work.No one will " +
                "come and buid our Continent, only we will.");
           // Implement reading the files
        }
    }
}
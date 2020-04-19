using LearnXamarin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LearnXamarin.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public IEnumerable<User> Users { get; set; }
        public BaseViewModel()
        {
            Users = GetUsers();
        }

        protected IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    FirstName = "Isaac", Email="Isaac@254",
                    Description = "I am a Fourth Year Student at Dedan Kimathi University Pursuing Bachelar of Science in EEE"
                },
                 new User()
                {
                    FirstName = "Isaac", Email="Isaac@254",
                    Description = "I am a Fourth Year Student at Dedan Kimathi University Pursuing Bachelar of Science in EEE"
                },
                  new User()
                {
                    FirstName = "Isaac", Email="Isaac@254",
                    Description = "I am a Fourth Year Student at Dedan Kimathi University Pursuing Bachelar of Science in EEE"
                },
                   new User()
                {
                    FirstName = "Isaac", Email="Isaac@254",
                    Description = "I am a Fourth Year Student at Dedan Kimathi University Pursuing Bachelar of Science in EEE"
                },
                    new User()
                {
                    FirstName = "Isaac", Email="Isaac@254",
                    Description = "I am a Fourth Year Student at Dedan Kimathi University Pursuing Bachelar of Science in EEE"
                },
                     new User()
                {
                    FirstName = "Isaac", Email="Isaac@254",
                    Description = "I am a Fourth Year Student at Dedan Kimathi University Pursuing Bachelar of Science in EEE"
                },
                 new User()
                {
                    FirstName = "Isaac", Email="Isaac@254",
                    Description = "I am a Fourth Year Student at Dedan Kimathi University Pursuing Bachelar of Science in EEE"
                },
                  new User()
                {
                    FirstName = "Isaac", Email="Isaac@254",
                    Description = "I am a Fourth Year Student at Dedan Kimathi University Pursuing Bachelar of Science in EEE"
                },
                   new User()
                {
                    FirstName = "Isaac", Email="Isaac@254",
                    Description = "I am a Fourth Year Student at Dedan Kimathi University Pursuing Bachelar of Science in EEE"
                },
                    new User()
                {
                    FirstName = "Isaac", Email="Isaac@254",
                    Description = "I am a Fourth Year Student at Dedan Kimathi University Pursuing Bachelar of Science in EEE"
                }

            };
            return users;
        }

    }
}

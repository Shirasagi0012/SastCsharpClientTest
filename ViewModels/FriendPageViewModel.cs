using Newtonsoft.Json;
using SastCsharpClientTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SastCsharpClientTest.ViewModels
{
    public class FriendPageViewModel : INotifyPropertyChanged
    {
        public List<Friend> FriendsList { get; set; }
        public Friend FriendsItem { get; set; }
        public int FriendsItemIndex { get; set; }
        public bool isTextBoxEnabled { get; set; }

        public FriendPageViewModel() 
        {
            FriendsList = new();
            ReadFromJSON();
            FriendsItem = FriendsList[0];
            isTextBoxEnabled = false;
        }

        public void ReadFromJSON()
        {
            string jsonData = File.ReadAllText("src//data.json");
            FriendsList = JsonConvert.DeserializeObject<Friend[]>(jsonData)!.ToList();
            RaisePropertyChanged(nameof(FriendsList));
        }

        public void WriteToJSON()
        {
            var output = JsonConvert.SerializeObject(FriendsList);
            Debug.WriteLine(output);
            File.WriteAllText("src//data.json", output);
        }

        public bool CanEditButtonExecute()
        {
            return !isTextBoxEnabled;
        }

        public bool CanSaveButtonExecute()
        {
            return isTextBoxEnabled;
        }

        public ICommand EditAction
        {
            get
            {
                switch (isTextBoxEnabled)
                {
                    case true:
                        return new RelayCommand(SaveTextBox, CanSaveButtonExecute);
                    case false:
                        return new RelayCommand(EditTextBox, CanEditButtonExecute);
                };
            }
        }

        void EditTextBox()
        {
            isTextBoxEnabled = true;
            RaisePropertyChanged($"{nameof(isTextBoxEnabled)}");
            RaisePropertyChanged($"{nameof(EditAction)}");
        }

        void SaveTextBox()
        {
            isTextBoxEnabled = false;
            FriendsList[FriendsItemIndex] = FriendsItem;
            WriteToJSON();
            ReadFromJSON();
            RaisePropertyChanged($"{nameof(isTextBoxEnabled)}");
            RaisePropertyChanged($"{nameof(EditAction)}");
            RaisePropertyChanged($"{nameof(FriendsItem)}");
            RaisePropertyChanged($"{nameof(FriendsList)}");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}

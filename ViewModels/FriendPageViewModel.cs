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

        public string SelectedItemName
        {
            get
            {
                return FriendsList[FriendsItemIndex].Name;
            }
            set
            {
                FriendsList[FriendsItemIndex] = new(FriendsList[FriendsItemIndex].Id, value,FriendsList[FriendsItemIndex].Description, FriendsList[FriendsItemIndex].ImgUrl);
            }
        }


        public string SelectedItemDescription
        {
            get
            {
                return FriendsList[FriendsItemIndex].Description;
            }
            set
            {
                FriendsList[FriendsItemIndex] = new(FriendsList[FriendsItemIndex].Id, FriendsList[FriendsItemIndex].Name, value, FriendsList[FriendsItemIndex].ImgUrl);
            }
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

        void EditTextBox()
        {
            isTextBoxEnabled = true;
            RaisePropertyChanged("");
        }

        void SaveTextBox()
        {
            isTextBoxEnabled = false;
            var _currentIndex = FriendsItemIndex;
            WriteToJSON();
            ReadFromJSON();
            FriendsItemIndex =_currentIndex;
            RaisePropertyChanged("");
        }

        public ICommand EditAction
        {
            get
            {
                switch (isTextBoxEnabled)
                {
                    case true:
                        return new RelayCommand(SaveTextBox, () => isTextBoxEnabled);
                    case false:
                        return new RelayCommand(EditTextBox, () => !isTextBoxEnabled);
                };
            }
        }

        void OnComboBoxSelectionChanged()
        {
            RaisePropertyChanged("");
        }

        public ICommand ComboBoxSelectionChanged
        {
            get
            {
                return new RelayCommand(OnComboBoxSelectionChanged, () => true);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}

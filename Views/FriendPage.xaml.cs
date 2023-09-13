using Newtonsoft.Json;
using SastCsharpClientTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SastCsharpClientTest.Views
{
    /// <summary>
    /// FriendPage.xaml 的交互逻辑
    /// </summary>
    public partial class FriendPage : Page
    {
        public FriendPage()
        {
            InitializeComponent();
            SetComboBox();
        }

        private List<Friend> friends = null!;

        private void SetComboBox()
        {
            string jsonData = File.ReadAllText("src//data.json");
            friends = JsonConvert.DeserializeObject<Friend[]>(jsonData)!.ToList();
            FriendOption.ItemsSource = friends.Select(friend => friend.Name);
        }

        private void ChooseFriend(object sender, EventArgs e)
        {
            var comboBox = (sender as ComboBox)!;
            if (comboBox.SelectedItem is null)
                return;
            var friend = friends.First(f => f.Name == comboBox.SelectedItem.ToString());
            NameBox.Text = friend.Name;
            DescriptionBox.Text = friend.Description;
            ImageBox.Source = new BitmapImage(
                new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, friend.ImgUrl))
            );
            EditButton.Visibility = Visibility.Visible;
            SetTextBoxEnabled(false);
        }

        private void SetTextBoxEnabled(bool isEnabled)
        {
            NameBox.IsEnabled = isEnabled;
            DescriptionBox.IsEnabled = isEnabled;
        }

        private void EditFriend(object sender, RoutedEventArgs e)
        {
            SetTextBoxEnabled(true);
        }
    }
}

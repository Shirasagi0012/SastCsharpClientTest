using Newtonsoft.Json;
using SastCsharpClientTest.Models;
using SastCsharpClientTest.ViewModels;
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
        FriendPageViewModel vm = new FriendPageViewModel();
        public FriendPage()
        {
            InitializeComponent();
            this.vm = new FriendPageViewModel();
            vm.ReadFromJSON();
        }

        private void ChooseFriend(object sender, EventArgs e)
        {
            //var comboBox = (sender as ComboBox)!;
            //if (comboBox.SelectedItem is null)
            //    return;
            //var friend = friends.First(f => f.Name == comboBox.SelectedItem.ToString());
            //NameBox.Text = friend.Name;
            //DescriptionBox.Text = friend.Description;
            //ImageBox.Source = new BitmapImage(
            //    new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, friend.ImgUrl))
            //);
            //EditButton.Visibility = Visibility.Visible;
            //SetTextBoxEnabled(false);
        }

        //private void FriendOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if(EditButton is not null)
        //    EditButton.Visibility = Visibility.Visible;
        //}
    }
}

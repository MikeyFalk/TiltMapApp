using AwesomeApp.Models;
using AwesomeApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;


namespace AwesomeApp.ViewModels
{
    class HomeViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        public event PropertyChangedEventHandler PropertyChanged;

        private string text = string.Empty;

        public string Text
        {
            get { return text; }
            set
            {
                if (text == value)
                {
                    return;
                }
                text = value;
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(Confirmation));
            }
        }

        public string Confirmation => $"You Typed: {Text}";
        public ObservableCollection<Item> Items { get; set; }

        public HomeViewModel()
        {
            Items = new ObservableCollection<Item>();
        }

        public async void Save()
        {
            Item newItem = new Item()
            {
                Id = 0,
                Text = Text,
            };
        
        await DataStore.AddItemAsync(newItem);
        await GetAllItems();
    }
    public async Task GetAllItems()
    {
        try
        {
            Items.Clear();
            var items = await DataStore.GetItemsAsync();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    void OnPropertyChanged(string text)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(text));
    }
}
}

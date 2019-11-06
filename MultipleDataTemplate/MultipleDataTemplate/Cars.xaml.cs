using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace MultipleDataTemplate
{
    public sealed partial class Cars : Page, INotifyPropertyChanged
    {
        public object _ItemSource { get; set; }

        public object ItemSource
        {
            get { return _ItemSource; }
            set
            {
                _ItemSource = value;
                this.OnPropertyChanged();
            }
        }
        public DataTemplate _itemTemplate { get; set; }

        public DataTemplate ItemTemplate
        {
            get { return _itemTemplate; }
            set
            {
                _itemTemplate = value;
                this.OnPropertyChanged();
            }
        }
        public Cars()
        {
            this.InitializeComponent();
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;


        private void CarsClick(object sender, RoutedEventArgs e)
        {
            ItemSource = new List<Car>() 
            {
                new Car() { Make = "Volkswagon", Model = "Golf" },
                new Car() { Make = "Ford", Model = "Mustang" },
                new Car() { Make = "Tesla", Model = "Model S" }
            };
            ItemTemplate = this.Resources["CarKey"] as DataTemplate;
        }

        private void BikeClick(object sender, RoutedEventArgs e)
        {
            ItemSource = new List<Employee>()
            {
                new Employee() { Name = "Jon", EmpID = "Snow" },
                new Employee() { Name = "Arya", EmpID = "Stark" },
                new Employee() { Name = "Sansa", EmpID = "Stark" }
            };
            ItemTemplate = this.Resources["BikeKey"] as DataTemplate;

        }
    }
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
    }
    public class Employee
    {
        public string Name { get; set; }
        public string EmpID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkRegistry.model;
using WorkRegistry.viewmodel;

namespace WorkRegistry.view
{
    /// <summary>
    /// Interaction logic for NewCarWindow.xaml
    /// </summary>
    public partial class NewCarWindow : Window
    {
        NewCarViewModel ViewModel { get; set; }
        public Car CurrentCar { get; set; }

        public NewCarWindow(NewCarViewModel newCarViewModel, Car currentCar)
        {
            if (currentCar == null)
                CurrentCar = new Car();
            else
                CurrentCar = currentCar;
            ViewModel = newCarViewModel;
            this.DataContext = this;
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveCar(CurrentCar);
            this.Close();
        }
    }
}

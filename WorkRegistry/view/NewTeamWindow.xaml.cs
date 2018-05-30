using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for NewTeamWindow.xaml
    /// </summary>
    public partial class NewTeamWindow : Window
    {
        NewTeamViewModel ViewModel
        {
            get; set;
        }

        public NewTeamWindow(NewTeamViewModel newTeamViewModel)
        {
            ViewModel = newTeamViewModel;
            ViewModel.PropertyChanged += RefreshView;
            this.DataContext = this;
            InitializeComponent();

            ExcludedWorkersListView.ItemsSource = newTeamViewModel.ExcludedWorkers;
            IncludedWorkersListView.ItemsSource = newTeamViewModel.IncludedWorkers;
        }

        public void RefreshView(object sender, PropertyChangedEventArgs e)
        {
            IncludedWorkersListView.InvalidateArrange();
            IncludedWorkersListView.UpdateLayout();

            ExcludedWorkersListView.InvalidateArrange();
            ExcludedWorkersListView.UpdateLayout();
        }

        private void AddWorkerToTeamButton_Click(object sender, RoutedEventArgs e)
        {
            Worker SelectedWorker = ExcludedWorkersListView.SelectedItem as Worker;
            ViewModel.AddWorkerToTeam(SelectedWorker);
        }

        private void RemoveWorkerFromTeamButton_Click(object sender, RoutedEventArgs e)
        {
            Worker SelectedWorker = IncludedWorkersListView.SelectedItem as Worker;
            ViewModel.RemoveWorkerFromTeam(SelectedWorker);
        }

        private void SaveTeam_Click(object sender, RoutedEventArgs e)
        {
            // TODO Bind testbox to teams name is currently not working!!!
            ViewModel.CurrentTeam.Name = CurrentTeamName.Text;
            ViewModel.Save();
            this.Close();
            // Console.WriteLine(ViewModel.CurrentTeam.Name);
        }
    }
}

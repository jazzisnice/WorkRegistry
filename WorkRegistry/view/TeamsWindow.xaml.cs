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
    /// Interaction logic for TeamsWindow.xaml
    /// </summary>
    public partial class TeamsWindow : Window
    {
        public TeamsViewModel TeamsViewModel;

        public TeamsWindow(TeamsViewModel teamsViewModel)
        {
            TeamsViewModel = teamsViewModel;
            InitializeComponent();

            teamsListBox.ItemsSource = TeamsViewModel.Teams;
        }

        private void NewTeamButton_Click(object sender, RoutedEventArgs e)
        {
            // Adding null parameter, since we want to create a new team..
            NewTeamWindow newTeamWindow = new NewTeamWindow(new NewTeamViewModel(TeamsViewModel, null));
            newTeamWindow.Show();
        }

        private void ModifyTeam(object sender, RoutedEventArgs e)
        {
            Button source = sender as Button;
            Team CurrentTeam = source.DataContext as Team;
            NewTeamWindow ModifyTeamWindow = new NewTeamWindow(new NewTeamViewModel(TeamsViewModel, CurrentTeam));
            ModifyTeamWindow.Show();
        }
        
        private void DeleteTeam(object sender, RoutedEventArgs e)
        {
            Button source = sender as Button;
            Team CurrentTeam = source.DataContext as Team;
            TeamsViewModel.DeleteTeam(CurrentTeam);
        }
    }
}

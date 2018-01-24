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
    /// Interaction logic for NewTeamWindow.xaml
    /// </summary>
    public partial class NewTeamWindow : Window
    {
        private TeamsViewModel TeamsViewModel;
        private Team CurrentTeam;
        private List<Worker> ExcludedWorkers = new List<Worker>();

        public NewTeamWindow(TeamsViewModel teamsViewModel, Team currentTeam)
        {
            TeamsViewModel = teamsViewModel;
            CurrentTeam = currentTeam;
            InitializeComponent();

            foreach (Worker worker in DbOperations.GetAllWorkers())
            {
                if (!CurrentTeam.Workers.Contains(worker))
                {
                    ExcludedWorkers.Add(worker);
                }
            }

            ExcludedWorkersListView.ItemsSource = ExcludedWorkers;
        }
    }
}

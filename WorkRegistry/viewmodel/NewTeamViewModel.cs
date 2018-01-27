using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkRegistry.model;

namespace WorkRegistry.viewmodel
{
    public class NewTeamViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public TeamsViewModel TeamsViewModel
        {
            get; set;
        }

        public Team CurrentTeam
        {
            get; set;
        }

        public ObservableCollection<Worker> ExcludedWorkers
        {
            get; set;
        }

        public ObservableCollection<Worker> IncludedWorkers
        {
            get; set;
        }

        public NewTeamViewModel(TeamsViewModel teamsViewModel, Team currentTeam)
        {
            TeamsViewModel = teamsViewModel;
            CurrentTeam = currentTeam;
            
            // If the currentTeam parameter is set, we are editing a team
            if (currentTeam != null)
            {
                IncludedWorkers = new ObservableCollection<Worker>(CurrentTeam.Workers);
                foreach (Worker worker in DbOperations.GetAllWorkers())
                {
                    if (!IncludedWorkers.Contains(worker))
                    {
                        ExcludedWorkers.Add(worker);
                    }
                }
            }
            // If it is null, we are creating a new team,
            // all of the workers will be in the excluded list, since the team is not created yet
            else
            {
                CurrentTeam = new Team();
                ExcludedWorkers = new ObservableCollection<Worker>(DbOperations.GetAllWorkers());
                IncludedWorkers = new ObservableCollection<Worker>();
            }

        }

        // From the excluded list, add a worker to the team
        public void AddWorkerToTeam(Worker worker)
        {
            if (worker != null)
            {
                IncludedWorkers.Add(worker);
                ExcludedWorkers.Remove(worker);
                PropertyChanged(this, new PropertyChangedEventArgs("CurrentTeam.Workers"));
                PropertyChanged(this, new PropertyChangedEventArgs("ExcludedWorkers"));
            }
        }

        // Remove one worker from the team and add it to the excluded
        public void RemoveWorkerFromTeam(Worker worker)
        {
            if (worker != null)
            {
                IncludedWorkers.Remove(worker);
                ExcludedWorkers.Add(worker);
                PropertyChanged(this, new PropertyChangedEventArgs("CurrentTeam.Workers"));
                PropertyChanged(this, new PropertyChangedEventArgs("ExcludedWorkers"));
            }
        }

        public void Save()
        {
            TeamsViewModel.AddOrEditTeam(CurrentTeam);
        }
    }
}

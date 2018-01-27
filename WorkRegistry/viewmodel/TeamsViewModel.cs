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
    public class TeamsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Team> Teams;

        public TeamsViewModel()
        {
            Teams = new ObservableCollection<Team>(DbOperations.GetAllTeams());
        }

        public void AddOrEditTeam(Team newTeam)
        {
            // TODO nagyon, hogy lehet hogy ne kelljen az összeset újra berakni?? 
            DbOperations.AddOrEditTeam(newTeam);
            Teams.Clear();
            foreach (Team team in DbOperations.GetAllTeams())
            {
                Teams.Add(team);
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Workers"));
        }

        public void DeleteTeam(Team currentTeam)
        {
            DbOperations.DeleteTeam(currentTeam);
            Teams.Remove(currentTeam);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Teams"));
        }
    }
}

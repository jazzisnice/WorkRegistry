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
    public class WorksViewModel
    {
        private ObservableCollection<Work> Works = new ObservableCollection<Work>(DbOperations.GetAllWorks());
        public event PropertyChangedEventHandler PropertyChanged;

        public void addNewWork(Work work)
        {
            DbOperations.AddNewWork(work);
            Works.Add(work);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Works"));
        }

        public ObservableCollection<Work> GetAllWorks()
        {
            return this.Works;
        }

    }

}

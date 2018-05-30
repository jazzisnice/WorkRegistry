using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkRegistry.model;

namespace WorkRegistry.viewmodel
{
    public class WorksViewModel
    {
        private ObservableCollection<Work> Works = new ObservableCollection<Work>(DbOperations.GetAllTasks());

        public void addNewWork()
        {

        }

        public ObservableCollection<Work> GetAllWorks()
        {
            return this.Works;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkRegistry.model;

namespace WorkRegistry.view
{
    public class WorkersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Worker> Workers = new ObservableCollection<Worker>(DbOperations.GetAllWorkers());

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddOrEditWorker(Worker newWorker)
        {
            // TODO nagyon, hogy lehet hogy ne kelljen az összeset újra berakni?? 
            DbOperations.AddOrEditWorker(newWorker);
            Workers.Clear();
            foreach (Worker worker in DbOperations.GetAllWorkers())
            {
                Workers.Add(worker);
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Workers"));
        }

        public int DeleteWorker(Worker worker)
        {
            int deleted = DbOperations.DeleteWorker(worker);
            if (deleted > 0)
                PropertyChanged(this, new PropertyChangedEventArgs("Workers"));
            Workers.Remove(Workers.Where(x => x.Id == worker.Id).Single());
            return deleted;
        }

        public void EditWorker()
        {

        }
    }
}

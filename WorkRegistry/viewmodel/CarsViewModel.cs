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
    public class CarsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Car> Cars { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public CarsViewModel()
        {
            Cars = new ObservableCollection<Car>(DbOperations.GetAllCars());
        }

        public void DeleteCar(Car car)
        {
            Cars.Remove(car);
            DbOperations.RemoveCar(car);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Cars"));
        }

        public void AddOrEditCar(Car car)
        {
            Cars.Clear();
            DbOperations.AddOrEditCar(car);
            foreach (Car CurrentCar in DbOperations.GetAllCars())
            {
                Cars.Add(CurrentCar);
            }
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Cars"));
        }
    }
}

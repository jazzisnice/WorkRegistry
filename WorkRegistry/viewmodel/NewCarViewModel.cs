using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkRegistry.model;

namespace WorkRegistry.viewmodel
{
    public class NewCarViewModel
    {
        private CarsViewModel CarsViewModel;
        public Car CurrentCar;

        // If the currentCar is null, we are adding a new one, else we are editing an existing car
        public NewCarViewModel(CarsViewModel carsViewModel, Car currentCar)
        {
            if (currentCar == null)
            {
                CurrentCar = new Car();
            }


        }
    }
}

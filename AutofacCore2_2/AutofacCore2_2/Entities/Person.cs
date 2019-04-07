using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacCore2_2.Entities
{
    public interface IPerson
    {
        List<ICar> Cars { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        void BuyCar();
    }

    /// <summary>
    /// LD001 Simulating relation "Person" owns "Car"
    /// LD004 for each class select the class name and then by "ctrl+." exstract the interface
    /// LD007 same thing here. Other changes: "List<Car>" -> "List<ICar>"
    /// </summary>
    public class Person : IPerson
    {
        public string Name {get; set;}
        public string Surname { get; set; }
        public List<ICar> Cars { get; set; } = new List<ICar>();

        #region Region Normal Approach

        public Person(string name, string surname, ICar car)
        {
            Name = name;
            Surname = surname;
            Cars.Add(car);
        }
        public void BuyCar()
        {
            Car aBoughtCar = new Car("ford", "yellow");
            Logger aLogger = new Logger();
            
            aBoughtCar.RunDiagnosis();
            aBoughtCar.Sell();

            Cars.Add(aBoughtCar);
            aLogger.log("Car purchase happened");
        }

        #endregion Region Normal Approach End

        #region Region DependencyInjection Approach

        ILogger _aLogger;
        ICar _aCar;
        public Person(ILogger alogger, ICar aCar)
        {
            _aLogger = alogger;
            _aCar = aCar;
        }

        public void BuyCarDepInj()
        {
            _aCar.Brand = "ford";
            _aCar.Color = "yellow";

            _aCar.RunDiagnosis();
            _aCar.Sell();

            Cars.Add(_aCar);
            _aLogger.log("Car purchase happened");
        }

        #endregion Region DependencyInjection Approach End
    }



}

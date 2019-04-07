using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacCore2_2.Entities
{
    public interface ICar
    {
        string Brand { get; set; }
        string Color { get; set; }
        void RunDiagnosis();
        void Sell();
    }

    /// <summary>
    /// LD005 for each class select the class name and then by "ctrl+." exstract the interface
    /// LD006 now need to stop depending on lower level, so creation of constructor and private "_aLogger" and new region using dependency injection
    /// </summary>
    public class Car : ICar
    {
        public string Brand { get; set; }
        public string Color { get; set; }


        #region Region Standard Approach
        
        public Car(string brand, string color)
        {
            Brand = brand;
            Color = color;
        }

        public void RunDiagnosis()
        {
            Logger aLogger = new Logger();
            aLogger .log("Diagnosis was ran");
        }

        public void Sell()
        {
            Logger aLogger = new Logger();
            aLogger.log("A Car Was Sold");
        }

        #endregion Region Standard Approach End

        #region Region Dependency Injection Approach

        ILogger _aLogger;
        public Car(ILogger alogger)
        {
            _aLogger = alogger;
        }

        public void RunDiagnosisDepInj()
        {
            //Initialization not needed
            //Logger aLogger = new Logger();
            _aLogger.log("Diagnosis was ran");
        }

        public void SellDepIng()
        {
            //Initialization not needed
            //Logger aLogger = new Logger();
            _aLogger.log("A Car Was Sold");
        }

        #endregion Region Dependency Injection Approach End

    }
}

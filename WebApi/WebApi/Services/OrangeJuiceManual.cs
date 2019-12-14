using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;
using WebApi.Interface;

namespace WebApi.Services
{
    public class OrangeJuiceManual : IManual, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this); //Hey, GC: don't bother calling finalize later
        }

        public Orange GetFruit()
        {
            return new Orange();
        }

        public int NumberOfFruits(int numberOfPeoples)
        {
            if(numberOfPeoples<0) throw new ArgumentException("Please insert Non negative number");
            return numberOfPeoples * 2;
        }
    }
}

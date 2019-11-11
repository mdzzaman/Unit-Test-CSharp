using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Interface
{
    public interface IManual
    {
        IFruit GetFruit();
        int NumberOfFruits(int numberOfPeoples);
    }
}

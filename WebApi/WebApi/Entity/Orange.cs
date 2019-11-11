using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interface;

namespace WebApi.Entity
{
    public class Orange : IFruit
    {
        private string _Name = "Orange";
        private string _Color = "Color-Orange";
        private int _Price = 120;

        public string Name { get => this._Name; set => _Name = value; }
        public string Color { get => _Color; set => _Color = value; }
        public int Price { get => _Price; set => _Price = value; }
    }
}

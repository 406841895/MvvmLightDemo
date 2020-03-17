using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightDemo.Model
{
    public class StudentModel:ObservableObject
    {
        private string name;
        private int age;
        private string address;
        public string Name { get=>name; set { Set(ref name, value); } }
        public int Age { get => age; set { age = value; RaisePropertyChanged("Age"); } }
        public string Address { get=>address; set { address = value; RaisePropertyChanged(() => Address); } }
    }
}

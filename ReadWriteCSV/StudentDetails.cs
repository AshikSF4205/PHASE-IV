using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadWriteCSV
{
    public enum GenderEnum { Male, Female }
    public class StudentDetails
    {
        public string Name { get; set; }

        public string FatherName { get; set; }

        public GenderEnum Gender { get; set; }

        public DateTime DOB { get; set; }

        public double Mark { get; set; }
    }
}
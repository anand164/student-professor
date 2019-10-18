using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProfessor.Model
{
    class StudentTaughtByProfessor 
    {
        public string professorName { get; set; }

        public string courseName { get; set; }
        public List<studentTable> studentList = new List<studentTable>() { }; 
    }
}

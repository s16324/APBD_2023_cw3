using cwiczenia_3_s16324.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cwiczenia_3_s16324.Services
{
    public class ValidationManager
    {


        public Boolean validateStudentInput(Student s)
        {
            return s.validate();
        }

        public Boolean validateIndexFormat(string i)
        {
            return Regex.IsMatch(i, @"^\d\d\d\d$");
        }

        public Boolean validateIndexUnique(List<Student> sl, Student s)
        {
            return !sl.Contains(s);
        }

    }
}

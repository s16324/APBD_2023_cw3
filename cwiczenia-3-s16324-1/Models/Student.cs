using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_3_s16324.Models
{
    public class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }
        public string BirthDate { get; set; }
        public string Studies { get; set; }
        public string Mode { get; set; }
        public string Email { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   IndexNumber == student.IndexNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IndexNumber);
        }

        public override string ToString()
        {
            return FirstName + "," + LastName + "," + IndexNumber + "," + BirthDate + "," + Studies + "," + Mode + "," + Email + "," + FathersName + "," + MothersName;
        }

        //Check if student contains all required data
        public Boolean validate()
        {
            return FirstName != null && LastName != null && IndexNumber != null && BirthDate != null && Studies != null && Mode != null && Email != null && FathersName != null && MothersName != null;
        }

    }

    


}

using cwiczenia_3_s16324.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_3_s16324.Services
{

    public class DataUpdateManager
    {
        public List<Student> students;
        DataQueryManager query;
        DataInsertManager insert;

        public DataUpdateManager()
        {
            students = new List<Student>();
            query = new DataQueryManager();
            students = query.GetStudents();
            insert = new DataInsertManager();

        }

        //Find and update student from input json
        public Student updateStudent(Student student, string index)
        {
            foreach (Student s in students)
            {
                if (s.IndexNumber == index)
                {
                    UpdateStudentData(s, student);
                }
            }
            insert.WriteToFile(students);

            return query.GetStudentsByIndex(index);
        }

        //Update StudentObject data
        public void UpdateStudentData(Student o, Student n){
            o.FirstName = n.FirstName;
            o.LastName = n.LastName;
            o.BirthDate = n.BirthDate;
            o.Studies = n.Studies;
            o.Mode = n.Mode;
            o.Email = n.Email;
            o.FathersName = n.FathersName;
            o.MothersName = n.MothersName;
        }

    }
}

using cwiczenia_3_s16324.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_3_s16324.Services
{
    public class DataDeleteManager
    {
        public List<Student> students;
        DataQueryManager query;
        DataInsertManager insert;

        public DataDeleteManager()
        {
            students = new List<Student>();
            query = new DataQueryManager();
            students = query.GetStudents();
            insert = new DataInsertManager();
        }

        //Find and delete student with given indexNumber
        public Boolean DeleteStudent(string index)
        {
            Student deleteStudent = null; ;
            Boolean result = false;
            foreach (Student s in students)
            {
                if (s.IndexNumber == index)
                {
                    deleteStudent = s;
                }
            }
            if (deleteStudent != null)
            {
                DeleteObject(deleteStudent);
                insert.WriteToFile(students);
                result = true;
            }

            return result;
        }

        private void DeleteObject(Student s)
        {
            students.Remove(s);
        }
    }
}

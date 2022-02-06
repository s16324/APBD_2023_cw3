using cwiczenia_3_s16324.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_3_s16324.Services
{
    public class DataInsertManager
    {

        public List<Student> students;
        DataQueryManager query;

        public DataInsertManager()
        {
            students = new List<Student>();
            query = new DataQueryManager();
            students = query.GetStudents();

        }

        public Student AddStudents(Student student)
        {
            Boolean err = false;
            if (!students.Contains(student))
            {
                students.Add(student);
            }
            else
            {
                err = true;
            }
            
            WriteToFile();
            Student studentAdded = null;
            if (!err)
            {
                studentAdded = query.GetStudentsByIndex(student.IndexNumber);
            }
            return studentAdded;
        }

        public void WriteToFile()
        {
            string path = @".\Data\students.csv";

            

            using (StreamWriter outputFile = new StreamWriter(path, false))
            {
                foreach (Student line in students)
                    outputFile.WriteLine(line.ToString());

                outputFile.Close();
            }

        }

        public void WriteToFile(List<Student> list)
        {
            string path = @".\Data\students.csv";

            using (StreamWriter outputFile = new StreamWriter(path, false))
            {
                foreach (Student line in list)
                    outputFile.WriteLine(line.ToString());

                outputFile.Close();
            }

        }
    }
}

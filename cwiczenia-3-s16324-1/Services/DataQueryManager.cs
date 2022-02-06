using cwiczenia_3_s16324.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_3_s16324.Services
{
    public class DataQueryManager
    {
        FileInfo fileInfo;
        StreamReader streamReader;
        public List<Student> students;

        public DataQueryManager()
        {
            students = new List<Student>();
        }

        //Get all students from csv file
        public List<Student> GetStudents()
        {
            List<Student> AllList = GetData();
            return AllList;
        }

        //Return Student object (wrapper)
        public Student GetStudents(string type, string value)
        {
            //List<Student> QueriedList = new List<Student>();
            Student QueriedStudent = null;
            if (type == "index")
            {
                QueriedStudent = GetStudentsByIndex(value);
            }
            return QueriedStudent;
        }

        //Return Student object (by indexNumber)
        public Student GetStudentsByIndex(string i)
        {
            List<Student> AllList = GetData();
            Student QueriedStudent = null;
            foreach(Student s in AllList){
                if (s.IndexNumber == i)
                {
                    QueriedStudent = s;
                }
            }
            return QueriedStudent;
        }

        //Load csv file to List
        public List<Student> GetData()
        {
            students = null;
            students = new List<Student>();

            fileInfo = new FileInfo(@".\Data\students.csv");
                streamReader = new StreamReader(fileInfo.OpenRead());
                string line = null;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] tokens = line.Split(',');
                    students.Add(new Student
                    {
                        FirstName = tokens[0],
                        LastName = tokens[1],
                        IndexNumber = tokens[2],
                        BirthDate = tokens[3],
                        Studies = tokens[4],
                        Mode = tokens[5],
                        Email = tokens[6],
                        FathersName = tokens[7],
                        MothersName = tokens[8]

                    });
                }
            streamReader.Close();
            return students;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___List_of_Objects
{
    internal class Roster
    {
        //Fields
        private string name;
        private List<Student> students;

        //Properties
        /// <summary>
        /// A Get only property for the private string variable, name
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// A get only property for the private list of student objects, students
        /// </summary>
        public List<Student> Students
        {
            get { return students; }
        }

        //Constructor
        /// <summary>
        /// A constructor to initialize the roster name and students variables
        /// </summary>
        /// <param name="name">name of the roster</param>
        /// <param name="students">list of students on the roster</param>
        public Roster(string name)
        {
            this.name = name.Trim();
            this.students = new List<Student> { };
        }

        //Methods
        /// <summary>
        /// Searches through the entire roster for a student with a given name
        /// if the name is found, return the studen with that name, otherwise return null
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Student SearchByName(string name)
        {
            //Searches through list of students
            foreach (Student student in students)
            {
                //If a student with the name is found, return that student
                if (name == student.FullName)
                {
                    return student;
                }
            }
            //if a name isn't found, return null
            return null;
        }

        /// <summary>
        /// A method for programmers to add a Student object to the students list of the roster
        /// Only adds if there is no other student with the same name
        /// </summary>
        /// <param name="s"></param>
        public void AddStudent(Student s)
        {
            //if there is no student with a matching name to the student given
            if(SearchByName(s.FullName) == null)
            {
                //Add a new student and give feedback that the student was added
                students.Add(s);
                SmartConsole.PrintSuccess($"{s.FullName} was added to the {name}");
            }
            //Otherwise print the following error message
            else
            {
                SmartConsole.PrintError($"There is already a student with the name {s.FullName} in the roster!");
            }
        }

        public Student AddStudent()
        {
            //creates a new student based on user input via the Smart Console
            Student newStudent = new Student(
                SmartConsole.Prompt("What is the student's name?"),
                SmartConsole.Prompt("What is the student's major?"),
                SmartConsole.Prompt("What is the student's year level?", 1, 99));

            //if there is no student with a matching name to the student given
            if (SearchByName(newStudent.FullName) == null)
            {
                //Add a new student and give feedback that the student was added, returning the newStudent object
                students.Add(newStudent);
                SmartConsole.PrintSuccess($"{newStudent.FullName} was added to the {name}");
                return newStudent;
            }
            //otherwise print the following error message and return null
            else
            {
                SmartConsole.PrintError($"There is already a student with the name {newStudent.FullName} in the roster!");
                return null;
            }
        }

        public void DisplayRosters()
        {
            Console.WriteLine($"{name} has {students.Count} students: ");
            foreach(Student s in students)
            {
                Console.WriteLine(s.ToString());
            }
        }
    }
}

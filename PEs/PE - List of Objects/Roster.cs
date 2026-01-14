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
        public Roster(string name, List<Student> students)
        {
            this.name = name;
            this.students = students;
        }

        //Methods
        /// <summary>
        /// A method for programmers to add a Student object to the students list of the roster
        /// Only adds if there is no other student with the same name
        /// </summary>
        /// <param name="s"></param>
        public bool AddStudent(Student s)
        {
            //Searches through list of students
            foreach ( Student student in students)
            {
                //If 2 students share a name, abort the function so the new student isnt added
                if (s.FullName == student.FullName)
                {
                    SmartConsole.PrintError("There is already a student with that name in the roster!");
                    return false;
                }
            }
            //Add a new student and return feedback that the student was added
            students.Add(s);
            SmartConsole.PrintSuccess($"{s.FullName} was added to the {name}");
            return true;
        }

        public Student AddStudent()
        {
            //creates a new student based on user input via the Smart Console
            Student newStudent = new Student(
                SmartConsole.PromptForInput("What is the student's name?"),
                SmartConsole.PromptForInput("What is the student's major?"),
                SmartConsole.PromptForInt("What is the student's year level?", 1, 99));
            if (AddStudent(newStudent))
            {
                return newStudent;
            }
            return null;
        }
    }
}

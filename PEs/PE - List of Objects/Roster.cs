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
            StreamReader input;
            this.name = name.Trim();
            students = new List<Student> { };

            if(File.Exists($@"..\..\..\..\..\..\{name}.txt"))
            {
                try
                {
                    input = new StreamReader($@"..\..\..\..\..\..\{name}.txt");
                    string line;
                    string[] studentInfo;
                    while ((line = input.ReadLine()) != null)
                    {
                        studentInfo = line.Split(",");
                        students.Add(new Student(studentInfo[0], studentInfo[1], int.Parse(studentInfo[2])));
                    }
                    input.Close();
                }
                catch (Exception)
                {

                }
            }
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

        /// <summary>
        /// Creates a new student via user info
        /// then checks that there is no student with a matching name already in the roster
        /// </summary>
        /// <returns>returns the new student created</returns>
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

        /// <summary>
        /// Writes a rosters name and no. of students, along with listing each s.ToString info
        /// </summary>
        public void DisplayRosters()
        {
            Console.WriteLine($"{name} has {students.Count} students: ");
            //Loops through entire roster
            foreach(Student s in students)
            {
                Console.WriteLine(s.ToString());
            }
        }

        //FILE IO PE SPECIFIC METHODS

        /// <summary>
        /// uses roster name as filename, then writes students to the file
        /// </summary>
        public void Save()
        {
            StreamWriter output;

            //Attempt to open file
            try
            {
                output = new StreamWriter($@"..\..\..\..\..\..\{name}.txt");

                foreach(Student s in students)
                {
                    output.WriteLine($"{s.FullName},{s.Major},{s.Year}");
                }

                SmartConsole.PrintSuccess($"Roster saved!");
                output.Close();
            }
            //write this message if an exception is called.
            catch(Exception e)
            {
                SmartConsole.PrintError($"An error occured when attempting to save the rosters");
            }
        }

        /// <summary>
        /// Create a freshman Roster object and adds any existing 1st year students to it
        /// </summary>
        /// <returns>A reference to the freshmanRoster object</returns>
        public Roster GetFreshmanRoster()
        {
            Roster freshmanRoster = new Roster("Freshman");
            if(students.Count > 0)
            {
                //Searches through list of students
                foreach (Student student in students)
                {
                    //If a student is a first year, add them to Freshman Rostr
                    if (student.Year == 1)
                    {
                        freshmanRoster.Students.Add(student);
                    }
                }
            }
            return freshmanRoster;
        }
    }
}

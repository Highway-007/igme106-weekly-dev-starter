using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___List_of_Objects
{
    internal class Student
    {
        //Fields
        private string fullName;
        private string major;
        private int year;

        //Properties
        /// <summary>
        /// A get only property for the private string variable, fullName
        /// </summary>
        public string FullName
        {
            get { return fullName; }
        }

        /// <summary>
        /// A get and set property for the private string variable, major
        /// </summary>
        public string Major
        {
            get { return major; }
            set {  major = (string) value; }
        }

        /// <summary>
        /// A get only property for the private integer variable, year
        /// </summary>
        public int Year
        {
            get { return year; }
        }

        //Constructor
        /// <summary>
        /// Initialize the fullName, major, and year values of a student using inputted values
        /// </summary>
        /// <param name="fullName">Full name of the student</param>
        /// <param name="major">Student's major</param>
        /// <param name="year">Student's year/level of education</param>
        public Student(string fullName, string major, int year)
        {
            this.fullName = fullName;
            this.major = major;
            this.year = year;
        }
    }
}

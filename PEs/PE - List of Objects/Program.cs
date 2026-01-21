namespace PE___List_of_Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Roster freshmanRoster = new Roster("Freshman");
            Roster allRoster = new Roster("All Students");
            int userInput = 0;

            allRoster.Save();

            do
            {
                userInput = SmartConsole.Prompt("Choose 1 of the following options: " +
                    "\n1 - Add a student" +
                    "\n2 - Change major for students" +
                    "\n3 - Print the rosters" +
                    "\n4 - Quit" +
                    "\n>", 1, 4);
                switch (userInput)
                {
                    case 1:
                        Student tempStudent = allRoster.AddStudent();
                        if (tempStudent.Year == 1 && allRoster.SearchByName(tempStudent.FullName) != null)
                        {
                            freshmanRoster.AddStudent(tempStudent);
                        }
                        break;

                    case 2:
                        string searchname = SmartConsole.Prompt("Whose major would you like to change?");
                        Student searchStudent = allRoster.SearchByName(searchname);
                        if (searchStudent != null)
                        {
                            allRoster.SearchByName(searchname).Major = SmartConsole.Prompt($"Found student: {allRoster.Students.Last().ToString()}" +
                                "\nWhat is their new major? ");

                        }
                        else
                        {
                            SmartConsole.PrintError($"{searchname} not found.");
                        }
                        break;

                    case 3:
                        allRoster.DisplayRosters();
                        freshmanRoster.DisplayRosters();
                        break;

                    case 4:
                        Console.WriteLine("Goodbye!");
                        break;

                }
            } while (userInput != 4);
        }
    }
}

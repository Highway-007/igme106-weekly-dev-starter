namespace PE_DictionariesVsLists
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates a new file reader, which loads a file of words
            // into both a list and a dictionary
            WordLoader reader = new WordLoader();

            // Get the two data structures needed for the exercise
            List<String> wordList = reader.WordList;
            Dictionary<String, bool> wordDictionary = reader.WordDictionary;

            // *********************
            // TODO: Put your code between here...
            string userInput = SmartConsole.Prompt("Do you want to search the [D]ictionary or [L]ist?");


            switch (userInput.Trim().ToUpper())
            {
                case "L":
                    foreach(string word in wordList)
                    {
                        if(wordList.Contains(word + word))
                        {
                            Console.WriteLine(word + word);
                        }
                    }
                    break;

                case "D":
                    //This method is visibly much faster
                    foreach(string word in wordList)
                    {
                        if(wordDictionary.ContainsKey(word + word))
                        {
                            Console.WriteLine(word + word);
                            wordDictionary[word + word] = true;
                        }
                    }

                    while(userInput != "QUIT")
                    {
                        userInput = SmartConsole.Prompt("Which word do you want to check (or enter QUIT)? ");
                        try
                        {
                            if (wordDictionary[userInput] == true)
                            {
                                Console.WriteLine($"{userInput} IS a double word");
                            }
                            else if (userInput != "QUIT")
                            {
                                Console.WriteLine($"{userInput} is NOT a double word");
                            }
                        }
                        catch(KeyNotFoundException e)
                        {
                            SmartConsole.PrintError("That word is not in the list");
                        }
                    }
                    break;

                default:
                    SmartConsole.PrintWarning("Command not recognized");
                    break;
            }

            // ...and here.
            // *********************
        }
    }
}

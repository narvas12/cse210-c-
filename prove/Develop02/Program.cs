// Exceeded the requirements byhandling errors using try catch method, and also saving the file names using an industry convention of appending the date and time to the file name 
using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime DateTime { get; set; }

    public JournalEntry(string prompt, string response, DateTime dateTime)
    {
        Prompt = prompt;
        Response = response;
        DateTime = dateTime;
    }
}

class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(string prompt, string response, DateTime dateTime)
    {
        JournalEntry entry = new JournalEntry(prompt, response, dateTime);
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.DateTime}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                outputFile.WriteLine($"{entry.DateTime.ToString("yyyy-MM-dd HH:mm:ss")},{entry.Prompt},{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved to file successfully!");
    }

    public void LoadFromFile(string fileName)
    {
        entries.Clear();

        try
        {
            string[] lines = File.ReadAllLines(fileName);

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3 && DateTime.TryParse(parts[0], out DateTime dateTime))
                {
                    entries.Add(new JournalEntry(parts[1], parts[2], dateTime));
                }
            }

            Console.WriteLine("Journal loaded from file successfully!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Creating a new journal.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Writing a new entry...");
                    string prompt = GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(prompt, response, DateTime.Now);
                    break;

                case "2":
                    Console.WriteLine("Displaying the journal...\n");
                    journal.DisplayEntries();
                    break;

                case "3":
                    string saveFileName = $"Journal_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";
                    journal.SaveToFile(saveFileName);
                    break;

                case "4":
                    Console.Write("Enter the file name to load the journal: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;

                case "5":
                    Console.WriteLine("Exiting the program.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }

    static string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
            // Add your own prompts here
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}




// using System;
// using System.Collections.Generic;
// using System.IO;

// // Class representing a journal entry
// class JournalEntry
// {
//     public string Prompt { get; set; }
//     public string Response { get; set; }
//     public string Date { get; set; }

//     public JournalEntry(string prompt, string response, string date)
//     {
//         Prompt = prompt;
//         Response = response;
//         Date = date;
//     }
// }

// // Class representing a journal
// class Journal
// {
//     private List<JournalEntry> entries;

//     public Journal()
//     {
//         entries = new List<JournalEntry>();
//     }

//     public void AddEntry(string prompt, string response, string date)
//     {
//         JournalEntry entry = new JournalEntry(prompt, response, date);
//         entries.Add(entry);
//     }

//     public void DisplayEntries()
//     {
//         foreach (var entry in entries)
//         {
//             Console.WriteLine($"Date: {entry.Date}");
//             Console.WriteLine($"Prompt: {entry.Prompt}");
//             Console.WriteLine($"Response: {entry.Response}\n");
//         }
//     }

//     public void SaveToFile(string fileName)
//     {
//         using (StreamWriter outputFile = new StreamWriter(fileName))
//         {
//             foreach (var entry in entries)
//             {
//                 outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
//             }
//         }
//         Console.WriteLine("Journal saved to file successfully!");
//     }

//     public void LoadFromFile(string fileName)
//     {
//         entries.Clear(); // Clear existing entries before loading from file

//         try
//         {
//             string[] lines = File.ReadAllLines(fileName);

//             foreach (var line in lines)
//             {
//                 string[] parts = line.Split(',');
//                 if (parts.Length == 3)
//                 {
//                     entries.Add(new JournalEntry(parts[1], parts[2], parts[0]));
//                 }
//             }

//             Console.WriteLine("Journal loaded from file successfully!");
//         }
//         catch (FileNotFoundException)
//         {
//             Console.WriteLine("File not found. Creating a new journal.");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Error: {ex.Message}");
//         }
//     }
// }

// // Main Program class
// class Program
// {
//     static void Main()
//     {
//         Journal journal = new Journal();

//         while (true)
//         {
//             Console.WriteLine("1. Write a new entry");
//             Console.WriteLine("2. Display the journal");
//             Console.WriteLine("3. Save the journal to a file");
//             Console.WriteLine("4. Load the journal from a file");
//             Console.WriteLine("5. Exit");

//             Console.Write("Enter your choice (1-5): ");
//             string choice = Console.ReadLine();

//             switch (choice)
//             {
//                 case "1":
//                     Console.WriteLine("Writing a new entry...");
//                     string prompt = GetRandomPrompt(); // Assuming you have a method to get a random prompt
//                     Console.WriteLine($"Prompt: {prompt}");
//                     Console.Write("Your response: ");
//                     string response = Console.ReadLine();
//                     journal.AddEntry(prompt, response, DateTime.Now.ToShortDateString());
//                     break;

//                 case "2":
//                     Console.WriteLine("Displaying the journal...\n");
//                     journal.DisplayEntries();
//                     break;

//                 case "3":
//                     Console.Write("Enter the file name to save the journal: ");
//                     string saveFileName = Console.ReadLine();
//                     journal.SaveToFile(saveFileName);
//                     break;

//                 case "4":
//                     Console.Write("Enter the file name to load the journal: ");
//                     string loadFileName = Console.ReadLine();
//                     journal.LoadFromFile(loadFileName);
//                     break;

//                 case "5":
//                     Console.WriteLine("Exiting the program.");
//                     Environment.Exit(0);
//                     break;

//                 default:
//                     Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
//                     break;
//             }
//         }
//     }

//     // Additional helper method to generate a random prompt
//     static string GetRandomPrompt()
//     {
//         List<string> prompts = new List<string>
//         {
//             "Who was the most interesting person I interacted with today?",
//             "What was the best part of my day?",
//             "How did I see the hand of the Lord in my life today?",
//             "What was the strongest emotion I felt today?",
//             "If I had one thing I could do over today, what would it be?"
//             // Add your own prompts here
//         };

//         Random random = new Random();
//         int index = random.Next(prompts.Count);
//         return prompts[index];
//     }
// }

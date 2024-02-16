
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime;

class Ex5
{
    static int Main()
    {
        string str, word;
        Console.Write("Insert F or S for change mode (F - Path, S - String)\n");
        char mode = Console.ReadKey().KeyChar;
        Console.WriteLine();
        
        switch (mode)
        {
            case 'F':
                Console.Write("Insert filepath:\n");
                string path = Console.ReadLine()!;

                if (!File.Exists(path))
                {
                    Console.Write("File doesn't exist\n");
                    return -1;
                }

                str = File.ReadAllText(path!);
                break;

            case 'S':
                Console.Write("Insert string:\n");
                str = Console.ReadLine()!;
                break;

            default:
                Console.Write("Incorrect mode");
                return 1;
        }

        if (str.Length < 1)
        {
            Console.Write("String is empty\n");
            return -1;
        }


        

        Console.Write("Insert a, b, c, d or e for change action\n");
        char action = Console.ReadKey().KeyChar;
        Console.Write("\n");


        try
        {
            switch (action)
            { 
                case 'a':
                    Console.WriteLine(flagAMethod(str));
                    break;


                case 'b':
                    Console.WriteLine(flagBMethod(str));
                    break;


                case 'c':
                    Console.Write("Insert word:\n");
                    word = Console.ReadLine()!;
                    Console.WriteLine(flagCMethod(str, word));
                    break;


                case 'd':
                    Console.Write("Insert word:\n");
                    word = Console.ReadLine()!;
                    Console.WriteLine(flagDMethod(str, word));
                    break;


                case 'e':
                    Console.Write("Insert number:\n");
                    int number;
                    string numbCons = Console.ReadLine()!;

                    if (!int.TryParse(numbCons, out number))
                    {
                        Console.WriteLine("Incorrect Number");
                        return 3;
                    }
                    try
                    {
                        Console.WriteLine(flagEMethod(str, number));
                    }
                    catch(ArgumentException)
                    {
                        Console.WriteLine("Error");
                    }
                    break;

                default:
                    Console.Write("Incorrect action");
                    return 4;
            }
        }
        catch(ArgumentException e)
        {
            Console.WriteLine(e.Message);
            return 5;
        }


        Console.ReadLine();
        return 0;
    }


    static string flagAMethod(string data)
    {
        if (data.Length < 1)
        {
            Console.Write("String is empty\n");
            throw new ArgumentException("String is empty");
        }

        string result = "";
        char[] detChars = {' ', '\t', '\n',',' };
        string[] words = data.Split(detChars);
        Array.Sort(words);

        foreach(string word in words)
        {
            result += word[word.Length - 1];
        }

        return result;
    }

    static string flagBMethod(string data)
    {
        if (data.Length < 1)
        {
            Console.Write("String is empty\n");
            throw new ArgumentException("String is empty");
        }


        string result = "";
        char[] detChars = { ' ', '\t', '\n', ',' };
        string[] words = data.Split(detChars);
        
        foreach (string word in words)
        {
            string modifyWord = word;
            char[] symb = word.ToCharArray();
            symb[0] = char.ToUpper(symb[0]);
            symb[symb.Length-1] = char.ToLower(symb[symb.Length - 1]);

            result += new string(symb) + " ";
        }

        return result;
    }

    static int flagCMethod(string data, string findWord)
    {
        if (data.Length < 1)
        {
            Console.Write("String is empty\n");
            throw new ArgumentException("String is empty");
        }
        if (findWord.Length < 1)
        {
            Console.Write("Word is empty\n");
            throw new ArgumentException("Word is empty");
        }


        int matches = 0;
        char[] detChars = { ' ', '\t', '\n', ',' };
        string[] words = data.Split(detChars);

        foreach (string word in words)
        {
            if (findWord == word) matches++;
        }

        return matches;

    }

    static string flagDMethod(string data, string word)
    {
        if (data.Length < 1)
        {
            Console.Write("String is empty\n");
            throw new ArgumentException("String is empty");
        }


        char[] detChars = { ' ', '\t', '\n', ',' };
        string[] words = data.Split(detChars);
        if (words.Length < 2)
        {
            Console.Write("Number of words lower then 2\n");
            throw new ArgumentException("Number of words lower then 2");
        }

        words[words.Length - 2] = word;

        return string.Join(" ", words);

    }

    static string flagEMethod(string data, int number)
    {
        if (data.Length < 1)
        {
            Console.Write("String is empty\n");
            throw new ArgumentException("String is empty");
        }


        char[] detChars = { ' ', '\t', '\n', ',' };
        string[] words = data.Split(detChars);
        int counter = 0;

        foreach(string word in words)
        {
            
            if (char.IsUpper(word[0])) counter++;
            if (counter == number) return word;
        }

        throw new ArgumentException("Error");
    }



}
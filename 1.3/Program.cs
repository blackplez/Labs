class Ex3
{
    static int Main(string[] args)
    {
        if (args.Length < 1 || args[0] == "-c")
        {
            char readln;
            int sum = 0, len = 0;
            Console.Write("Input char symbol ('S' to exit)");
            Console.WriteLine();

            while ((readln = Console.ReadKey().KeyChar) != 'S')
            {
                sum += readln;
                len++;
                Console.Write("Input char symbol ('S' to exit)");
                Console.WriteLine();
            };
            sum /= len;

            Console.WriteLine("Your result: {0}", sum);
        }
        else if (args[0] == "-f" && args.Length==2)
        {

            if (!File.Exists(args[1]))
            {
                Console.WriteLine("File doesn't exist");
                return -1;
            }

            string data = File.ReadAllText(args[1]);
            if (data.Length<1)
            {
                Console.WriteLine("File is empty");
                return -1;
            }
            string[] values = data.Split(' ');


            int sum = 0;
            foreach (string value in values)  
            {
                sum += value[0];
            }
            sum /= values.Length;

            Console.WriteLine("Your result: {0}", sum);
        }
        else
        {
            Console.WriteLine("Incorrect flag");
            return 1;
        }


        Console.ReadLine();
        return 0;
    }
}


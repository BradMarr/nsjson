using System.Diagnostics;

string? input = null;
string[]? inputArray = {"",""};
string TerminalURL(string caption, string url) => $"\u001B]8;;{url}\a{caption}\u001B]8;;\a";

Console.WriteLine("      ___          ___           ___       ___          ___          ___     \n" +
                             "     /\\__\\        /\\  \\         /\\  \\     /\\  \\        /\\  \\        /\\__\\    \n" +
                             "    /::|  |      /::\\  \\        \\:\\  \\   /::\\  \\      /::\\  \\      /::|  |   \n" +
                             "   /:|:|  |     /:/\\ \\  \\   ___ /::\\__\\ /:/\\ \\  \\    /:/\\:\\  \\    /:|:|  |   \n" +
                             "  /:/|:|  |__  _\\:\\~\\ \\  \\ /\\  /:/\\/__/_\\:\\~\\ \\  \\  /:/  \\:\\  \\  /:/|:|  |__ \n" +
                             " /:/ |:| /\\__\\/\\ \\:\\ \\ \\__\\\\:\\/:/  /  /\\ \\:\\ \\ \\__\\/:/__/ \\:\\__\\/:/ |:| /\\__\\ \n" +
                             " \\/__|:|/:/  /\\:\\ \\:\\ \\/__/ \\::/  /   \\:\\ \\:\\ \\/__/\\:\\  \\ /:/  /\\/__|:|/:/  /\n" +
                             "     |:/:/  /  \\:\\ \\:\\__\\    \\/__/     \\:\\ \\:\\__\\   \\:\\  /:/  /     |:/:/  / \n" +
                             "     |::/  /    \\:\\/:/  /               \\:\\/:/  /    \\:\\/:/  /      |::/  /  \n" +
                             "     /:/  /      \\::/  /                 \\::/  /      \\::/  /       /:/  /   \n" +
                             "     \\/__/        \\/__/                   \\/__/        \\/__/        \\/__/    \n");

try
{
    while (true)
    {
        if (inputArray[0] == "compile" && inputArray.Length > 1)
        {
            string[] linesArray = File.ReadAllLines(@inputArray[1]);

            if (File.Exists(inputArray[1] + ".json"))
            {
                File.Delete(inputArray[1] + ".json");
            }
            var outFile = File.CreateText(inputArray[1] + ".json");

            foreach (string line in linesArray) 
            { 
                string[] lineArray = line.Split("//"); 
                outFile.WriteLine(lineArray[0]); 
            }
            outFile.Close();



            Console.Write(" $");
        }


        else if (input == "docs")
        {
            try
            {
                Process.Start(new ProcessStartInfo { FileName = @"https://docs.blubrad.com/nsjson", UseShellExecute = true });
            }
            catch
            {
                Console.WriteLine(TerminalURL("https://docs.blubrad.com/nsjson", "https://docs.blubrad.com/nsjson"));
            }
            Console.Write(" $");
        }
        else             //help
        {
            Console.WriteLine(" ┌─────────┬──────────────┬──────────────────────────────────────┐\n" +
                              " │ command │ arguments    │ description                          │\n" +
                              " ├─────────┼──────────────┼──────────────────────────────────────┤\n" +
                              " │ help    │ -            │ shows this message                   │\n" +
                              " │ docs    │ -            │ displays documentation page          │\n" +
                              " │ compile │ <path>       │ compiles the file the path points to │\n" +
                              " └─────────┴──────────────┴──────────────────────────────────────┘");
            Console.Write(" $");
        }

        input = Console.ReadLine();
        inputArray = input.Split(" ");
    } 
}
catch (Exception e)
{
    Console.WriteLine(e);
}

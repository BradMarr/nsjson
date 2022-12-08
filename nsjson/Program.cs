using System.Diagnostics;

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

void runtime()
{
    Console.ForegroundColor = ConsoleColor.White;
    string? input = null;
    string[]? inputArray = {""};

    while (true)
    {
        if (inputArray[0] == "compile")
        {
            string[] linesArray = File.ReadAllLines(@inputArray[1]);

            if (File.Exists(inputArray[1] + ".json"))
            {
                File.Delete(inputArray[1] + ".json");
            }
            var outFile = File.CreateText(inputArray[1] + ".json");

            int linesIndex = 0;
            foreach (string line in linesArray)
            {
                string finalLine;
                char[] letterArray = line.ToCharArray();
                int letterIndex = 0;
                foreach (char letter in letterArray)
                {
                    if (letterIndex < letterArray.Length-1)
                    {
                        if (letterArray[letterIndex] == ',' && letterArray[letterIndex + 1] == '}' || letterArray[letterIndex] == ',' && letterArray[letterIndex + 1] == ']')
                        {
                            letterArray[letterIndex] = ' ';
                        };
                    }
                    else
                    {
                        if (letterArray[letterIndex] == ',' && linesArray[linesIndex+1].ToCharArray()[0] == '}' || letterArray[letterIndex] == ',' && linesArray[linesIndex+1].ToCharArray()[0] == ']')
                        {
                            letterArray[letterIndex] = ' ';
                        }
                    }

                    letterIndex++;
                };

                finalLine = string.Concat(letterArray);
                linesArray[linesIndex] = finalLine;
                string[] lineArray = linesArray[linesIndex].Split("//note//");

                outFile.WriteLine(lineArray[0]);
                linesIndex++;
            };
            outFile.Close();
            Console.WriteLine(" compiled.");
            Console.Write(" $ ");
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
            Console.Write(" $ ");
        }
        else             //help
        {
            Console.WriteLine(" ┌─────────┬───────────────────┬──────────────────────────────────────┐\n" +
                              " │ command │ arguments         │ description                          │\n" +
                              " ├─────────┼───────────────────┼──────────────────────────────────────┤\n" +
                              " │ help    │ -                 │ shows this message                   │\n" +
                              " │ docs    │ -                 │ displays documentation page          │\n" +
                              " │ compile │ <path>            │ READ DOCS FIRST!!                    │\n" +
                              " └─────────┴───────────────────┴──────────────────────────────────────┘");
            Console.Write(" $ ");
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        input = Console.ReadLine();
        inputArray = input?.Split(" ");
    }
}

try
{
    runtime();
}
catch (Exception e)
{
    Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine(e.ToString(), Console.ForegroundColor);
    runtime();
}

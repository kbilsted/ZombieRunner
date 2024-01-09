Console.CursorVisible = false;

Title();

(int left, int top) person = (3, 2);

while (true)
{
    Console.Clear();
    Console.SetCursorPosition(person.left, person.top);

    Console.Write('p');

    var tastatur = Console.ReadKey();

    if (tastatur.KeyChar == 'w')
    {
        person.top = person.top - 1;
    }

    if (tastatur.KeyChar == 's')
    {
        person.top = person.top + 1;
    }

    if (tastatur.KeyChar == 'a')
    {
        person.left = person.left - 1;
    }

}


void Title()
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    var logo = @"

▒███████▒ ▒█████   ███▄ ▄███▓ ▄▄▄▄    ██▓▓█████     ██▀███   █    ██  ███▄    █  ███▄    █ ▓█████  ██▀███  
▒ ▒ ▒ ▄▀░▒██▒  ██▒▓██▒▀█▀ ██▒▓█████▄ ▓██▒▓█   ▀    ▓██ ▒ ██▒ ██  ▓██▒ ██ ▀█   █  ██ ▀█   █ ▓█   ▀ ▓██ ▒ ██▒
░ ▒ ▄▀▒░ ▒██░  ██▒▓██    ▓██░▒██▒ ▄██▒██▒▒███      ▓██ ░▄█ ▒▓██  ▒██░▓██  ▀█ ██▒▓██  ▀█ ██▒▒███   ▓██ ░▄█ ▒
  ▄▀▒   ░▒██   ██░▒██    ▒██ ▒██░█▀  ░██░▒▓█  ▄    ▒██▀▀█▄  ▓▓█  ░██░▓██▒  ▐▌██▒▓██▒  ▐▌██▒▒▓█  ▄ ▒██▀▀█▄  
▒███████▒░ ████▓▒░▒██▒   ░██▒░▓█  ▀█▓░██░░▒████▒   ░██▓ ▒██▒▒▒█████▓ ▒██░   ▓██░▒██░   ▓██░░▒████▒░██▓ ▒██▒
░▒▒ ▓░▒░▒░ ▒░▒░▒░ ░ ▒░   ░  ░░▒▓███▀▒░▓  ░░ ▒░ ░   ░ ▒▓ ░▒▓░░▒▓▒ ▒ ▒ ░ ▒░   ▒ ▒ ░ ▒░   ▒ ▒ ░░ ▒░ ░░ ▒▓ ░▒▓░
░░▒ ▒ ░ ▒  ░ ▒ ▒░ ░  ░      ░▒░▒   ░  ▒ ░ ░ ░  ░     ░▒ ░ ▒░░░▒░ ░ ░ ░ ░░   ░ ▒░░ ░░   ░ ▒░ ░ ░  ░  ░▒ ░ ▒░
░ ░ ░ ░ ░░ ░ ░ ▒  ░      ░    ░    ░  ▒ ░   ░        ░░   ░  ░░░ ░ ░    ░   ░ ░    ░   ░ ░    ░     ░░   ░ 
  ░ ░        ░ ░         ░    ░       ░     ░  ░      ░        ░              ░          ░    ░  ░   ░     
░                                  ░                                                                       




                                          PRESS ANY KEY
";
    //Console.WriteLine(logo);
    //    FillLogo(logo);
    
    DrawGradual(logo);

    Console.ReadKey();

    static void DrawGradual(string logo)
    {
        var split = logo.Split('\n');
        Enumerable.Repeat(0, split.Length)
        .ToList()
        .ForEach(x => Console.WriteLine());

        var curs = Console.GetCursorPosition();
        curs.Top -= split.Length;

        foreach (char[] drawChars in new char[][] { ['█', '▄', '▀'], ['▓'], ['▒'], ['░'] })
        {
            var cursor = curs;
            Console.SetCursorPosition(cursor.Left, cursor.Top);
            foreach (var line in split)
            {
                bool drawn = false;
                foreach (var c in line)
                {
                    if (drawChars.Any(x=>x==c))
                    {
                        Console.SetCursorPosition(cursor.Left, cursor.Top);
                        Console.Write(c);
                        drawn = true;
                    }
                    cursor.Left += 1;
                }
                //if(drawn)
                //    Thread.Sleep(40);
                cursor.Left = 0;
                cursor.Top += 1;
            }
            Thread.Sleep(400);
        }
    }

    static void FillLogo(string logo)
    {
        var cursor = Console.GetCursorPosition();
        cursor.Top -= logo.Split('\n').Length;
        Console.SetCursorPosition(cursor.Left, cursor.Top);
        Console.ForegroundColor = ConsoleColor.Red;

        foreach (var line in logo.Split('\n'))
        {
            foreach (var c in line)
            {
                if (c == '█')
                {
                    Console.SetCursorPosition(cursor.Left, cursor.Top);
                    Console.Write('█');
                }
                cursor.Left += 1;
            }
            Thread.Sleep(155);
            cursor.Left = 0;
            cursor.Top += 1;
        }
    }
}
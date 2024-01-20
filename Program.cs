using Microsoft.VisualBasic;

Console.CursorVisible = false;

Console.OutputEncoding = System.Text.Encoding.UTF8;



//for (var i = 0; i <= 65000; i++)
//{
//    Console.Write(Strings.ChrW(i));
//    if (i % 77 == 0)
//    { // break every 50 chars
//        Console.WriteLine();
//    }
//}
//Console.ReadKey();

Person person = new Person(14, 26);
Zombie[] zombies = { Zombie.CreateRnd(), Zombie.CreateRnd(), Zombie.CreateRnd(), Zombie.CreateRnd(), Zombie.CreateRnd(), };
Mine[] mines = { new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()) };


while (true)
{
    //TitleScreen();

    Game();
}

void Game()
{
    person = new Person(14, 26);
     zombies = new[]{ Zombie.CreateRnd(), Zombie.CreateRnd(), Zombie.CreateRnd(), Zombie.CreateRnd(), Zombie.CreateRnd(), };
     mines = new Mine[] { new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()), new(Rnd()) };

    while (true)
    {
        PrintScreen();

        var tastatur = Console.ReadKey(true);

        if (tastatur.KeyChar == 'w')
        {
            person.Top = person.Top - 1;
        }

        if (tastatur.KeyChar == 's')
        {
            person.Top = person.Top + 1;
        }

        if (tastatur.KeyChar == 'a')
        {
            person.Left = person.Left - 1;
        }

        if (tastatur.KeyChar == 'd')
        {
            person.Left = person.Left + 1;
        }

        if (Sprite.Occupy(zombies, person))
        {
            GameOver();
            return;
        }

        foreach (var zombie in zombies)
        {
            PrintScreen();

            if (zombie.Top > person.Top && !Sprite.Occupy(zombies, new Sprite(zombie.Top - 1, zombie.Left)))
            {
                zombie.Top = zombie.Top - 1;
            }
            else if (zombie.Top < person.Top && !zombies.Any(x => x.Top == zombie.Top + 1 && x.Left == zombie.Left))
            {
                zombie.Top = zombie.Top + 1;
            }
            else if (zombie.Left > person.Left && !zombies.Any(x => x.Top == zombie.Top && x.Left == zombie.Left - 1))
            {
                zombie.Left = zombie.Left - 1;
            }
            else if (zombie.Left < person.Left && !zombies.Any(x => x.Top == zombie.Top && x.Left == zombie.Left + 1))
            {
                zombie.Left = zombie.Left + 1;
            }
            else
            {
                zombie.Left = zombie.Left + RoleDice();
                zombie.Top = zombie.Top + RoleDice();
            }

            if (zombie.Occupy(person))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(zombie.Left, zombie.Top);
                Console.Write('z');
                Thread.Sleep(300);

                GameOver();
                return;
            }

            Thread.Sleep(150);
        }

    }

    int RoleDice()
    {
        return Random.Shared.Next(-1, 1);
    }
}

void TitleScreen()
{
    Console.Clear();

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
";
    //Console.WriteLine(logo);
    //    FillLogo(logo);

    DrawGradual(logo);

    Console.WriteLine(@"
                              V1.0 by Zak McCracken & Zane McCracken
                                      Copyright 2024


                                       PRESS ANY KEY
");
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
                    if (drawChars.Any(x => x == c))
                    {
                        Console.SetCursorPosition(cursor.Left, cursor.Top);
                        Console.Write(c);
                        drawn = true;
                    }
                    cursor.Left += 1;
                }
                cursor.Left = 0;
                cursor.Top += 1;
            }
            Thread.Sleep(300);
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


void GameOver()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.SetCursorPosition(0,0);
    Console.WriteLine(@"





  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  
 ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
 ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     
                                                     ░                   
                                                                          

                                          PRESS ANY KEY
");

    Console.ReadKey();
}



void PrintScreen()
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.SetCursorPosition(person.Left, person.Top);
    Console.Write('p');

    Console.ForegroundColor = ConsoleColor.Green;
    foreach (var zombie in zombies)
    {
        Console.SetCursorPosition(zombie.Left, zombie.Top);
        Console.Write('z');
    }

    Console.ForegroundColor = ConsoleColor.DarkGray;
    foreach (var mine in mines)
    {
        Console.SetCursorPosition(mine.Left, mine.Top);
        Console.Write('░');
    }
}

(int top, int left) Rnd() => (Random.Shared.Next(24), Random.Shared.Next(79));

class Sprite(int Top, int Left)
{
    public int Top { get; set; } = Top;
    public int Left { get; set; } = Left;

    public Sprite((int top, int left) coord) : this(coord.top, coord.left)
    {
    }

    public bool Occupy(Sprite s)
      => Top == s.Top && Left == s.Left;

    public static bool Occupy(IEnumerable<Sprite> ss, Sprite s)
      => ss.Any(x => x.Top == s.Top && x.Left == s.Left);
}

class Zombie(int Top, int Left) : Sprite(Top, Left)
{
    public static bool AnyZombieOnField(Zombie[] zombies, int top, int left)
        => zombies.Any(x => x.Top == top && x.Left == left);

    public static Zombie CreateRnd()
        => new Zombie(Random.Shared.Next(0, 19), Random.Shared.Next(0, 79));
}

class Mine((int top, int left) coord) : Sprite (coord);

class Person(int Top, int Left) : Sprite(Top, Left);

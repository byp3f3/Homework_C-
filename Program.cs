using System.Runtime.ExceptionServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Пианино");
        Console.WriteLine("F1 - первая октава, F2 - вторая октава, esc - выход");
        Console.WriteLine("A - Q, A# - W, B - E, C - A, C# - S, D - D");
        Console.WriteLine("D# - I, E - O, F# - P, F - J, G# - K, G - L");
        static int[] OctChoice(int octave)
        {
            int[] FirstOctave = new int[12] { 440, 466, 494, 262, 277, 294, 311, 330, 370, 349, 392, 415};
            int[] SecondOctave = new int[12] { 880, 932, 988, 523, 554, 587, 622, 659, 740, 698, 784, 830  };
            if (octave == 1)
            { return FirstOctave; }
            else if (octave == 2) 
            {  return SecondOctave; }
            return FirstOctave;
        }
        ConsoleKeyInfo note;
        do
        { note = Console.ReadKey();
        int[] ChosenOct = OctChoice(1);
        switch (note.Key)
        {
            
            case ConsoleKey.Z:
                ChosenOct = OctChoice(1);
                break;
             case ConsoleKey.X:
                ChosenOct = OctChoice(2);
                break;
            case ConsoleKey.Q:
                Console.Beep(ChosenOct[0], 200);
                break;
            case ConsoleKey.W:
                Console.Beep(ChosenOct[1], 200);
                break;
            case ConsoleKey.E:
                Console.Beep(ChosenOct[2], 200);
                break;
            case ConsoleKey.A:
                Console.Beep(ChosenOct[3], 200);
                break;
            case ConsoleKey.S:
                Console.Beep(ChosenOct[4], 200);
                break;
            case ConsoleKey.D:
                Console.Beep(ChosenOct[5], 200);
                break;
            case ConsoleKey.I:
                Console.Beep(ChosenOct[6], 200);
                break;
            case ConsoleKey.O:
                Console.Beep(ChosenOct[7], 200);
                break;
            case ConsoleKey.P:
                Console.Beep(ChosenOct[8], 200);
                break;
            case ConsoleKey.J:
                Console.Beep(ChosenOct[9], 200);
                break;
            case ConsoleKey.K:
                Console.Beep(ChosenOct[10], 200);
                break;
            case ConsoleKey.L:
                Console.Beep(ChosenOct[11], 200);
                break;

            }
        } while (note.Key != ConsoleKey.Escape);
    }
}
namespace diary
{
    internal class Program
    {
        static DateTime date = DateTime.Now;
        static int position = 1;
        static int maxPosition = 0;

        static Note task1 = new Note() { Name = "Погулять", Description = "Иногда стоит проветрить голову", NoteDate = "08.12.2023"};
        static Note task2 = new Note() { Name = "Поспать", Description = "Здоровый сон понижает уровень стресса", NoteDate = "08.12.2023" };
        static Note task3 = new Note() { Name = "Полить цветы", Description = "Хоть кто-то в доме должен поддерживать водный баланс", NoteDate = "07.12.2023" };
        static Note task4 = new Note() { Name = "Покормить льва", Description = "Очень важно заботиться о домашних животных", NoteDate = "06.12.2023" };
        static Note task5 = new Note() { Name = "Сходить на пары", Description = "К сожалению, иногда приходится заниматься и таким", NoteDate = "06.12.2023" };
        static List<Note> tasks = new List<Note>();
        static List<Note> selectedTasks = new List<Note>();

        static void DefaultAdd()
        {
            tasks.Add(task1);
            tasks.Add(task2);
            tasks.Add(task3);
            tasks.Add(task4);
            tasks.Add(task5);
        }
        static void Main()
        {
            DefaultAdd();
            NotesMenu();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        ArrowMenu(key.Key);
                        break;

                    case ConsoleKey.DownArrow:
                        ArrowMenu(key.Key);
                        break;

                    case ConsoleKey.LeftArrow:
                        DateChange(-1);
                        break;

                    case ConsoleKey.RightArrow:
                        DateChange(1);
                        break;

                    case ConsoleKey.Enter:
                        if (tasks.Any())
                            ShowDescription(selectedTasks[position - 1]);
                        break;
                }
            } while (key.Key != ConsoleKey.Escape);
        }

        static void NotesMenu()
        {
            Console.Clear();
            Console.WriteLine("Выбрана дата: " + date.ToLongDateString());
            int num = 1;

            foreach (Note note in tasks)
            {
                if (note.NoteDate == date.ToShortDateString())
                {
                    Console.WriteLine("   " + num + ". " + note.Name);
                    selectedTasks.Add(note);
                    maxPosition++;
                    num++;
                }

            }
        }

        static void DateChange(int day)
        {
            date = date.AddDays(day);
            maxPosition = 0;
            position = 1;
            selectedTasks.Clear();
            NotesMenu();
        }

        static void ArrowMenu(ConsoleKey key)
        {   
            if (maxPosition != 0)
            {
                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");

                if (key == ConsoleKey.UpArrow)
                {
                    if (position != 1)
                        position--;
                    else if (position == 1)
                        position = maxPosition;

                }
                else if (key == ConsoleKey.DownArrow)
                    if (position < maxPosition)
                        position++;
                    else if (position == maxPosition)
                        position = 1;

                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
            }
        }

        static void ShowDescription(Note task)
        {
            Console.Clear();
            Console.WriteLine(task.Name);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Описание: " + task.Description);
            Console.WriteLine("Когда: " + task.NoteDate);

            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Enter);
            maxPosition = 0;
            position = 1;
            NotesMenu();
        }

        
    }

}
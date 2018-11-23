using System;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(); //create a board
            //load tasks to board
            board.LoadTasks();

            switch (args[0][1])
            {
                case 'l': board.ShowList(); break;
                case 'a':
                    if (args.Length > 2) board.AddList(string.Join(" ", args, 1, args.GetLength(0) - 1));
                    else throw new ArgumentException("Unable to add: no task provided");
                    break;
                case 'r':
                    if (args.Length >= 2) board.RemoveList(args[1]);
                    else throw new ArgumentException("Unable to remove: no index provided");
                    break;
                case 'c':
                    if (args.Length >= 2) board.CheckList(args[1]);
                    else throw new ArgumentException("Unable to remove: no index provided");
                    break;
                    
                default: board.PrintUsage();
                    break;
            }

            Console.ReadLine();
        }
    }
}


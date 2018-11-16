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
                case 'a': board.AddList(string.Join(" ", args, 1, args.GetLength(0) - 1)); break;
                case 'r': board.RemoveList(args[1]); break;
                case 'c': board.CheckList(args[1]); break;
                default: throw (new ArgumentException(args[0]));
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TODO
{
    class Board
    {
        private List<Task> tasks;
        const string TasksListName = "tasks_list.txt";

        public Board()
        {
            this.tasks = new List<Task>();
        }

        internal void ShowList()
        {
            for(int i=0; i < tasks.Count; i++)
            {
                Console.Write($"{i+1} - [{(tasks[i].IsChecked ? 'x': ' ')}] {tasks[i].Desciption}\n");

            }
        }

        internal void CheckList(string v)
        {
            if (!int.TryParse(v, out var ck_index))
            {
                throw new ArgumentException("Invalid index.");
            }
            try
            {
                tasks[ck_index - 1].IsChecked = true;
                // rewrite whole file?
                modified_tasks();
                ShowList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid index : {e}");
            }

        }

        internal void RemoveList(string v)
        {
            if(!int.TryParse(v, out var rm_index))
            {
                throw new ArgumentException("Invalid index.");
            }

            try
            {
                tasks.RemoveAt(rm_index - 1);
                modified_tasks();
                ShowList(); 
            }
            catch(Exception e)
            {
                Console.WriteLine($"Invalid index : {e}");
            }
        }

        private void modified_tasks()
        {
            using (StreamWriter writer = new StreamWriter(TasksListName, false))
            {
                foreach(Task item in tasks)
                    writer.WriteLine($"{(item.IsChecked ? 'c' : 'n')} {item.Desciption}");
            }
        }

        internal void AddList(string description)
        {   
            Task new_task = new Task(description);
            tasks.Add(new_task);
            ShowList();
            WrtieTofile(new_task);
        }

        private void WrtieTofile(Task new_task)
        {
            using (StreamWriter writer = new StreamWriter(TasksListName,true)) {
                writer.WriteLine($"{(new_task.IsChecked ? 'c' : 'n')} {new_task.Desciption}");
            }
        }

        internal void LoadTasks()
        {
            try
            {
                StreamReader reader = new StreamReader(TasksListName);
                
                while(true)
                {
                    string line = reader.ReadLine();
                    if (line == null) break;

                    bool isChecked = false;
                    if (line[0] == 'c') isChecked = true;
                    else if (line[0] == 'n') isChecked = false;
                    else throw (new ArgumentException("Content Error.")); // if first word not c/n, throw argumentexception

                    tasks.Add(new Task(line.Substring(2), isChecked));
                }
                reader.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No Task Repo Founded: Create a New Repo.");
                FileStream fs = File.Create(TasksListName);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Something is wrong in your Repo.");
            }
        }
    }
}

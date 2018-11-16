using System;
using System.Collections.Generic;
using System.Text;

namespace TODO
{
    class Task
    {
        public string Desciption { get; private set; }
        public bool IsChecked { get; set; }

        public Task(string desciption)
        {
            Desciption = desciption;
            IsChecked = false;
        }

        public Task(string desciption, bool isChecked) : this(desciption)
        {
            IsChecked = isChecked;
        }
    }
}

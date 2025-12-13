using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public class TaskItem
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public bool IsCompleted { get; set; }
        public string DisplayTime => Time.ToString("hh\\:mm");
        public string FormattedDate => Date.ToString("dd MMMM yyyy", new CultureInfo("ru-RU"));
    }
}

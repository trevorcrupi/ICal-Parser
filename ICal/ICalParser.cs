using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICal
{
    public class ICalParser
    {
        private List<Event> contents;

        public List<Event> Contents
        {
            get { return contents; }
        }

        public ICalParser(ICalReader r)
        {
            this.contents = r.getContents();
        }

        public void WriteToConsole()
        {
            this.contents.ForEach(a => Console.WriteLine(a));
        }
    }
}

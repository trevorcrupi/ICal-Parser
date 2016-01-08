using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ICal
{
    public class ICalReader
    {
        private string path;
        private List<Event> list;

        public string File
        {
            get { return path; }
        }

        public ICalReader(string fp)
        {
            path = fp;
            this.list = new List<Event>();
        }

        public List<Event> getContents()
        {
            return this.prepareContents(new FileStream(this.File, FileMode.Open, FileAccess.Read));
        }

        public List<Event> prepareContents(FileStream fs)
        {
            using (StreamReader sr = new StreamReader(fs))
            {
                string ical = sr.ReadToEnd();
                char[] delim = { '\n' };
                string[] lines = ical.Split(delim);
                List<Event> newEvent = new List<Event>();
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("BEGIN:VEVENT"))
                    {
                       Dictionary<string, string> dictionary = this.grabEvent(i, lines);
                       this.setEvent(dictionary);
                    }
                }
                return this.list;
            }
        }

        private List<Event> setEvent(Dictionary<string, string> dictionary)
        {
            Event a = new Event();
            try
            {
                a.created = dictionary["CREATED;VALUE=DATE"];
                a.description = dictionary["DESCRIPTION"];
                a.DTEnd = dictionary["DTEND"];
                a.DTStamp = dictionary["DTSTAMP"];
                a.DTStart = dictionary["DTSTART"];
                a.lastModified = dictionary["LAST-MODIFIED;VALUE=DATE"];
                a.location = dictionary["LOCATION"];
                a.sequence = dictionary["SEQUENCE"];
                a.transp = dictionary["TRANSP"];
                a.uid = dictionary["UID"];
                this.list.Add(a);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return new List<Event>();
            }
            Console.WriteLine(this.list);
            return this.list;
        }

        private Dictionary<string, string> grabEvent(int i, string[] lines)
        {
            var events = new Dictionary<string, string>();
            for(int j = 0; j < 12; j++)
            {
                string current = lines[i + j + 1];
                if (!current.Contains("END:VEVENT"))
                {
                    string key = current.Substring(0, current.IndexOf(':'));
                    int start = current.IndexOf(':') + 1;
                    string value = current.Substring(start);
                    events.Add(key, value);
                }
            }

            return events;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICal
{
    public class Event
    {
        public string created;
        public string description;
        public string DTEnd;
        public string DTStamp;
        public string DTStart;
        public string lastModified;
        public string location;
        public string sequence;
        public string summary;
        public string transp;
        public string uid;
        
        public override string ToString()
        {
            return
            "CREATED: " + this.created + "\n" +
            "DESCRIPTION: " + this.description + "\n" +
            "DTEND: " + this.DTEnd + "\n" +
            "DTSTAMP: " + this.DTStamp + "\n" +
            "DTSTART: " + this.DTStart + "\n" +
            "LAST_MODIFIED: " + this.lastModified + "\n" +
            "LOCATION: " + this.location + "\n" +
            "SEQUENCE: " + this.sequence + "\n" +
            "SUMMARY: " + this.summary + "\n" +
            "TRANSP: " + this.transp + "\n" +
            "UID: " + this.uid + "\n";
        }
    }

} 

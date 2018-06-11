using System;

namespace test2.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public string User { get; set; }
        public string WorkRequest { get; set; }
        public string Department { get; set; }
        public bool Urgent
        { get; set; }
        public bool Pending
        { get; set; }
        public bool InProgress
        { get; set; }
        public bool Closed
        { get; set; }

        public DateTime Created
        {get; set;}
    }
}
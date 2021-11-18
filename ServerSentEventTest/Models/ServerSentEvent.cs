using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSentEventTest.Models
{
    public class ServerSentEvent
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Azure.WebJobs;

namespace Subroutine.Command.Sequencer.Scan
{
    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("queue")] string mesage, TextWriter log)
        {
            log.WriteLine(mesage);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    public class TaskList<T> : List<T> where T: Task
    {
        
    }
}

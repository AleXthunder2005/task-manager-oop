using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    static class mTaskCreator
    {
        private static List<Type> m_taskTypes;

        public static void Initialize(List<Type> taskTypes)
        {
            m_taskTypes = taskTypes;
        }

        public static List<Type> TaskTypes
        {
            get { return m_taskTypes; }
        }
    }
}

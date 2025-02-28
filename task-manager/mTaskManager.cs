using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    static class mTaskManager
    {
        private static TaskList<Task> m_tasks;       //Список задач
        private static List<Type> m_taskTypes;     //Список конкретных классов наследников класса Task

        public static void Initialize() {
            m_taskTypes = LoadTaskTypes();
        }

        private static List<Type> LoadTaskTypes() { 
   
            List<Type> taskTypes = new List<Type>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            var taskClasses = assembly.GetTypes().Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(Task)));
            foreach (var type in taskClasses)
            {
                taskTypes.Add(type);
            }

            return taskTypes;
        }


        //properties
        public static TaskList<Task> Tasks {
            get { return m_tasks; }
            set { m_tasks = value; }
        }

        public static List<Type> TaskTypes
        {
            get { return m_taskTypes; }
        }
    }
}

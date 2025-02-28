using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    static class TaskManagerModel
    {
        private static TaskList<Task> m_tasks;       //Список задач
        private static List<Type> m_taskTypes;     //Список конкретных классов наследников класса Task

        public static void LoadTaskTypes()
        {
            m_taskTypes = new List<Type>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            var taskClasses = assembly.GetTypes().Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(Task)));
            foreach (var type in taskClasses)
            {
                m_taskTypes.Add(type);
            }
        }

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

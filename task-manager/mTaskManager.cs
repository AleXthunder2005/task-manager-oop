﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static task_manager.Settings;

namespace task_manager
{
    static class mTaskManager
    {
        private static TaskList<Task> _tasks = new TaskList<Task>();       //Список задач
        private static List<Type> _taskTypes;     //Список конкретных классов наследников класса Task
        
        public static int SelectedTaskIndex { get; set; } = RESETED_TASK_INDEX;
        public static void Initialize() {
            _taskTypes = LoadTaskTypes();
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
            get { return _tasks; }
            set { _tasks = value; }
        }

        public static List<Type> TaskTypes
        {
            get { return _taskTypes; }
        }
    }
}

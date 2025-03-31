using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    public static class BinaryHandler
    {
        public static byte[] BuildBinary(TaskList<Task> tasks)
        {

            StringBuilder binaryBuilder = new StringBuilder();
            byte[] result = { };
            foreach (Task task in tasks)
            {
                result = result.Concat(Encoding.UTF8.GetBytes($"Type:{task.GetType().Name},")).ToArray();
                result = result.Concat(task.ToBinary()).ToArray();
            }

            return result;
        }

        public static TaskList<Task> ReadBinary(byte[] data)
        {
            TaskList<Task> tasks = new TaskList<Task>();

            string strData = Encoding.UTF8.GetString(data);
            string[] objects = strData.Split(';');

            for (int i = 0; i < objects.Length; i++)
            {
                Dictionary<String, String> dictionary = new Dictionary<String, String>();
                dictionary = BinaryParser.ParseBinaryObject(objects[i]);

                if (dictionary.ContainsKey("Type"))
                {
                    string type = dictionary["Type"];
                    Type taskType = Type.GetType($"task_manager.{type}");
                    if (taskType == null) continue;

                    TaskBuilder builder = new TaskBuilder();
                    builder.Build();
                    dynamic newTask = Activator.CreateInstance(taskType, builder);
                    newTask.ReadPropertyFromBinary(newTask, dictionary);
                    newTask.SetOptions();

                    tasks.Add(newTask);
                }
            }

            return tasks;
        }



    }
}

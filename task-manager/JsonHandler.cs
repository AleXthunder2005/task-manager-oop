using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    public static class JsonHandler
    {
        public static string BuildJson(TaskList<Task> tasks) 
        {

            StringBuilder jsonBuilder = new StringBuilder("[");
            foreach (Task task in tasks)
            {
                jsonBuilder.Append("\n{");
                jsonBuilder.Append($"\n\t\"Type\": \"{task.GetType().Name}\",");

                jsonBuilder.Append(task.ToJSON().TrimStart('{'));
                jsonBuilder.Append(",");
            }
            jsonBuilder.Length--;
            jsonBuilder.Append("\n]");
            return jsonBuilder.ToString();
        }

        public static TaskList<Task> ReadJson(string json) 
        { 
            TaskList<Task> tasks = new TaskList<Task>();


            string[] objects = SplitJsonArray(json);

            for (int i = 0; i < objects.Length; i++)
            {
                Dictionary<String, String> dictionary = new Dictionary<String, String>();
                dictionary = JsonParser.ParseJsonObject(objects[i]);

                if (dictionary.ContainsKey("Type")) 
                {
                    string type = dictionary["Type"];
                    Type taskType = Type.GetType($"task_manager.{type}");
                    if (taskType == null) continue;
                    
                    TaskBuilder builder = new TaskBuilder();
                    builder.Build();
                    dynamic newTask = Activator.CreateInstance(taskType, builder);
                    newTask.ReadPropertyFromJSON(newTask, dictionary);
                    newTask.SetOptions();

                    tasks.Add(newTask);
                }
            }

            return tasks;
        }        
        
        
        private static string[] SplitJsonArray(string array)
        {
            array = array.Trim('[', ']');
            var objects = new List<string>();
            int braceLevel = 0;
            int startIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                char c = array[i];
                if (c == '{')
                {
                    if (braceLevel == 0)
                        startIndex = i;
                    braceLevel++;
                }
                else if (c == '}')
                {
                    braceLevel--;
                    if (braceLevel == 0)
                    {
                        objects.Add(array.Substring(startIndex, i - startIndex + 1));
                    }
                }
            }

            return objects.ToArray();
        }
    }
}

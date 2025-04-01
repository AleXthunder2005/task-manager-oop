using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using task_manager.FileHandlers;

namespace task_manager
{
    public static class JsonHandler
    {
        public static string BuildJson(TaskList<Task> tasks, bool haveToSaveChecksum = false) 
        {

            StringBuilder jsonBuilder = new StringBuilder("[");
            if (tasks.Count > 0)
            {
                foreach (Task task in tasks)
                {
                    jsonBuilder.Append("{");
                    jsonBuilder.Append($"\"Type\":\"{task.GetType().Name}\",");

                    string jsonTask = task.ToJSON();
                    jsonBuilder.Append(jsonTask.Substring(1, jsonTask.Length - 1));
                    jsonBuilder.Append(",");
                }
                jsonBuilder.Length--;
            }
            jsonBuilder.Append("]");

            string json = jsonBuilder.ToString();
            if (haveToSaveChecksum) 
            {
                json = JsonPlugin.SaveChecksum(json);
            }

            //красивый вывод
            JsonDocument doc = JsonDocument.Parse(json);
            json = JsonSerializer.Serialize(doc, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            return json;
        }

        public static TaskList<Task> ReadJson(string json, bool haveToVerifyChecksum = false) 
        { 
            TaskList<Task> tasks = new TaskList<Task>();

            try
            {
                JsonDocument doc = JsonDocument.Parse(json.Trim());
                json = JsonSerializer.Serialize(doc, new JsonSerializerOptions
                {
                    WriteIndented = false
                });
            }
            catch 
            {
                MessageBox.Show("Reading unsuccessful! (Json is incorrect!)", "Opening error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return tasks;
            }


            if (haveToVerifyChecksum) 
            {
                if (!JsonPlugin.IsChecksumCorrect(json))
                {
                    MessageBox.Show("Reading unsuccessful! (Checksum is incorrect!)", "Opening error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return tasks;
                }
            }
            json = JsonPlugin.DiscardChecksum(json);


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


                    bool isReadingSuccessful = newTask.IsReadingFromJsonObjectSuccessful(newTask, dictionary);

                    if (!isReadingSuccessful)
                    {
                        MessageBox.Show("Reading unsuccessful!", "Opening error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tasks.Clear();
                        break;
                    }

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

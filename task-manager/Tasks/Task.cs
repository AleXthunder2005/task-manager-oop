using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_manager
{
    public abstract class Task
    {
        private string _title;
        private string _description;
        private int _taskId;

        public static int _idCounter;

        static Task() 
        {
            _idCounter = 0;
        }

        public Task() { }
        public Task (TaskBuilder builder) {
            Title = builder.Title;
            Description = builder.Description;

            _taskId = _idCounter++;
        }

        public abstract void Draw(Graphics g, DrawOptions options);

        protected abstract void SetOptions();
        //properties
        public string Title {
            get { return _title; }
            set { _title = value; }
        }
        public string Description {
            get { return _description; }
            set { _description = value; }
        }

        public int TaskID {
            get { return _taskId; }
            set { _taskId = value; }
        }

        public bool IsCompleted { get; set; } = false;

        public DrawOptions Options { get; set; } = new DrawOptions();

        public abstract Task Clone();

        public override bool Equals(object obj)
        {
            Task otherTask = obj as Task;
            if (otherTask == null)
            {
                return false;
            }

            return this.TaskID == otherTask.TaskID;
        }

        public virtual string ToJSON()
        {
            var jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");

            // Сериализация базовых свойств
            jsonBuilder.Append($"\"Title\": \"{Title}\"");
            jsonBuilder.Append($",\"Description\": \"{Description}\"");
            jsonBuilder.Append($",\"TaskID\": {TaskID}");
            jsonBuilder.Append($",\"IsCompleted\": {(IsCompleted ? "true" : "false")}");

            // Сериализация Options
            jsonBuilder.Append(",\"Options\": {");
            jsonBuilder.Append($"\"X\": {Options.X}");
            jsonBuilder.Append($",\"Y\": {Options.Y}");
            jsonBuilder.Append("}");

            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        public void ReadPropertyFromJSON(Task task, Dictionary<string, string> jsonObject) 
        {
            task.Title = jsonObject.ContainsKey("Title") ? jsonObject["Title"] : "task";
            task.Description = jsonObject.ContainsKey("Description") ? jsonObject["Description"] : "description";
            if (jsonObject.ContainsKey("TaskID")) task.TaskID = int.Parse(jsonObject["TaskID"]);
            task.IsCompleted = jsonObject.ContainsKey("IsCompleted") ? bool.Parse(jsonObject["IsCompleted"]) : false;

            // Десериализация Options
            if (jsonObject.TryGetValue("Options", out string optionsJson))
            {
                var optionsProps = JsonParser.ParseJsonToDictionary(optionsJson);
                task.Options = new DrawOptions
                {
                    X = int.Parse(optionsProps["X"]),
                    Y = int.Parse(optionsProps["Y"]),
                };
            }
        }
    }
}

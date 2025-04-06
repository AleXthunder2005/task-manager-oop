using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using task_manager.FileHandlers;
using task_manager.Tasks;

namespace task_manager
{
    public static class JsonHandler
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new TaskJsonConverter() },
        };

        public static string BuildJson(TaskList<Task> tasks, bool haveToSaveChecksum = false)
        {
            try
            {
                string json = JsonSerializer.Serialize(tasks, _jsonOptions);

                if (haveToSaveChecksum)
                {
                    json = JsonPlugin.SaveChecksum(json);
                }

                return json;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Serialization failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static TaskList<Task> ReadJson(string json, bool haveToVerifyChecksum = false)
        {
            try
            {
                if (haveToVerifyChecksum)
                {
                    if (!JsonPlugin.IsChecksumCorrect(json))
                    {
                        MessageBox.Show("Checksum verification failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new TaskList<Task>();
                    }
                    json = JsonPlugin.DiscardChecksum(json);
                }

                TaskList<Task> tasks = JsonSerializer.Deserialize<TaskList<Task>>(json, _jsonOptions);
                if (tasks != null)
                {
                    tasks.RemoveAll(task => task == null);
                    return tasks;
                }
                return new TaskList<Task>();
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Invalid JSON format: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new TaskList<Task>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new TaskList<Task>();
            }
        }
    }
}

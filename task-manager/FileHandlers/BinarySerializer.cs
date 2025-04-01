using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using task_manager.FileHandlers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace task_manager
{
    public static class BinarySerializer
    {
        public static void SerializeTasks(TaskList<Task> tasks, string filePath, bool haveToSaveChecksum = false)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(memoryStream, tasks);
                    byte[] data = memoryStream.ToArray();

                    if (haveToSaveChecksum)
                    {
                        data = BinaryPlugin.SaveChecksum(data);
                    }
                    File.WriteAllBytes(filePath, data);

                    MessageBox.Show("Successful saving!", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Unsuccessful saving!", "Saving error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tasks.Clear();
            }
        }

        public static TaskList<Task> DeserializeTasks(string filePath, bool haveToVerifyChecksum = false)
        {
            try
            {
                byte[] fileData = File.ReadAllBytes(filePath);

                if (haveToVerifyChecksum)
                {
                    if (!BinaryPlugin.IsChecksumCorrect(fileData))
                    {
                        MessageBox.Show($"Reading unsuccessful! (Checksum is incorrect!)", "Opening error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new TaskList<Task>();
                    }
                    else
                    {
                        byte[] data = BinaryPlugin.DiscardChecksum(fileData);
                        using (MemoryStream memoryStream = new MemoryStream(data))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            return (TaskList<Task>)formatter.Deserialize(memoryStream);
                        }
                    }
                }
                else
                {
                    using (MemoryStream memoryStream = new MemoryStream(fileData))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        return (TaskList<Task>)formatter.Deserialize(memoryStream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Reading unsuccessful!", "Opening error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new TaskList<Task>();
            }
        }
    }
}

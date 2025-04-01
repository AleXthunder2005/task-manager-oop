using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace task_manager
{
    public static class BinarySerializer
    {
        public static void SerializeTasks(TaskList<Task> tasks, string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, tasks);
                }
                MessageBox.Show("Successful saving!", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Unsuccessful saving!", "Saving error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tasks.Clear();
            }
        }

        public static TaskList<Task> DeserializeTasks(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (TaskList<Task>)formatter.Deserialize(fs);
                }
            }
            catch
            {
                MessageBox.Show("Reading unsuccessful!", "Opening error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new TaskList<Task>();
            }
        }

    }
}

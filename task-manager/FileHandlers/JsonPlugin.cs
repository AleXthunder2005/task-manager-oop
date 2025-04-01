using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_manager.FileHandlers
{
    public static class JsonPlugin
    {
        public static string SaveChecksum(string jsonArray) 
        {
            int checksum = int.MaxValue - jsonArray.Length;

            StringBuilder jsonBuilder = new StringBuilder("");

            jsonBuilder.Append("{");
            jsonBuilder.Append("\"Tasks\":");
            jsonBuilder.Append(jsonArray);

            jsonBuilder.Append(",");

            jsonBuilder.Append($"\"Metadata\":{{\"Checksum\": {checksum}}}");

            jsonBuilder.Append("}");

            return jsonBuilder.ToString();
        }

        public static string DiscardChecksum(string json) 
        {

            Dictionary<string, string> parsedJson = JsonParser.ParseJsonObject(json);

            if (parsedJson.ContainsKey("Tasks"))
            {
                int tasksArrayLength = parsedJson["Tasks"].Length;
                return parsedJson["Tasks"].Substring(1, tasksArrayLength - 2); // обрезали {}
            }
            {
                return json;
            }
        }

        public static bool IsChecksumCorrect(string json) {

            Dictionary<string, string> parsedJson = JsonParser.ParseJsonObject(json);

            if (parsedJson.ContainsKey("Metadata"))
            {
                var parsedMetadata = JsonParser.ParseJsonObject(parsedJson["Metadata"]);
                if (parsedMetadata.ContainsKey("Checksum"))
                {
                    try
                    {
                        int checksum = int.Parse(parsedMetadata["Checksum"]);
                        int diff = int.MaxValue - (checksum + parsedJson["Tasks"].Length);
                        if (diff != 0)
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            else 
            {
                return false;
            }

                return true;
        }

    }
}

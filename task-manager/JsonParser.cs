using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    public static class JsonParser
    {
        public static Dictionary<string, string> ParseJsonToDictionary(string json)
        {
            var result = new Dictionary<string, string>();
            json = json.Trim().TrimStart('{').TrimEnd('}');

            int braceLevel = 0;
            int startIndex = 0;
            bool inQuotes = false;

            // Сначала разбиваем на пары ключ-значение с учетом вложенных объектов
            var pairs = new List<string>();

            for (int i = 0; i < json.Length; i++)
            {
                char c = json[i];

                if (c == '"' && (i == 0 || json[i - 1] != '\\'))
                    inQuotes = !inQuotes;

                if (!inQuotes)
                {
                    if (c == '{') braceLevel++;
                    if (c == '}') braceLevel--;

                    if (c == ',' && braceLevel == 0)
                    {
                        pairs.Add(json.Substring(startIndex, i - startIndex));
                        startIndex = i + 1;
                    }
                }
            }

            // Добавляем последнюю пару
            if (startIndex < json.Length)
                pairs.Add(json.Substring(startIndex));

            // Обрабатываем каждую пару
            foreach (var pair in pairs)
            {
                int colonPos = pair.IndexOf(':');
                if (colonPos <= 0) continue;

                string key = pair.Substring(0, colonPos).Trim().Trim('"');
                string value = pair.Substring(colonPos + 1).Trim();

                // Если значение - вложенный объект, сохраняем его как есть
                if (value.StartsWith("{") && value.EndsWith("}"))
                {
                    result[key] = value;
                }
                else
                {
                    // Удаляем кавычки у строковых значений
                    if (value.StartsWith("\"") && value.EndsWith("\""))
                        value = value.Substring(1, value.Length - 2);
                        value = value.Trim();

                    result[key] = value;
                }
            }

            return result;
        }
    }
}

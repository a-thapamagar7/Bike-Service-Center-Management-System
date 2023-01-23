using Coursework.Data.Model;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Coursework.Data
{
	public class Helper
	{
        private static string _SecretKey = "afhkjJHFD89afj92";

        public static string ConvertHash(string input, string secretKey)
        {
            using (var hmac = new HMACSHA512())
            {
                secretKey = _SecretKey;
                hmac.Key = Encoding.UTF8.GetBytes(secretKey);

                byte[] data = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public static List<StaffInfo> GetAll()
        {
            var inventory = Helper.ReadFromFile<List<StaffInfo>>(fileName: "StaffInfo.json");
            return inventory;
        }

        public static List<AdminInfo> GetAllAdmin()
        {
            var inventory = Helper.ReadFromFile<List<AdminInfo>>(fileName: "AdminInfo.json");
            return inventory;
        }

        public static List<ItemRequest> GetAllItemRequest()
        {
            var inventory = Helper.ReadFromFile<List<ItemRequest>>(fileName: "ItemRequests.json");
            return inventory;
        }

            public static List<AvailableItems> GetAllAvailableItems()
        {
            var inventory = Helper.ReadFromFile<List<AvailableItems>>(fileName: "AvailableItems.json");
            return inventory;
        }

        public static List<AvailableItems> SelectionSortAscending(List<AvailableItems> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j].QuantityAvailable < list[minIndex].QuantityAvailable)
                    {
                        minIndex = j;
                    }
                }
                // Swap the minimum value with the value at the current index
                AvailableItems temp = list[i];
                list[i] = list[minIndex];
                list[minIndex] = temp;
            }
            return list;
        }

        public static List<AvailableItems> SelectionSortDescending(List<AvailableItems> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j].QuantityAvailable > list[minIndex].QuantityAvailable)
                    {
                        minIndex = j;
                    }
                }
                // Swap the maximum value with the value at the current index
                AvailableItems temp = list[i];
                list[i] = list[minIndex];
                list[minIndex] = temp;
            }
            return list;
        }

        public static T ReadFromFile<T>(string fileName)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "Resources", fileName);
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }

        public static void WriteToFile(string fileName, object data)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "Resources", fileName);
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, json);
        }
    }
}

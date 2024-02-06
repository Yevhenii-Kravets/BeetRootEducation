namespace Logs
{
    public class Log
    {
        private const string FileName = "Logs.json";
        private static List<string> Logs = new List<string>();

        public static void WriteLog(string text)
        {
            ReadLogs();

            Logs.Add(text);
            File.WriteAllLines(FileName, Logs);
        }
        public static List<string> ReadLogs() => Logs = File.ReadAllLines(FileName).ToList();
    }
}
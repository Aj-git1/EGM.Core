namespace EGM.Core
{
    public class OsService
    {
        private string timezone = "UTC";

        public void SetTimezone(string newTimezone)
        {
            if (string.IsNullOrWhiteSpace(newTimezone))
            {
                Console.WriteLine("Invalid timezone.");
                return;
            }

            var oldTimezone = timezone;
            timezone = newTimezone;

            // Persist to file
            File.WriteAllText("os_config.txt", timezone);

            // Audit log
            Console.WriteLine($"[AUDIT] Operator changed timezone");
            Console.WriteLine($"Timestamp: {DateTime.UtcNow:u}");
            Console.WriteLine($"Old Value: {oldTimezone}");
            Console.WriteLine($"New Value: {newTimezone}");
        }

        public void ShowTimezone()
        {
            Console.WriteLine($"Current Timezone: {timezone}");
        }
    }
}
namespace EGM.Core
{
    public class UpdateService
    {
        private readonly Machine _machine;

        private string currentVersion = "v1";
        private string lastKnownGoodVersion = "v1";

        private List<string> installHistory = new();

        public UpdateService(Machine machine)
        {
            _machine = machine;
        }

        public void Install(string packagePath)
        {
            Console.WriteLine($"Starting update using {packagePath}");

            _machine.SetState(MachineState.UPDATING);

            try
            {
                // 1. Validate package exists
                if (!File.Exists(packagePath))
                    throw new Exception("Package not found");

                // 2. Simulate pre-install script
                bool preInstallSuccess = true; // change to false to test rollback

                if (!preInstallSuccess)
                    throw new Exception("Pre-install script failed");

                // 3. Update success
                lastKnownGoodVersion = currentVersion;
                currentVersion = Path.GetFileNameWithoutExtension(packagePath);

                installHistory.Add(currentVersion);

                Console.WriteLine($"Update successful. Current version: {currentVersion}");

                _machine.SetState(MachineState.IDLE);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update failed: {ex.Message}");
                currentVersion = lastKnownGoodVersion;
                Console.WriteLine($"Rollback to version: {currentVersion}");

                _machine.SetState(MachineState.ERROR);
            }
        }

        public void ShowVersions()
        {
            Console.WriteLine($"Current Version: {currentVersion}");
            Console.WriteLine($"Last Known Good: {lastKnownGoodVersion}");
        }
    }
}
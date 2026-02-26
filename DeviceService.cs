namespace EGM.Core
{
    public class DeviceService
    {
        private readonly Machine _machine;
        private bool _ackEnabled = true;

        public DeviceService(Machine machine)
        {
            _machine = machine;
            StartKeepAlive();
        }

        public void SetAck(bool value)
        {
            _ackEnabled = value;
            Console.WriteLine($"Bill validator ACK set to {value}");
        }

        private void StartKeepAlive()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(10000);

                    Console.WriteLine("Sending keep-alive ping...");

                    await Task.Delay(2000);

                    if (!_ackEnabled)
                    {
                        _machine.EnterMaintenanceFromDevice();
                    }
                }
            });
        }
    }
}
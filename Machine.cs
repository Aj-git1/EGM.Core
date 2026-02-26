namespace EGM.Core
{
    public class Machine
    {
        public MachineState CurrentState { get; private set; } = MachineState.IDLE;

        private bool _gameRunning = false;

        public bool SetState(MachineState newState)
        {
            if (CurrentState == newState)
                return false;

            CurrentState = newState;
            Console.WriteLine($"State changed to {newState}");
            return true;
        }

        public void StartGame()
        {
            if (CurrentState != MachineState.IDLE)
                return;

            _gameRunning = true;
            SetState(MachineState.RUNNING);

            Task.Run(async () =>
            {
                while (_gameRunning)
                {
                    Console.WriteLine("Game running...");
                    await Task.Delay(2000);
                }
            });
        }

        public void StopGame()
        {
            _gameRunning = false;
            SetState(MachineState.IDLE);
        }

        public void EnterMaintenance()
        {
            _gameRunning = false;
            SetState(MachineState.MAINTENANCE);
        }

        public void EnterMaintenanceFromDevice()
        {
            if (CurrentState == MachineState.MAINTENANCE)
                return;

            Console.WriteLine("Bill validator not responding – entering maintenance mode.");
            _gameRunning = false;
            SetState(MachineState.MAINTENANCE);
        }
    }
}
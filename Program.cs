using EGM.Core;

var machine = new Machine();
var deviceService = new DeviceService(machine);
var updateService = new UpdateService(machine);
var osService = new OsService();

Console.WriteLine("EGM Core Started");

while (true)
{
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;

    if (input == "exit")
        break;

    switch (input)
    {
        case "start_game":
            machine.StartGame();
            break;

        case "stop_game":
            machine.StopGame();
            break;

        case "signal door_open":
            Console.WriteLine("Door opened – entering maintenance mode.");
            machine.EnterMaintenance();
            break;

        case "status":
            Console.WriteLine($"Current State: {machine.CurrentState}");
            break;

        case "device bill_validator ack on":
            deviceService.SetAck(true);
            break;

        case "device bill_validator ack off":
            deviceService.SetAck(false);
            break;
        case var cmd when cmd.StartsWith("update --package"):
            var parts = cmd.Split(' ');
            updateService.Install(parts[2]);
            break;

        case "version":
            updateService.ShowVersions();
            break;

        case var cmd when cmd.StartsWith("os set-timezone"):
            var parts1 = cmd.Split(' ');
            osService.SetTimezone(parts1[2]);
            break;

        case "os show":
            osService.ShowTimezone();
            break;
        default:
            Console.WriteLine("Unknown command");
            break;
    }
}
using P2Ps;

Console.WriteLine("Enter your port for the server:");
int port = int.Parse(Console.ReadLine());

P2PServer server = new(port);
server.Start();

Console.WriteLine("Press Enter to exit...");
Console.ReadLine();
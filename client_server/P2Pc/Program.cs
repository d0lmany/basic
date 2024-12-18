using P2Pc;

Console.WriteLine("Enter IP address of the server:");
string serverIp = Console.ReadLine();
Console.WriteLine("Enter port of the server:");
int serverPort = int.Parse(Console.ReadLine());

P2PClient client = new();
while (true){
    Console.WriteLine("Enter message to send:");
    string message = Console.ReadLine();
    client.SendMessage(serverIp, serverPort, message);
}
Console.ReadKey();
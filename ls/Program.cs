static string[] GetList(string path)
{
    string[] files = Directory.GetFiles(path);
    string[] dirs = Directory.GetDirectories(path);
    List<string> list = [];
    list.AddRange(dirs);
    list.AddRange(files);
    list.Sort();
    return [.. list];
}
string[] list = [];
if (args.Length > 0)
{
    try
    {
        list = GetList(args[0]);
    }
    catch
    {
        Console.WriteLine("Enter not a path");
    }
}
else
{
    list = GetList(Environment.CurrentDirectory);
}
using (StreamWriter sw = new("list.txt", false))
{
    foreach (string file in list)
    {
        sw.WriteLine(Path.GetFileName(file));
    }
}
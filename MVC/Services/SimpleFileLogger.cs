namespace MVC.Services;

public class SimpleFileLogger
{
    public void Log(string message)
    {
        File.AppendAllText(DateTime.Today.ToString("yyyy-MM-dd") + ".txt", message + Environment.NewLine);
    }
}

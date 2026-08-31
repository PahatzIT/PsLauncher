using System.Diagnostics;
using System.IO;
using System.Text;

try
{
    if (args.Length == 0)
    {
        Environment.ExitCode = 1;
        return;
    }

    string scriptPath = args[0];

    if (!File.Exists(scriptPath))
    {
        Environment.ExitCode = 1;
        return;
    }

    StringBuilder psArgs = new();
    psArgs.Append("-NoProfile -ExecutionPolicy Bypass -WindowStyle Hidden ");
    psArgs.Append($"-File \"{scriptPath}\"");

    for (int i = 1; i < args.Length; i++)
    {
        psArgs.Append($" \"{args[i]}\"");
    }

    ProcessStartInfo psi = new()
    {
        FileName = "powershell.exe",
        Arguments = psArgs.ToString(),
        UseShellExecute = false,
        CreateNoWindow = true,
        WindowStyle = ProcessWindowStyle.Hidden
    };

    using Process? process = Process.Start(psi);

    if (process is null)
    {
        Environment.ExitCode = 1;
        return;
    }

    process.WaitForExit();

    Environment.ExitCode = process.ExitCode;
}
catch
{
    Environment.ExitCode = 1;
}
using System;
using System.IO;
using System.Runtime.InteropServices;
namespace OpenWarfare.Error
{
    public class GenericError : System.Exception
    {
        public GenericError(string message) : base(message)
        {
            string DTN = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
            System.Console.WriteLine($"Error: {message}");
            System.Console.WriteLine($"Trace: {new System.Diagnostics.StackTrace()}");
            System.Console.WriteLine($"[{DTN}] Error occured, logging to file.");
            var sw = new StreamWriter($"elog_{Environment.OSVersion.Platform.ToString().ToLower()}_{DTN}.txt", false);
            sw.WriteLine($"Error: {message}");
            sw.WriteLine($"Trace: {new System.Diagnostics.StackTrace()}");
            sw.WriteLine($"[{DTN}] Error occured, logging to file.");
            sw.WriteLine("--------------------------------------------------");
            sw.WriteLine("System Information:");
            sw.WriteLine($"OS: {RuntimeInformation.OSDescription} ${Environment.OSVersion.Platform.ToString()}");
            sw.WriteLine($"CMDLine: {Environment.CommandLine}");
            sw.WriteLine($"Path: {Environment.ProcessPath?.ToString()}");
            sw.WriteLine($"Architecture: {RuntimeInformation.ProcessArchitecture}");
            sw.WriteLine($"PID: {Environment.ProcessId}");
            sw.Close();
            Environment.Exit(1);
        }
    }
}
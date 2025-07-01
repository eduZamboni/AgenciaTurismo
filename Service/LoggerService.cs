using System;
using System.Collections.Generic;
using System.IO;

namespace AgenciaTurismo.Service
{
    public static class LoggerService
    {
        // Lista para log em memória
        public static List<string> MemoryLog { get; } = new List<string>();

        // Loga no console
        public static void LogToConsole(string message)
        {
            Console.WriteLine($"[Console] {message}");
        }

        // Loga em arquivo
        public static void LogToFile(string message)
        {
            var projectDir = Directory.GetCurrentDirectory();
            var filesDir = Path.Combine(projectDir, "wwwroot", "files");
            if (!Directory.Exists(filesDir))
            {
                Directory.CreateDirectory(filesDir);
            }
            var logPath = Path.Combine(filesDir, "log.txt");
            File.AppendAllText(logPath, $"[File] {DateTime.Now}: {message}{Environment.NewLine}");
        }

        // Loga em memória
        public static void LogToMemory(string message)
        {
            MemoryLog.Add($"[Memory] {DateTime.Now}: {message}");
        }
    }
}

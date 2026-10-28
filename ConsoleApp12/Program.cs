using System;
using System.Diagnostics;
using System.ComponentModel;

public class Program
{
    public static async Task Main()
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = "dotnet",
            UseShellExecute = false,
            CreateNoWindow = true
        };

        // TODO 1. Добавьте аргумент "--info" через startInfo.ArgumentList.
        startInfo.ArgumentList.Add("--info");

        // TODO 2. Укажите рабочую директорию Environment.CurrentDirectory.
        startInfo.WorkingDirectory = Environment.CurrentDirectory;

        using Process process = new()
        {
            StartInfo = startInfo
        };

        Stopwatch stopwatch = new();

        try
        {
            // TODO 3. Запустите секундомер.
            stopwatch.Start();

            // TODO 4. Запустите процесс через Start().
            process.Start();

            // TODO 5. Выведите PID процесса.
            Console.WriteLine($"PID: {process.Id}");

            // TODO 6. Дождитесь завершения через await process.WaitForExitAsync().
            await process.WaitForExitAsync();

            // TODO 7. Остановите секундомер.
            stopwatch.Stop();

            // TODO 8. Выведите длительность и ExitCode.
            Console.WriteLine($"Длительность: {stopwatch.Elapsed}");
            Console.WriteLine($"Exit code: {process.ExitCode}");
        }
        catch (Win32Exception ex)
        {
            // TODO 9. Сообщите об ошибке запуска. Не используйте пустой catch.
            Console.WriteLine($"Ошибка запуска: Не удалось выполнить '{startInfo.FileName}'.");
            Console.WriteLine($"Детали ошибки: {ex.Message}");
        }
    }
}
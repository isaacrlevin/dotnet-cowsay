using System;
using System.Threading;
using Kurukuru;
using System.Threading.Tasks;
namespace dotnetcowsay
{
static class SpinnerEx
    {
        public static void Start(string text, Action action, Pattern pattern = null, Pattern fallbackPattern = null)
        {
            Start(text, _ => action(), pattern, fallbackPattern);
        }

        public static void Start(string text, Action<Spinner> action, Pattern pattern = null, Pattern fallbackPattern = null)
        {
            using (var spinner = new Spinner(text, pattern, fallbackPattern: fallbackPattern))
            {
                spinner.Start();

                try
                {
                    action(spinner);

                    if (!spinner.Stopped)
                    {
                        spinner.Stop("", "");
                    }
                }
                catch
                {
                    if (!spinner.Stopped)
                    {
                        spinner.Stop("", "");
                    }
                    throw;
                }
            }
        }

        public static Task StartAsync(string text, Func<Task> action, Pattern pattern = null, Pattern fallbackPattern = null)
        {
            return StartAsync(text, _ => action(), pattern, fallbackPattern);
        }

        public static async Task StartAsync(string text, Func<Spinner, Task> action, Pattern pattern = null, Pattern fallbackPattern = null)
        {
            using (var spinner = new Spinner(text, pattern, fallbackPattern: fallbackPattern))
            {
                spinner.Start();

                try
                {
                    await action(spinner);
                    if (!spinner.Stopped)
                    {
                        spinner.Stop("", "");
                    }
                }
                catch
                {
                    if (!spinner.Stopped)
                    {
                        spinner.Stop("", "");
                    }
                    throw;
                }
            }
        }
    }}
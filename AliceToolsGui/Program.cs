// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AliceToolsGui
{
    static class Program
    {


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 4 && int.TryParse(args[3], out int pid))
            {
                TryKillProcess(pid);

                if (args[1] == "update")
                {
                    File.Copy(args[0], args[2], true);
                    var si = new ProcessStartInfo(args[2], $"delete \"{args[0]}\" {GetThisPID()}")
                    {
                        UseShellExecute = false
                    };
                    Process.Start(si).Dispose();
                    Environment.Exit(0);
                }
                else if (args[1] == "delete")
                {
                    File.Delete(args[2]);
                }
            }
            using (var mutex = new Mutex(true, "7bd011cf-ed65-4dd7-98c6-129f07f580e9", out bool createNew))
            {
                if (createNew)
                {
                    FormMain.ClearTemp();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain());
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        public static int GetThisPID()
        {
            using (var proc = Process.GetCurrentProcess())
            {
                return proc.Id;
            }
        }

        private static void TryKillProcess(int pid)
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(pid);
                if (!proc.HasExited)
                {
                    proc.Kill();
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch { }
#pragma warning restore CA1031 // Do not catch general exception types
            finally
            {
                proc?.Dispose();
            }
        }
    }
}

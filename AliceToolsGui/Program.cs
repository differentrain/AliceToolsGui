using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using AliceToolsGui.AliceToolsProxies;
using AliceToolsGui.GithubRepoReleases;

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
            if (args.Length == 3)
            {
                if (args[1] == "update")
                {
                    File.Copy(args[0], args[2], true);
                    Process.Start(args[2], $"delete \"{args[0]}\"");
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
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DriverFileInstallApp
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            //InitializeComponent();
        }
        public override void Install(IDictionary savedState)
        {
            base.Install(savedState);
            //Add custom code here
            try
            {

                string action = "";
                string assemblyPath = "";
                StringDictionary myStringDictionary = Context.Parameters;
                if (Context.Parameters.Count > 0)
                {
                    foreach (string myString in Context.Parameters.Keys)
                    {
                        if (myString.ToLower().Equals("action"))
                        {
                            action = Context.Parameters[myString];
                        }
                        if (myString.ToLower().Equals("assemblypath"))
                        {
                            assemblyPath = Context.Parameters[myString];
                        }
                    }
                    //remove last file name to get the assembly root path
                    assemblyPath = assemblyPath.Substring(0, assemblyPath.LastIndexOf("\\"));
                }
                string path_to_inf = assemblyPath + "\\driversFolder\\sign_inf\\smb.inf";
                driverInstall(path_to_inf);
                //}
            }
            catch { }
        }
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
            //Add custom code here
        }
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            //Add custom code here
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            //Add custom code here
        }
        /// <summary>
        /// execute PnPutil.exe to install the driver INF file
        /// </summary>
        /// <param name="driverPath"></param>
        private static void driverInstall(string driverPath)
        {
            try
            {
                var process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.FileName = "cmd.exe";
                string a = @"" + driverPath + "";
                process.StartInfo.Arguments = "/c C:\\Windows\\System32\\PnPutil.exe -a \"" + driverPath + "\""; // where driverPath is path of .inf file
                process.Start();
                process.WaitForExit();
                process.Dispose();
                Console.WriteLine(@"Driver has been installed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
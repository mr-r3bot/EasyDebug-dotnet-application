using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDebug
{
    internal class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("[x] Missing parameter: absolute path to file");
                return;
            }
            string filePath = args[0];
            Console.WriteLine("[+] Absolute path to file that you want to debugged is loaded in module: {0}", filePath);
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist");
                return;
            }

            string[] fileContent = new string[] { "[.NET Framework Debugging Control]", "GenerateTrackingInfo=1", "AllowOptimize=0" };

            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string absPath = Path.GetDirectoryName(filePath);
            string fileIni = Path.Combine(absPath, fileName + ".ini");


            try
            {
                Console.WriteLine("[+] Writing .ini file to: {0}", fileIni);
                File.WriteAllLines(fileIni, fileContent);
            }
            catch (Exception e)
            {
                Console.WriteLine("[x] error write .ini file: {0}", e);
            }

            try
            {
                Console.WriteLine("[+] Modifying registry key value to disable optimization");
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Environment\\", "COMPLUS_ZAPDISABLE", "1", RegistryValueKind.String);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Environment\\", "COMPlus_ReadyToRun", "0",  RegistryValueKind.String);
                Console.WriteLine("[+] Modifided COMPLUS_ZAPDISABLE=1");
                Console.WriteLine("[+] Modifided COMPlus_ReadyToRun=0");
            }
            catch (Exception e) { Console.WriteLine("[x] Error modify registry key value: {0}", e); }
        }
    }
}

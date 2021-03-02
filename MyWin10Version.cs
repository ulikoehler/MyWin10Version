using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace MyWin10Version
{
    class MyWin10Version
    {
        public static void Main(string[] args)
        {
            string win10Version = null;
            using (PowerShell powerShell = PowerShell.Create())
            {
                powerShell.AddScript("(Get-WmiObject Win32_OperatingSystem).Version");
                Collection<PSObject> PSOutput = powerShell.Invoke();
                StringBuilder stringBuilder = new StringBuilder();
                foreach (PSObject pSObject in PSOutput)
                {
                    stringBuilder.AppendLine(pSObject.ToString());
                }
                win10Version = stringBuilder.ToString();
            }
            // win10Version == "10.0.19042" ==> extract 19042
            win10Version = win10Version.Split('.').Last();
            /**
             * Show confirmation message
             */
            MessageBox.Show("Windows 10 version: " + win10Version, "MyWin10Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

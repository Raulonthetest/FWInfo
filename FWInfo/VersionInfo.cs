using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GET_OS
{
    public partial class VersionInfo : Form
    {
        public VersionInfo()
        {
            InitializeComponent();
            //1 - get os ver
            OperatingSystem os = Environment.OSVersion;
            string OSversion = Environment.OSVersion.Version.ToString();
            string Platf = "";
            if (OSversion == "3.0.9348")
            {
                Platf = "Pocket PC 2000";
            }
            else if (OSversion == "3.0.11171")
            {
                Platf = "Pocket PC 2002";
            }
            else if (OSversion == "4.20.1081")
            {
                Platf = "Pocket PC 2003";
            }
            else if (OSversion == "4.21.1088")
            {
                Platf = "Pocket PC 2003 SE";
            }
            else if (OSversion == "5.1.1700")
            {
                Platf = "Windows Mobile 5.0";
            }
            else if (OSversion == "5.2.1235")
            {
                Platf = "Windows Mobile 6.0";
            }
            else if (OSversion == "5.2.19202")
            {
                Platf = "Windows Mobile 6.1";
            }
            else if (OSversion == "5.2.20757")
            {
                Platf = "Windows Mobile 6.1.4";
            }
            else if (OSversion == "5.2.21234")
            {
                Platf = "Windows Mobile 6.5";
            }
            else if (OSversion == "5.2.23090")
            {
                Platf = "Windows Mobile 6.5.3";
            }

            //registry
            string devicemodl = "";
            string devcodename = "";
            string buildsw = "";
            string builddate = "";

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\FirmwareInfo"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("SoftwareBuild");
                    if (o != null)
                    {
                        buildsw = o as String;  //"as" because it's REG_SZ...otherwise ToString() might be safe(r)
                        //do what you like with version
                    }
                }
            }

            using (RegistryKey key2 = Registry.LocalMachine.OpenSubKey("Software\\FirmwareInfo"))
            {
                if (key2 != null)
                {
                    Object p = key2.GetValue("DeviceModel");
                    if (p != null)
                    {
                        devicemodl = p as String;  //"as" because it's REG_SZ...otherwise ToString() might be safe(r)
                        //do what you like with version
                    }
                }
            }
            using (RegistryKey key3 = Registry.LocalMachine.OpenSubKey("Software\\FirmwareInfo"))
            {
                if (key3 != null)
                {
                    Object q = key3.GetValue("DeviceCodename");
                    if (q != null)
                    {
                        devcodename = q as String;  //"as" because it's REG_SZ...otherwise ToString() might be safe(r)
                        //do what you like with version
                    }
                }
            }

            using (RegistryKey key4 = Registry.LocalMachine.OpenSubKey("Software\\FirmwareInfo"))
            {
                if (key4 != null)
                {
                    Object r = key4.GetValue("BuildDate");
                    if (r != null)
                    {
                        builddate = r as String;  //"as" because it's REG_SZ...otherwise ToString() might be safe(r)
                        //do what you like with version
                    }
                }
            }

            label1.Text = "OS : " + Platf + ", based on " + os.Platform.ToString() + " " + os.Version.ToString() + "\nDevice: " + devicemodl + " (codename " + devcodename + ")" + "\nBuild: " + buildsw + ", built at " + builddate;
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
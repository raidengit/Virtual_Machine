using Microsoft.WindowsAPICodePack.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace VirtualBoxManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PrivateFontCollection modernFont = new PrivateFontCollection();

            modernFont.AddFontFile("Fusion.ttf");

            lbl_Title.Font = new Font(modernFont.Families[0], 20, FontStyle.Bold);

            String UserName = Environment.UserName;
            lbl_Username.Text = UserName;
            string hostName = Dns.GetHostName();
            lbl_Hostname.Text = hostName;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                if (adapter.Name.Equals("Wi-Fi") || adapter.Name.Equals("Ethernet"))
                {
                    if (adapter.OperationalStatus == OperationalStatus.Up)
                    {
                        string mac_address = adapter.GetPhysicalAddress().ToString();
                        lbl_mac_address.Text = mac_address;

                        IPInterfaceProperties properties = adapter.GetIPProperties();

                        foreach (IPAddressInformation unicast in properties.UnicastAddresses)
                        {
                            if(unicast.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                lbl_ip.Text = unicast.Address.ToString();
                            } 
                        }
                        GatewayIPAddressInformationCollection addresses = properties.GatewayAddresses;
                        if (addresses.Count > 0)
                        {

                            foreach (GatewayIPAddressInformation address in addresses)
                            {
                                lbl_gateway.Text = address.Address.ToString();
                            }
                        }

                        Ping myPing = new Ping();
                        PingReply reply = myPing.Send("1.1.1.1", 1000);
                        int PingInternetCounter = 0;
                        for (int numpings = 0; numpings < 4; numpings++)
                        {
                            if (reply.Status == IPStatus.Success)
                            {
                                PingInternetCounter++;

                                if (PingInternetCounter.Equals(4))
                                {
                                    lbl_Internet_Connection.Text = "Established";
                                    lbl_Internet_Connection.ForeColor = Color.Green;
                                }
                                if (PingInternetCounter > 0 && PingInternetCounter < 4)
                                {
                                    lbl_Internet_Connection.Text = "Unstable";
                                    lbl_Internet_Connection.ForeColor = Color.Yellow;
                                }
                            }
                            if (reply.Status != IPStatus.Success)
                            {
                                lbl_Internet_Connection.Text = "Disconnected";
                                lbl_Internet_Connection.ForeColor = Color.Red;
                            }
                        }


                    }

                }

            }
            var networks = NetworkListManager.GetNetworks(NetworkConnectivityLevels.Connected);
            foreach (var network in networks)
            {
           
                if (network.IsConnected)
                {
                    lbl_ssid_status.Text = "Connected";
                    lbl_ssid_status.ForeColor= Color.Green;

                }else if (!network.IsConnected)
                {
                    lbl_ssid_status.Text = "Disconnected";
                    lbl_ssid_status.ForeColor= Color.Red;
                }
                lbl_ssid.Text = network.Name;
            }
            string strCmdText;
            //
            strCmdText = "/C" +"\"C:\\Program Files\\Oracle\\virtualbox\\VBoxManage.exe\" --version";

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = strCmdText;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            //
            string VBox_Version = "";
            while (!process.HasExited)
            {
                VBox_Version = VBox_Version + process.StandardOutput.ReadToEnd();
            }
            //

            //
            if (VBox_Version != "")
            {
                lbl_VirtualBoxInstalled.Text = "Yes";
                lbl_VirtualBoxInstalled.ForeColor = Color.Green;
                //
                string Vbox_cut_version = VBox_Version.Substring(0, VBox_Version.IndexOf("r"));
                lbl_VBOX_V.Text = Vbox_cut_version;

                if (Vbox_cut_version.Equals("7.0.6"))
                {
                    lbl_VBOX_V.Text = Vbox_cut_version + " " + "(Last Version)";
                    lbl_VBOX_V.ForeColor = Color.Green;
                }
                if (!Vbox_cut_version.Equals("7.0.6"))
                {
                    lbl_VBOX_V.Text = Vbox_cut_version + " " + "(Outdated)";
                    lbl_VBOX_V.ForeColor = Color.Yellow;
                }
            }
            if (VBox_Version.Equals(""))
            {
                lbl_VirtualBoxInstalled.Text = "No";
                lbl_VirtualBoxInstalled.ForeColor = Color.Red;
                lbl_VBOX_V.Text = "N/A";
                lbl_VBOX_V.ForeColor = Color.Red;
            }

        }
        private void cb_os_type_Click(object sender, EventArgs e)
        {
            OS_TYPE_CB();
        }
        private void OS_TYPE_CB()
        {
            cb_os_type.Items.Clear();
            cb_os_type.Items.Add("Microsoft Windows");
            cb_os_type.Items.Add("Linux");
            cb_os_type.Items.Add("Solaris");
            cb_os_type.Items.Add("BSD");
            cb_os_type.Items.Add("IBM OS/2");
            cb_os_type.Items.Add("MAC OS X");
            cb_os_type.Items.Add("Other");
        }
        private void OS_VERSION_CB()
        {
            string os_version = cb_os_type.SelectedItem.ToString();

            if (os_version.Equals("Microsoft Windows"))
            {
                WindowsOptionsCB();
            }
            if (os_version.Equals("Linux"))
            {
                LinuxOptionsCB();
            }
        }
        private void cb_os_version_Click(object sender, EventArgs e)
        {
            OS_VERSION_CB();
        }
        string savepath;
        private void OS_Location_CB()
        {
            cb_vm_location.Items.Clear();
            cb_vm_location.Items.Add("Select new Location");
            if(savepath != null)
            {
                cb_vm_location.Text = savepath;
            }
        }
        private void cb_vm_location_Click(object sender, EventArgs e)
        {
            OS_Location_CB();
        }
     
        private void cb_vm_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Prepare a dummy string, thos would appear in the dialog
            if (savepath == null)
            {
                using (FolderBrowserDialog sf = new FolderBrowserDialog())
                {

                    if (sf.ShowDialog() == DialogResult.OK)
                    {
                        // Now here's our save folder
                        savepath = sf.SelectedPath;
                        cb_vm_location.Items.Clear();
                        cb_vm_location.Items.Add(savepath);
                        cb_vm_location.Text = savepath;

                        // Do whatever
                    }
                }
            }

        }
        private void WindowsOptionsCB()
        {
            cb_os_version.Items.Clear();
            cb_os_version.Items.Add("Windows 10 (64-bit)");
            cb_os_version.Items.Add("Windows 11 (64-bit)");
            cb_os_version.Items.Add("Windows 2022 (64-bit)");
        }
        private void LinuxOptionsCB()
        {
            cb_os_version.Items.Clear();
            cb_os_version.Items.Add("Ubuntu (64-bit)");
            cb_os_version.Items.Add("Antix (64-bit)");
        }
        private void btn_create_only_Click(object sender, EventArgs e)
        {                
            string VMsname = tb_vm_name.Text;
            string OSType = cb_os_type.Text;
            string OSVersion = cb_os_version.Text;
            string VMLocation = cb_vm_location.Text;
            string RAM_label = cb_HARD_ram.Text;
            string video = cb_HARD_video.Text;
            string graphic_Serial = cb_HARD_graphic_controller.Text;
            string donwloaded_medium = "antiX-22-net_386-net.iso";
            string VM_GB = textbox_specify_disk_GB.Text;
            string VM_Format = cb_Specifiy_Disk.Text;
            string network_adapter = cb_HARD_network_1stnic.Text;
            string strCmdText1 = "/C" + "\"C:\\Program Files\\Oracle\\virtualbox\\VBoxManage.exe\" createvm --name " + VMsname + " --ostype Ubuntu_64 --register --basefolder " + VMLocation;


            Process process1 = new Process();
            process1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process1.StartInfo.FileName = "cmd.exe";
            process1.StartInfo.Arguments = strCmdText1;
            process1.StartInfo.UseShellExecute = false;
            process1.StartInfo.RedirectStandardOutput = true;
            process1.Start();

            string VBox_Version1 = "";
            while (!process1.HasExited)
            {
                VBox_Version1 = VBox_Version1 + process1.StandardOutput.ReadToEnd();
            }
            //
            process1.Dispose();
            //
            if (OSVersion.Equals("Antix (64-bit)"))
            {
                
                string strCmdText3 = "/C" + "\"C:\\Program Files\\Oracle\\virtualbox\\VBoxManage.exe\"  modifyvm " + VMsname + " --ioapic on";
                //
                string strCmdText4 = "/C" + "\"C:\\Program Files\\Oracle\\virtualbox\\VBoxManage.exe\"  modifyvm " + VMsname + " --memory " + RAM_label + " --vram " + video;
                //
                string strCmdText5 = "/C" + "\"C:\\Program Files\\Oracle\\virtualbox\\VBoxManage.exe\"  modifyvm " + VMsname + " --nic1 " + network_adapter.ToLower();
                //
                string strCmdText6 = "/C" + "\"C:\\Program Files\\Oracle\\virtualbox\\VBoxManage.exe\"  modifyvm " + VMsname + " --graphicscontroller " + graphic_Serial;
                //
                string strCmdText7 = "/C" + "\"C:\\Program Files\\Oracle\\virtualbox\\VBoxManage.exe\"  createmedium disk --filename " + VMLocation + "/" + VMsname + "/" + VMsname + "_DISK." + VM_Format.ToLower() + " --size " + VM_GB + " --format " + VM_Format;
                //
                string strCmdTextAntix = "/C" + " cd "+VMLocation+" && curl.exe --url https://ftp.caliu.cat/pub/distribucions/mxlinux/MX-ISOs/ANTIX/Final/antiX-22/antiX-22-net_386-net.iso --output " + donwloaded_medium;
                //
                string Full_Location = VMLocation + "/" + VMsname + "/" + VMsname + "_DISK." + VM_Format.ToLower();
                //
                string[] array_commands = new string[] {
                    strCmdText3,
                    strCmdText4,
                    strCmdText5,
                    strCmdText6,
                    strCmdText7,
                    strCmdTextAntix,
                };
                foreach (string CMD_Arguments in array_commands)
                {
                    Process process2 = new Process();
                    process2.StartInfo.FileName = "cmd.exe";
                    process2.StartInfo.Arguments = CMD_Arguments;
                    process2.StartInfo.UseShellExecute = false;
                    process2.StartInfo.RedirectStandardOutput = true;
                    process2.Start();
                    process2.WaitForExit();
                }

                //
                //
                //Process process = new Process();

                //process.StartInfo.FileName = @"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe";
                //process.StartInfo.Arguments = $"storagectl {VMsname} --name \"SATA Controller\" --add sata --controller IntelAhci";
                //process.StartInfo.UseShellExecute = false;
                //process.StartInfo.RedirectStandardOutput = true;
                //process.StartInfo.RedirectStandardError = true;
                //process.Start();
                //process.Dispose();
                ////
                //Process process3 = new Process();
                ////
                //process3.StartInfo.FileName = @"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe";
                //process3.StartInfo.Arguments = $"storageattach {VMsname} --storagectl " + "\"SATA Controller\" --port 0 --device 0 --type hdd --medium " + Full_Location;
                //process3.StartInfo.UseShellExecute = false;
                //process3.StartInfo.RedirectStandardOutput = true;
                //process3.StartInfo.RedirectStandardError = true;
                //process3.Start();
                //process3.Dispose();
                ////
                 Process process4 = new Process();
                //

                process4.StartInfo.FileName = @"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe";
                process4.StartInfo.Arguments = $"storagectl {VMsname} --name " + "\"IDE Controller\" --add ide --controller PIIX4";
                process4.StartInfo.UseShellExecute = false;
                process4.StartInfo.RedirectStandardOutput = true;
                process4.Start();
                process4.Dispose();
                //
                Process process5 = new Process();
                //
                process5.StartInfo.FileName = @"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe";
                process5.StartInfo.Arguments = $"storageattach {VMsname} --storagectl " + "\"IDE Controller\" --port 1 --device 0 --type dvddrive --medium " + VMLocation + "\\" + donwloaded_medium;
                process5.StartInfo.UseShellExecute = false;
                process5.StartInfo.RedirectStandardOutput = true;
                process5.Start();
                process5.Dispose();
                ////
                //Process process6 = new Process();
                ////
                //process6.StartInfo.FileName = @"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe";
                //process6.StartInfo.Arguments = $"modifyvm {VMsname} --boot1 dvd --boot2 disk --boot3 none --boot4 none";
                //process6.StartInfo.UseShellExecute = false;
                //process6.StartInfo.RedirectStandardOutput = true;
                //process6.StartInfo.RedirectStandardError = true;
                //process6.Start();
                //process6.Dispose();
                ////
                if (checkBox1.Checked)
                {
                    string strCmdText13 = "/C" + "\"C:\\Program Files\\Oracle\\virtualbox\\VBoxManage.exe\" startvm " + VMsname;
                    Process process10 = new Process();
                    process10.StartInfo.FileName = "cmd.exe";
                    process10.StartInfo.Arguments = strCmdText13;
                    process10.StartInfo.UseShellExecute = false;
                    process10.StartInfo.RedirectStandardOutput = true;
                    process10.Start();
                    process10.Dispose();
                }
                // @"storagectl ANTIX --name ""SATA Controller"" --add sata --controller IntelAhci";
                //
                //string strCmdText8 = "/C" + @"C:\Program Files\Oracle\virtualbox\VBoxManage.exe" + $"storagectl {VMsname} --name \"SATA Controller\" --add sata --controller IntelAhci";
                ////
                //string strCmdText9 = "/C" + @"C:\Program Files\Oracle\virtualbox\VBoxManage.exe" + $"storageattach {VMsname} --storagectl " + "\"SATA Controller\" --port 0 --device 0 --type hdd --medium " + Full_Location;
                ////
                //string strCmdText10 = "/C" + @"C:\Program Files\Oracle\virtualbox\VBoxManage.exe" + $"storagectl {VMsname} --name " + "\"IDE Controller\" --add ide --controller PIIX4";
                ////
                //string strCmdText11 = "/C" + @"C:\Program Files\Oracle\virtualbox\VBoxManage.exe" + $"storageattach {VMsname} --storagectl " + "\"IDE Controller\" --port 1 --device 0 --type dvddrive --medium " + VMLocation + "\\" +donwloaded_medium;
                ////
                //string strCmdText12 = "/C" + @"C:\Program Files\Oracle\virtualbox\VBoxManage.exe" + $"modifyvm {VMsname} --boot1 dvd --boot2 disk --boot3 none --boot4 none";
                ////

            }



        }
       

        private void cb_Specifiy_Disk_Click(object sender, EventArgs e)
        {
            //cb_Specifiy_Disk.Items.Add("VDI (VirtualBox Disk Image)");
            //cb_Specifiy_Disk.Items.Add("VHD (Virtual Hard Disk)");
            //cb_Specifiy_Disk.Items.Add("VMDK (Virtual Machine Disk)");
            //cb_Specifiy_Disk.Items.Add("HDD (Parallels Hard Disk)");
            //cb_Specifiy_Disk.Items.Add("QCOW (QEMU Copy-On-Write)");
            //cb_Specifiy_Disk.Items.Add("QED (QEMU enhanced disk)");
            cb_Specifiy_Disk.Items.Clear();
            cb_Specifiy_Disk.Items.Add("VDI");
            cb_Specifiy_Disk.Items.Add("VHD");
            cb_Specifiy_Disk.Items.Add("VMDK");
            cb_Specifiy_Disk.Items.Add("HDD");
            cb_Specifiy_Disk.Items.Add("QCOW");
            cb_Specifiy_Disk.Items.Add("QED");
        }

        private void cb_HARD_graphic_controller_Click(object sender, EventArgs e)
        {
            cb_HARD_graphic_controller.Items.Clear();
            cb_HARD_graphic_controller.Items.Add("VMSVGA");

        }

        private void cb_HARD_network_1stnic_Click(object sender, EventArgs e)
        {
            cb_HARD_network_1stnic.Items.Clear();
            cb_HARD_network_1stnic.Items.Add("NAT");
            cb_HARD_network_1stnic.Items.Add("NAT Network");
            cb_HARD_network_1stnic.Items.Add("Bridge Adapter");
            cb_HARD_network_1stnic.Items.Add("Internal Network");
            cb_HARD_network_1stnic.Items.Add("Host-Only Adapter");
            cb_HARD_network_1stnic.Items.Add("Not Connected");
        }

        
    }
}

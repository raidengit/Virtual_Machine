using System.Diagnostics;

namespace Virtual_Machine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmbOsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OS_TYPE_CB();
        }
        private void OS_TYPE_CB()
        {
            cmbOsType.Items.Clear();
            cmbOsType.Items.Add("Microsoft Windows");
            cmbOsType.Items.Add("Linux");
            cmbOsType.Items.Add("Solaris");
            cmbOsType.Items.Add("BSD");
            cmbOsType.Items.Add("IBM OS/2");
            cmbOsType.Items.Add("MAC OS X");
            cmbOsType.Items.Add("Other");
        }



        private void txtOsVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            OS_VERSION_CB();
        }
        string savepath;
        private void OS_VERSION_CB()
        {
            string cbOsversion = cmbOsType.SelectedItem.ToString();

            if (cbOsversion.Equals("Microsoft Windows"))
            {
                WindowsOptionsCB();
            }
            if (cbOsversion.Equals("Linux"))
            {
                LinuxOptionsCB();
            }
        }
        private void WindowsOptionsCB()
        {
            cmbOsVersion.Items.Clear();
            cmbOsVersion.Items.Add("Windows 10 (64-bit)");
            cmbOsVersion.Items.Add("Windows 11 (64-bit)");
            cmbOsVersion.Items.Add("Windows 2022 (64-bit)");
        }
        private void LinuxOptionsCB()
        {
            cmbOsVersion.Items.Clear();
            cmbOsVersion.Items.Add("Ubuntu (64-bit)");
            cmbOsVersion.Items.Add("Antix (64-bit)");
        }

        private void txtVmLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            VMLocation();
        }

        private void VMLocation()
        {
            cmbVmLocation.Items.Clear();
            cmbVmLocation.Items.Add("Select new Location");
            if (savepath != null)
            {
                cmbVmLocation.Text = savepath;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string VMsname = txtMachineName.Text;
            string OSType = cmbOsType.Text;
            string OSVersion = cmbOsVersion.Text;
            string VMLocation = cmbVmLocation.Text;
            string RAM_label = cmbRAM.Text;
            string video = cmbVideo.Text;
            string graphic_Serial = cmbGraphicsController.Text;
            string donwloaded_medium = "antiX-22-net_386-net.iso";
            string network_adapter = cmbNetworkMode.Text;
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

            process1.Dispose();

            if (OSVersion.Equals("Antix (64-bit)"))
            {

                string strCmdText3 = "/C" + "\"C:\\Program Files\\Oracle\\virtualbox\\VBoxManage.exe\"  modifyvm " + VMsname + " --ioapic on";
                string strCmdText4 = "/C" + "\"C:\\Program Files\\Oracle\\virtualbox\\VBoxManage.exe\"  modifyvm " + VMsname + " --memory " + RAM_label + " --vram " + video;
                string strCmdText5 = "/C" + "\"C:\\Program Files\\Oracle\\virtualbox\\VBoxManage.exe\"  modifyvm " + VMsname + " --nic1 " + network_adapter.ToLower();

                string strCmdText6 = "/C" + "\"C:\\Program Files\\Oracle\\virtualbox\\VBoxManage.exe\"  modifyvm " + VMsname + " --graphicscontroller " + graphic_Serial;

                string strCmdText7 = "/C" + "\"C:\\Program Files\\Oracle\\virtualbox\\VBoxManage.exe\"  createmedium disk --filename " + VMLocation + "/" + VMsname + "/" + VMsname + "_DISK." + VM_Format.ToLower() + " --size " + VM_GB + " --format " + VM_Format;

                string strCmdTextAntix = "/C" + " cd " + VMLocation + " && curl.exe --url https://ftp.caliu.cat/pub/distribucions/mxlinux/MX-ISOs/ANTIX/Final/antiX-22/antiX-22-net_386-net.iso --output " + donwloaded_medium;

                string Full_Location = VMLocation + "/" + VMsname + "/" + VMsname + "_DISK." + VM_Format.ToLower();

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
                Process process4 = new Process();
                process4.StartInfo.FileName = @"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe";
                process4.StartInfo.Arguments = $"storagectl {VMsname} --name " + "\"IDE Controller\" --add ide --controller PIIX4";
                process4.StartInfo.UseShellExecute = false;
                process4.StartInfo.RedirectStandardOutput = true;
                process4.Start();
                process4.Dispose();
                Process process5 = new Process();
                process5.StartInfo.FileName = @"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe";
                process5.StartInfo.Arguments = $"storageattach {VMsname} --storagectl " + "\"IDE Controller\" --port 1 --device 0 --type dvddrive --medium " + VMLocation + "\\" + donwloaded_medium;
                process5.StartInfo.UseShellExecute = false;
                process5.StartInfo.RedirectStandardOutput = true;
                process5.Start();
                process5.Dispose();
            }


            //private void btnCreate_Click(object sender, EventArgs e)
            //{
            //    string machineName = txtMachineName.Text;
            //    string osType = cmbOsType.SelectedItem.ToString();
            //    string osVersion = txtOsVersion.Text;
            //    string vmLocation = txtVmLocation.Text;
            //    string vdiLocation = txtVdiLocation.Text;
            //    string isoLocation = txtIsoLocation.Text;
            //    int ram = (int)numRam.Value;
            //    int coreProcessors = (int)numCores.Value;
            //    int videoMemory = (int)numVideoMemory.Value;
            //    string graphicsController = cmbGraphicsController.SelectedItem.ToString();
            //    string networkMode = cmbNetworkMode.SelectedItem.ToString();

            //    // Construct the command string with the appropriate arguments
            //    string command = $"createvm --name {machineName} --ostype {osType} --register --basefolder \"{vmLocation}\"";
            //    string output = ExecuteCommand(command);

            //    // Check for errors in the output
            //    if (output.Contains("error"))
            //    {
            //        MessageBox.Show("An error occurred while creating the virtual machine:\n" + output);
            //        return;
            //    }

            //    // Configure the virtual machine with the desired settings
            //    command = $"modifyvm {machineName} --memory {ram} --cpus {coreProcessors} --vram {videoMemory} --graphicscontroller {graphicsController}";
            //    output = ExecuteCommand(command);

            //    // Check for errors in the output
            //    if (output.Contains("error"))
            //    {
            //        MessageBox.Show("An error occurred while configuring the virtual machine:\n" + output);
            //        return;
            //    }

            //    // Attach the virtual hard drive to the virtual machine
            //    command = $"storagectl {machineName} --name \"SATA Controller\" --add sata --controller IntelAHCI --portcount 1";
            //    output = ExecuteCommand(command);

            //    // Check for errors in the output
            //    if (output.Contains("error"))
            //    {
            //        MessageBox.Show("An error occurred while configuring the virtual machine storage:\n" + output);
            //        return;
            //    }

            //    command = $"storageattach {machineName} --storagectl \"SATA Controller\" --port 0 --device 0 --type hdd --medium \"{vdiLocation}\"";
            //    output = ExecuteCommand(command);

            //    // Check for errors in the output
            //    if (output.Contains("error"))
            //    {
            //        MessageBox.Show("An error occurred while attaching the virtual hard drive:\n" + output);
            //        return;
            //    }

            //    // Attach the installation ISO to the virtual machine
            //    if (!string.IsNullOrEmpty(isoLocation))
            //    {
            //        command = $"storageattach {machineName} --storagectl \"IDE Controller\" --port 0 --device 0 --type dvddrive --medium \"{isoLocation}\"";
            //        output = ExecuteCommand(command);

            //        // Check for errors in the output
            //        if (output.Contains("error"))
            //        {
            //            MessageBox.Show("An error occurred while attaching the installation ISO:\n" + output);
            //            return;
            //        }
            //    }

            //    // Configure the network adapter
            //    command = $"modifyvm {machineName} --nic1 {networkMode}";
            //    output = ExecuteCommand(command);

            //    // Check for errors in the output
            //    if (output.Contains("error"))
            //    {
            //        MessageBox.Show("An error occurred while configuring the network adapter:\n" + output);
            //        return;
            //    }

            //    MessageBox.Show("Virtual machine created successfully.");
            //}
            //private string ExecuteCommand(string command)
            //{
            //    ProcessStartInfo startInfo = new ProcessStartInfo();
            //    startInfo.FileName = "VBoxManage.exe";
            //    startInfo.Arguments = command;
            //    startInfo.RedirectStandardOutput = true;
            //    startInfo.UseShellExecute = false;
            //    startInfo.CreateNoWindow = true;

            //    using (Process process = new Process())
            //    {
            //        process.StartInfo = startInfo;
            //        process.Start();

            //        string output = process.StandardOutput.ReadToEnd();
            //        process.WaitForExit();

            //        return output;
            //    }
            //}

        }

        private void cmbGraphicsController_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbGraphicsController.Items.Clear();
            cmbGraphicsController.Items.Add("VMSVGA");
        }

        private void cmbNetworkMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbNetworkMode.Items.Clear();
            cmbNetworkMode.Items.Add("NAT");
            cmbNetworkMode.Items.Add("NAT Network");
            cmbNetworkMode.Items.Add("Bridge Adapter");
            cmbNetworkMode.Items.Add("Internal Network");
            cmbNetworkMode.Items.Add("Host-Only Adapter");
            cmbNetworkMode.Items.Add("Not Connected");
        }
    }
}
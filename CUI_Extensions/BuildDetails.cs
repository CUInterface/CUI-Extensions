using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Build.Execution;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using Microsoft.Build.Logging;
using System.IO;
using System.Diagnostics;

namespace NugetBuilder
{
    public partial class BuildDetails : Form
    {
        public BuildDetails(string projectPath, string configurationName)
        {
            InitializeComponent();

            cmbBuild.Items.Add("Debug");
            cmbBuild.Items.Add("InHouse");
            cmbBuild.Items.Add("Release");

            if (cmbBuild.Items.Contains(configurationName))
            {
                cmbBuild.SelectedItem = configurationName;
            }

            lblProjectLocation.Text = projectPath;

            //Custom rule for DPServiceCore
            if (projectPath.IndexOf("DPServiceCore",0, StringComparison.CurrentCultureIgnoreCase) > 0)
            {
                //if (cmbBuild.SelectedItem.ToString() == "Release")
                //{
                //    txtDPCoreDep.Text = "InHouse-DPCore";
                //}
                //else
                //{
                //    txtDPCoreDep.Text = "Debug-DPCore";
                //}

                MessageBox.Show("Don't forget to make sure your project is referencing the proper DPCore before publishing NuGet Package!");
            }
            else
            {
                //txtDPCoreDep.Enabled = false;
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(lblProjectLocation.Text);

            string sProjectPath = fi.Directory.FullName;
            string sProjectFileName = fi.Name;
            string sBuildType = this.cmbBuild.SelectedItem.ToString();
            string sBuildDirectory = String.Format("{0}{1}", @"\\cuiserver\DataShare\DP System\Installs\NuGet Packages\", sBuildType);
            string sVersion = string.Empty;
            string sDependency = string.Empty;

            //InHouse-DPCore
            if (!string.IsNullOrEmpty(txtVersion.Text))
            {
                sVersion = string.Format(" -version {0}", txtVersion.Text);
            }

            //if (!string.IsNullOrEmpty(txtDPCoreDep.Text))
            //{
            //    sDependency = string.Format(";DPCoreDependency={0}", txtDPCoreDep.Text);
            //}

            if (fi.Directory.GetFiles("*.nuspec").Length > 0)
            {
                var process = new Process();
                var startinfo = new ProcessStartInfo();
                startinfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                startinfo.FileName = "cmd.exe";
                startinfo.RedirectStandardInput = true;
                startinfo.UseShellExecute = false;

                process.Exited += Process_Exited;
                process.EnableRaisingEvents = true;
                process.StartInfo = startinfo;
                process.Start();

                using (StreamWriter sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine(string.Format("cd {0}", sProjectPath));
                        sw.WriteLine(string.Format("copy /Y \"{0}\" \"{1}\"", @"\\cuiserver\/DataShare/\DP System\Installs\NuGet Packages\nuget.exe", sProjectPath));
                        sw.WriteLine(string.Format("nuget.exe pack {0} -Prop Configuration={1};BuildID={1}{2}{3}", sProjectFileName, sBuildType, sDependency, sVersion));
                        sw.WriteLine(string.Format("move /Y *.nupkg \"{0}\"", sBuildDirectory));
                        sw.WriteLine("del nuget.exe");
                    }
                }
            }
            else
            {
                MessageBox.Show("Cannot find the .nuspec file for this project.");
            }        
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            //TODO - do a check to see if the file exists
            MessageBox.Show("Nuget package created.");
        }
    }
}

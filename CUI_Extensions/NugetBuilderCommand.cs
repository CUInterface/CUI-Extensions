//------------------------------------------------------------------------------
// <copyright file="FirstCommand.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System.Diagnostics;
using System.Windows;
using EnvDTE;

namespace NugetBuilder
{
    internal sealed class BuildCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int cmdShowBuildDetails = 0x1010;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("e3ea90e3-fd18-40b9-8c0b-fb82dadfc831");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private BuildCommand(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, cmdShowBuildDetails);
                var menuItem = new MenuCommand(this.ShowBuildDetails, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static BuildCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {
            Instance = new BuildCommand(package);
        }
        private void ShowBuildDetails(object sender, EventArgs e)
        {            
            var objServiceContainer = ServiceProvider as IServiceContainer;
            var objDTE = objServiceContainer.GetService(typeof(SDTE)) as DTE;
            var objConfigManager = objDTE.Solution.Projects.Item(1).ConfigurationManager;
            var sConfigurationName = objConfigManager.ActiveConfiguration.ConfigurationName;
            var sProjectPath = string.Empty;

            if (string.IsNullOrEmpty(sConfigurationName))
            {
                MessageBox.Show("Cannot determine configuration name (e.g. Debug/InHouse/Release)");

                return;
            }

            System.Array projs = default(System.Array);
            Project proj = default(Project);
            projs = (System.Array)objDTE.ActiveSolutionProjects;
           
            if (projs.Length > 0)
            {
                proj = (EnvDTE.Project)projs.GetValue(0);
                sProjectPath = proj.FullName;
            }

            if (string.IsNullOrEmpty(sProjectPath))
            {
                MessageBox.Show("Cannot determine the path to this project.");

                return;
            }

            var frmBuildDetails = new BuildDetails(sProjectPath, sConfigurationName);
            frmBuildDetails.ShowDialog();
        }
    }
    //internal sealed class InHouseCommand
    //{
    //    /// <summary>
    //    /// Command ID.
    //    /// </summary>
    //    public const int cmdidInHouse = 0x2020;

    //    /// <summary>
    //    /// Command menu group (command set GUID).
    //    /// </summary>
    //    public static readonly Guid CommandSet = new Guid("e3ea90e3-fd18-40b9-8c0b-fb82dadfc831");

    //    /// <summary>
    //    /// VS Package that provides this command, not null.
    //    /// </summary>
    //    private readonly Package package;

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="InHouseCommand"/> class.
    //    /// Adds our command handlers for menu (commands must exist in the command table file)
    //    /// </summary>
    //    /// <param name="package">Owner package, not null.</param>
    //    private InHouseCommand(Package package)
    //    {
    //        if (package == null)
    //        {
    //            throw new ArgumentNullException("package");
    //        }

    //        this.package = package;

    //        OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
    //        if (commandService != null)
    //        {
    //            var menuCommandID = new CommandID(CommandSet, cmdidInHouse);
    //            var menuItem = new MenuCommand(this.StartNotepad, menuCommandID);
    //            commandService.AddCommand(menuItem);
    //        }
    //    }

    //    /// <summary>
    //    /// Gets the instance of the command.
    //    /// </summary>
    //    public static InHouseCommand Instance
    //    {
    //        get;
    //        private set;
    //    }

    //    /// <summary>
    //    /// Gets the service provider from the owner package.
    //    /// </summary>
    //    private IServiceProvider ServiceProvider
    //    {
    //        get
    //        {
    //            return this.package;
    //        }
    //    }

    //    /// <summary>
    //    /// Initializes the singleton instance of the command.
    //    /// </summary>
    //    /// <param name="package">Owner package, not null.</param>
    //    public static void Initialize(Package package)
    //    {
    //        Instance = new InHouseCommand(package);
    //    }
    //    private void StartNotepad(object sender, EventArgs e)
    //    {
    //        string cmd = "devenv \"C:\\Users\\tremp\\Documents\\Visual Studio 2015\\Projects\\Test\\Test.sln\" /build Debug /project \"Test\\Test.csproj\" /projectconfig Debug";

    //        //IVsSolution x;

    //        //string s1;
    //        //string s2;
    //        //string s3;

    //        //x.GetSolutionInfo(out s1, out s2, out s3);

    //        System.Diagnostics.ProcessStartInfo PR = new System.Diagnostics.ProcessStartInfo("cmd", cmd);
    //    }
    //}
    //internal sealed class DebugCommand
    //{
    //    /// <summary>
    //    /// Command ID.
    //    /// </summary>
    //    public const int cmdidDebug = 0x2030;

    //    /// <summary>
    //    /// Command menu group (command set GUID).
    //    /// </summary>
    //    public static readonly Guid CommandSet = new Guid("e3ea90e3-fd18-40b9-8c0b-fb82dadfc831");

    //    /// <summary>
    //    /// VS Package that provides this command, not null.
    //    /// </summary>
    //    private readonly Package package;

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="DebugCommand"/> class.
    //    /// Adds our command handlers for menu (commands must exist in the command table file)
    //    /// </summary>
    //    /// <param name="package">Owner package, not null.</param>
    //    private DebugCommand(Package package)
    //    {
    //        if (package == null)
    //        {
    //            throw new ArgumentNullException("package");
    //        }

    //        this.package = package;

    //        OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
    //        if (commandService != null)
    //        {
    //            var menuCommandID = new CommandID(CommandSet, cmdidDebug);
    //            var menuItem = new MenuCommand(this.StartNotepad, menuCommandID);
    //            commandService.AddCommand(menuItem);
    //        }
    //    }

    //    /// <summary>
    //    /// Gets the instance of the command.
    //    /// </summary>
    //    public static DebugCommand Instance
    //    {
    //        get;
    //        private set;
    //    }

    //    /// <summary>
    //    /// Gets the service provider from the owner package.
    //    /// </summary>
    //    private IServiceProvider ServiceProvider
    //    {
    //        get
    //        {
    //            return this.package;
    //        }
    //    }

    //    /// <summary>
    //    /// Initializes the singleton instance of the command.
    //    /// </summary>
    //    /// <param name="package">Owner package, not null.</param>
    //    public static void Initialize(Package package)
    //    {
    //        Instance = new DebugCommand(package);
    //    }
    //    private void StartNotepad(object sender, EventArgs e)
    //    {
    //        //Class1 testDialog = new Class1();       
    //        //testDialog.ShowModal();

    //        var frmBuildDetails = new BuildDetails();

    //        frmBuildDetails.ShowDialog();


    //        //Process proc = new Process();
    //        //proc.StartInfo.FileName = "notepad.exe";
    //        //proc.Start();
    //    }
    //}
}

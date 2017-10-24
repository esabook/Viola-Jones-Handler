namespace ViolaJonesHandler
{
	partial class ProjectInstaller
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.serviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
			this.serviceInstaller = new System.ServiceProcess.ServiceInstaller();
			this.mainService = new ViolaJonesHandler.Service1();
			// 
			// serviceProcessInstaller
			// 
			this.serviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.serviceProcessInstaller.Password = null;
			this.serviceProcessInstaller.Username = null;
			// 
			// serviceInstaller
			// 
			this.serviceInstaller.Description = "Service untuk mempercepat proses mendeteksi event  system";
			this.serviceInstaller.DisplayName = "ViolaJonesHandler";
			this.serviceInstaller.ServiceName = "ViolaJonesHandler";
			this.serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
			// 
			// mainService
			// 
			this.mainService.CanHandlePowerEvent = true;
			this.mainService.CanHandleSessionChangeEvent = true;
			this.mainService.CanPauseAndContinue = true;
			this.mainService.CanShutdown = true;
			this.mainService.ExitCode = 0;
			this.mainService.ServiceName = "ViolaJonesHandler";
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller,
            this.serviceInstaller});

		}

		#endregion

		private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller;
		private System.ServiceProcess.ServiceInstaller serviceInstaller;
		private Service1 mainService;
	}
}
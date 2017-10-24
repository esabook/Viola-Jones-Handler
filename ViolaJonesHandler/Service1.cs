using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace ViolaJonesHandler
{
	public partial class Service1 : ServiceBase
	{
		string wlogon = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon";
		string AutoLogonA = "AutoAdminLogon";
		string userSwitch = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Authentication\\LogonUI\\UserSwitch";
		string userSwitchV="Enabled";
		string KunciViolaJonesInfo = "KunciViolaJonesInfo";


		public Service1()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			setRegistry(wlogon, KunciViolaJonesInfo, "SLogon", RegistryValueKind.String,modeSetRegistry.ubah);
		}

		protected override void OnStop(){
			setRegistry(wlogon, KunciViolaJonesInfo, "", RegistryValueKind.String, modeSetRegistry.Hapus);
		}


		protected static void setRegistry(string Registry, string value, string data, RegistryValueKind vk)//set registry
		{
			RegistryKey registry;
			if (Environment.Is64BitOperatingSystem)
			{
				registry = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
			}
			else
			{
				registry = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
			}
			try
			{
				RegistryKey regk = registry.CreateSubKey(Registry);
				regk.SetValue(value, data, vk);
				regk.Close();
			}
			catch { }

		}
		protected override void OnSessionChange(SessionChangeDescription changeDescription)
		{
			
			switch (changeDescription.Reason)
			{
				case SessionChangeReason.ConsoleConnect:
					setRegistry(wlogon, KunciViolaJonesInfo, "", RegistryValueKind.String, modeSetRegistry.ubah);
					break;
				case SessionChangeReason.ConsoleDisconnect:
					setRegistry(wlogon, KunciViolaJonesInfo, "", RegistryValueKind.String, modeSetRegistry.ubah);
					break;
				case SessionChangeReason.RemoteConnect:
					setRegistry(wlogon, KunciViolaJonesInfo, "", RegistryValueKind.String, modeSetRegistry.ubah);
					break;
				case SessionChangeReason.RemoteDisconnect:
					setRegistry(wlogon, KunciViolaJonesInfo, "", RegistryValueKind.String, modeSetRegistry.ubah);
					break;
				case SessionChangeReason.SessionLock:
					setRegistry(wlogon, KunciViolaJonesInfo, "Lock", RegistryValueKind.String, modeSetRegistry.ubah);
					break;
				case SessionChangeReason.SessionLogoff:
					setRegistry(wlogon, KunciViolaJonesInfo, "UnlocK", RegistryValueKind.String, modeSetRegistry.ubah);
					break;
				case SessionChangeReason.SessionLogon:
					setRegistry(wlogon, KunciViolaJonesInfo, "SLogon", RegistryValueKind.String, modeSetRegistry.ubah);
					break;
				case SessionChangeReason.SessionRemoteControl:
					setRegistry(wlogon, KunciViolaJonesInfo, "", RegistryValueKind.String, modeSetRegistry.ubah);
					break;
				case SessionChangeReason.SessionUnlock:
					setRegistry(wlogon, KunciViolaJonesInfo, "", RegistryValueKind.String, modeSetRegistry.ubah);
					break;
				default:
					break;
			}
		}
		protected override void OnShutdown()
		{
			setRegistry(wlogon, AutoLogonA, "0", RegistryValueKind.DWord, modeSetRegistry.ubah);
			setRegistry(wlogon, KunciViolaJonesInfo, "Lock", RegistryValueKind.String, modeSetRegistry.ubah);
			setRegistry(userSwitch, userSwitchV, "1", RegistryValueKind.DWord, modeSetRegistry.ubah);
		}




		public enum modeSetRegistry : int { 
			Hapus=0, ubah=1
		} 
		public static void setRegistry(string Registry, string value, string data, RegistryValueKind vk, modeSetRegistry mode)//set registry
		{
			RegistryKey registry;
			if (Environment.Is64BitOperatingSystem)
			{
				registry = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
			}
			else
			{
				registry = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
			}
			try
			{
				RegistryKey regk = registry.CreateSubKey(Registry);
				switch (mode)
				{
					case modeSetRegistry.ubah:
						{
							regk.SetValue(value, data, vk);
							break;
						}
					case modeSetRegistry.Hapus:
						{
							regk.DeleteValue(value);
							break;
						}
					default:
						break;
				}
				regk.Close();
			}
			catch { }

		}
	}
}

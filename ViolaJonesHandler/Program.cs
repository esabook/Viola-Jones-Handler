using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;

namespace ViolaJonesHandler
{
	static class Program
	{
		/// <summary>
		/// This is main entry point for the service of naming with <code>ViolaJonesHandler</code>.
		/// Using argument <code>/i</code> to installing service; argument <code>/u</code> for unnistalling service.
		/// </summary>
		static void Main(String[] args)
		{
			if (args.Length > 0)
			{
				switch (args[0])
				{

					case "/i": /// installing
						{
							try
							{
								ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
							}
							catch { }
							break;
						}
					case "/u": ///uninstalling
						{
							try
							{
								ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });

							}
							catch { }
							
							break;
						}
					default:
						break;
				}
			}
			else
			{
				/// try running up the service
				ServiceBase[] ServicesToRun;
				ServicesToRun = new ServiceBase[]  {
					new Service1()
				};
				ServiceBase.Run(ServicesToRun);
			}
		}
	}
}

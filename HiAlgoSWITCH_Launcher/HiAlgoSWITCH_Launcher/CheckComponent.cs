/*
    HiAlgoSWITCH_Launcher: A program to launch a game with HiAlgoSWITCH activated and after running, close it.

    Copyright (C) 2016  Lucas Cota (BrasileiroGamer)
    lucasbrunocota@live.com
    <http://www.github.com/BrasileiroGamer/>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

/*
 *	CheckComponent.cs
 *	Author: Lucas Cota (BrasileiroGamer)
 *	Description: HiAlgoSWITCH_Launcher Component Checker.
 *  Date: 2016-07-28
 */

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HiAlgoSWITCH_Launcher
{
	class CheckComponent
	{
		public static void VerifySettings()
		{
			if (!File.Exists(GlobalSettings.iniFileName) || GlobalSettings.iniFirstRun == "Enabled" || File.ReadAllLines(GlobalSettings.iniFileName).Length < 6 || new FileInfo(GlobalSettings.iniFileName).Length < 109)
			{
				MessageBoxManager.No = "Exit";
				MessageBoxManager.Yes = "Continue";

				MessageBoxManager.Register();
				DialogResult dialogWizard = MessageBox.Show
				(
					"Well, it looks like it's your first configuration or some part of the configuration file is missing." + Environment.NewLine + Environment.NewLine +
					"Click 'Continue' to continue the setup wizard." + Environment.NewLine +
					"Click 'Exit' to exit the program.",
					"HiAlgoSWITCH_Launcher Wizard", MessageBoxButtons.YesNo, MessageBoxIcon.Information
				);
				MessageBoxManager.Unregister();

				if (dialogWizard == DialogResult.Yes)
				{
					dialogWizard = MessageBox.Show
					(
						"Please click 'OK' and select the HiAlgoSWITCH executable on your machine.",
						"HiAlgoSWITCH_Launcher Wizard", MessageBoxButtons.OKCancel, MessageBoxIcon.Information
					);

					if (dialogWizard == DialogResult.OK)
					{
						Settings.FirstRun();
					}
					else
					{
						About.AboutBox();
						Environment.Exit(1);
					}
				}
				else
				{
					About.AboutBox();
					Environment.Exit(1);
				}
			}
			Settings.ReadSettings();
		}

		public static void VerifyLogCleaner()
		{
			if (GlobalSettings.iniClearHialgoLogs == "Enabled")
			{
				try
				{
					var logFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\HiAlgo";
					var logDelete = Directory.EnumerateFiles(logFolder, "*.*", SearchOption.AllDirectories).Where
					(
						logFile => logFile.EndsWith(".log") || logFile.Contains("cache")
					);

					foreach (var logFile in logDelete)
					{
						File.Delete(logFile);
					}
				}
				catch{ }
			}
		}
	}
}

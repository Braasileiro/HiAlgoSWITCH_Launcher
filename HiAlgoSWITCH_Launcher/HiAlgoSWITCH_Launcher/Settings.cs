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
 *	Settings.cs
 *	Author: Lucas Cota (BrasileiroGamer)
 *	Description: HiAlgoSWITCH_Launcher Settings.
 *  Date: 2016-07-28
 */

using System;
using System.IO;
using System.Windows.Forms;

namespace HiAlgoSWITCH_Launcher
{
	class Settings
	{
		public static void FirstRun()
		{
			// Delete Current File
			File.Delete(GlobalSettings.iniFileName);

			// ProgramPath
			var dialogProgramPath = new OpenFileDialog();
			dialogProgramPath.Filter = "HiAlgoSWITCH.exe|HiAlgoSWITCH.exe";
			dialogProgramPath.FilterIndex = 1;

			if (dialogProgramPath.ShowDialog() == DialogResult.OK)
			{
				GlobalSettings.iniProgramPath = dialogProgramPath.FileName;
			}
			else
			{
				About.AboutBox();
				Environment.Exit(1);
			}

			// GamePath
			var dialogGamePath = new OpenFileDialog();
			dialogGamePath.Filter = "Game Executable (*.exe)|*.exe";
			dialogGamePath.FilterIndex = 1;

			if (dialogGamePath.ShowDialog() == DialogResult.OK)
			{
				GlobalSettings.iniGamePath = dialogGamePath.FileName;
			}
			else
			{
				About.AboutBox();
				Environment.Exit(1);
			}

			// AboutBox Wizard
			MessageBoxManager.Yes = "Keep Defaults";
			MessageBoxManager.No = "Enable About";

			MessageBoxManager.Register();
			DialogResult dialogAbout = MessageBox.Show
			(
				"Enable AboutBox?" + Environment.NewLine + Environment.NewLine +
				"'AboutBox' is a message box with information about the program that will appear every time the program ends." + Environment.NewLine +
				"You can change this setting manually writing 'Disabled/Enabled' in 'AboutBox' field in the configuration file 'HiAlgoSWITCH_Launcher.ini'." + Environment.NewLine + Environment.NewLine +
				"The default setting is 'Disabled'.",
				"HiAlgoSWITCH_Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Information
			);
			MessageBoxManager.Unregister();

			if(dialogAbout == DialogResult.Yes)
			{
				GlobalSettings.iniAboutBox = "Disabled";
			}
			else
			{
				GlobalSettings.iniAboutBox = "Enabled";
			}

			// Writing Settings
			GlobalSettings.iniHialgoLauncher.Write("FirstRun", "Disabled");
			GlobalSettings.iniHialgoLauncher.Write("AboutBox", GlobalSettings.iniAboutBox);
			GlobalSettings.iniHialgoLauncher.Write("GamePath", GlobalSettings.iniGamePath);
			GlobalSettings.iniHialgoLauncher.Write("ProgramPath", GlobalSettings.iniProgramPath);
			GlobalSettings.iniHialgoLauncher.Write("ClearHialgoLogs", "Enabled");
		}

		public static void ReadSettings()
		{
			GlobalSettings.iniFirstRun = GlobalSettings.iniHialgoLauncher.Read("FirstRun");
			GlobalSettings.iniAboutBox = GlobalSettings.iniHialgoLauncher.Read("AboutBox");
			GlobalSettings.iniGamePath = GlobalSettings.iniHialgoLauncher.Read("GamePath");
			GlobalSettings.iniProgramPath = GlobalSettings.iniHialgoLauncher.Read("ProgramPath");
			GlobalSettings.iniClearHialgoLogs = GlobalSettings.iniHialgoLauncher.Read("ClearHialgoLogs");
		}
	}
}

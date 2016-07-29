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
 *	Core.Settings.cs
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
			File.Delete(Global.iniFileName);

			// ProgramPath
			var dialogProgramPath = new OpenFileDialog();
			dialogProgramPath.Filter = "HiAlgoSWITCH.exe|HiAlgoSWITCH.exe";
			dialogProgramPath.FilterIndex = 1;

			if (dialogProgramPath.ShowDialog() == DialogResult.OK)
			{
				Global.iniProgramPath = dialogProgramPath.FileName;
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
				Global.iniGamePath = dialogGamePath.FileName;
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
				Global.iniAboutBox = "Disabled";
			}
			else
			{
				Global.iniAboutBox = "Enabled";
			}

			// Writing Settings
			Global.iniHialgoLauncher.Write("FirstRun", "Disabled");
			Global.iniHialgoLauncher.Write("AboutBox", Global.iniAboutBox);
			Global.iniHialgoLauncher.Write("GamePath", Global.iniGamePath);
			Global.iniHialgoLauncher.Write("ProgramPath", Global.iniProgramPath);
			Global.iniHialgoLauncher.Write("ClearHialgoLogs", "Enabled");
		}

		public static void ReadSettings()
		{
			Global.iniFirstRun = Global.iniHialgoLauncher.Read("FirstRun");
			Global.iniAboutBox = Global.iniHialgoLauncher.Read("AboutBox");
			Global.iniGamePath = Global.iniHialgoLauncher.Read("GamePath");
			Global.iniProgramPath = Global.iniHialgoLauncher.Read("ProgramPath");
			Global.iniClearHialgoLogs = Global.iniHialgoLauncher.Read("ClearHialgoLogs");
		}
	}
}

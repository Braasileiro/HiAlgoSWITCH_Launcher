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
 *	GlobalSettings.cs
 *	Author: Lucas Cota (BrasileiroGamer)
 *	Description: HiAlgoSWITCH_Launcher Global Variables.
 *  Date: 2016-07-28
 */

namespace HiAlgoSWITCH_Launcher
{
	class GlobalSettings
	{
		public static IniParser iniHialgoLauncher = new IniParser(iniFileName); // Settings File

		public static string iniFileName = "HiAlgoSWITCH_Launcher.ini"; // Settings Filename
		public static string iniFirstRun = iniHialgoLauncher.Read("FirstRun"); // FirstRun Control
		public static string iniAboutBox = iniHialgoLauncher.Read("AboutBox"); // AboutBox Control
		public static string iniGamePath = iniHialgoLauncher.Read("GamePath"); // GamePath Name
		public static string iniProgramPath = iniHialgoLauncher.Read("ProgramPath"); // ProgramPath Name
		public static string iniClearHialgoLogs = iniHialgoLauncher.Read("ClearHialgoLogs"); // ClearHialgoLogs Control
	}
}

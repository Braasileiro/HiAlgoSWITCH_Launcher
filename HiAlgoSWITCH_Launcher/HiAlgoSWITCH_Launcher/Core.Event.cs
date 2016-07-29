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
 *	Core.Event.cs
 *	Author: Lucas Cota (BrasileiroGamer)
 *	Description: HiAlgoSWITCH_Launcher Events.
 *  Date: 2016-07-28
 */

using System;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HiAlgoSWITCH_Launcher
{
	class Event
	{
		// SetForegroundWindow Function
		[DllImport("user32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		// ShowWindow Function
		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr handle, int nCmdShow);

		// FindWindow Function
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		public static void StartGame()
		{
			// Start Executables
			Process.Start(Global.iniProgramPath);
			Process.Start(Global.iniGamePath).WaitForExit();

			// HiAlgoSWITCH Injector Window Handle
			IntPtr hWnd = FindWindow("HiAlgo Switch Injector", null);

			// Find Counter
			var hWndFindCount = 0;

			while(hWnd == null && hWndFindCount < 10)
			{
				Thread.Sleep(1000);
				hWnd = FindWindow("HiAlgo Switch Injector", null);
				hWndFindCount++;
			}

			if (hWnd == null)
			{
				ProcessKiller.Kill("HiAlgoSWITCH");

				MessageBox.Show
				(
					"Game not started!" + Environment.NewLine +
					"Try close and reopen the game, it does not work, make sure it is working properly." + Environment.NewLine + Environment.NewLine +
					"The application will be closed.",
					"HiAlgoSWITCH_Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error
				);
				Environment.Exit(1);
			}
			else
			{
				ShowWindow(hWnd, 9);
				SetForegroundWindow(hWnd);
			}

			// Killing HiAlgoSWITCH
			Thread.Sleep(5000);
			ProcessKiller.Kill("HiAlgoSWITCH");

			// Verify AboutBox
			if (Global.iniAboutBox == "Enabled")
			{
				About.AboutBox();
			}

			// Exit Program
			Environment.Exit(0);
		}
	}
}

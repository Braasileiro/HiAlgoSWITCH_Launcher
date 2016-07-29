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
 *	Core.About.cs
 *	Author: Lucas Cota (BrasileiroGamer)
 *	Description: HiAlgoSWITCH_Launcher About Informations.
 *  Date: 2016-07-28
 */

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace HiAlgoSWITCH_Launcher
{
	class About
	{
		public static void AboutBox()
		{
			MessageBoxManager.Yes = "Exit";
			MessageBoxManager.No = "GitHub";
			MessageBoxManager.Cancel = "Check Updates";

			MessageBoxManager.Register();
			DialogResult dialogAbout = MessageBox.Show
			(
				"Thank you for using the program!" + Environment.NewLine + Environment.NewLine +
				"Author: Lucas Cota (BrasileiroGamer)" + Environment.NewLine +
				"E-mail: lucasbrunocota@live.com" + Environment.NewLine +
				"Language: C#" + Environment.NewLine +
				"Version: 2016.1" + Environment.NewLine +
				".NET Framework: 4.6" + Environment.NewLine + Environment.NewLine +
				"Enhanced error check coming soon.",
				"About HiAlgoSWITCH_Launcher", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information
			);
			MessageBoxManager.Unregister();

			if(dialogAbout == DialogResult.No)
			{
				Process.Start("https://github.com/BrasileiroGamer");
			}

			if (dialogAbout == DialogResult.Cancel)
			{
				Process.Start("https://github.com/BrasileiroGamer/HiAlgoSWITCH_Launcher/releases");
			}
		}
	}
}

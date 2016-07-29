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
 *	Util.ProcessKiller.cs
 *	Author: Lucas Cota (BrasileiroGamer)
 *  Description: Simple Process Killer.
 *	Date: 2016-07-29
 */

using System.Diagnostics;

namespace HiAlgoSWITCH_Launcher
{
	class ProcessKiller
	{
		public static void Kill(string processSearch)
		{
			foreach (var processName in Process.GetProcessesByName(processSearch))
			{
				processName.Kill();
			}
		}
	}
}

# HiAlgoSWITCH_Launcher
A program to launch a game with HiAlgoSWITCH activated and after running, close it.

My second program in C# and second firm contact with object-oriented programming. Hehehehe'

The program basically works as a launcher for HiAlgo SWITCH. Instead of opening the HiAlgo and then open the game, the program does everything automatically.

Originally created this program to use with Resident Evil 0 HD Remaster, because I need to use the HiAlgoSWITCH with the game, but as a utility, I decided to use code in general.

My PC is not that great and the internal resolution of the game (Resident Evil HD Remaster 0) is high (1920x1440), so I can not reach 60FPS in the game. #SadFace

While the staff did not discover how to change the internal resolution of this game, that's the way. I am studying how to inject hooks in Direct3D 9 and see if I can change the internal resolution of the game. Any progress'll let here in the README.

# Installing
The program has no installer, just open the executable "HiAlgoSWITCH_Launcher.exe" and follow the instructions.

NOTE: If the game is running in administrator mode, the program should also be started in administrator mode.

# Requeriments
* Windows 7 or higher
* Microsoft .NET Framework 4.6
* [HiAlgoSWITCH installed] (http://www.hialgo.com/Downloads.html)
* Any DirectX 9 game that you want to use.

# Usage
The program has a wizard of first use, it first will ask the executable program and then the executable of the game, quite simple.

After the game be released in the HiAlgo SWITCH screen click 'YES, PLEASE' to enable injector or 'NO, THANK YOU' to not activate.

# Notes
* Recommended to put the program in the game folder. If you need to create another launcher, simply copy the executable 'HiAlgoSWITCH_Launcher.exe' to the desired folder, so the attending of first use appears to the new game configuration. You can also create a launcher shortcut if desired (recommended if you are using the tool for various games).

* You can also create symbolic links (hard links) of 'HiAlgoSWITCH_Launcher.exe' file to the desired folder, so you can avoid duplication of files, although the program is very small (32,768 bytes). 

* If you have made the wrong configuration, the value of the seven 'FirstRun' to 'Enabled' in the 'HiAlgoSWITCH_Launcher.ini' file and open the program to create a new configuration file or simply delete the file. A better error checking out soon.

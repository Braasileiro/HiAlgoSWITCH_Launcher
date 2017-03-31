using System;

namespace HiAlgoSWITCH_Launcher
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			CheckComponent.VerifySettings();

			CheckComponent.VerifyLogCleaner();

			GameEvent.StartGame();
		}
	}
}

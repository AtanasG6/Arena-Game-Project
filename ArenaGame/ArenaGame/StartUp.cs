using ArenaGame.Core;
using ArenaGame.Core.Contracts;

public class StartUp
{
	public static void Main()
	{
		IEngine engine = new Engine();
		engine.Run();
	}
}

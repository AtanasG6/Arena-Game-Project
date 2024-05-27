using System;
using ArenaGame.IO.Contracts;
using ArenaGame.Utilities;

namespace ArenaGame.IO
{
	public class Writer : IWriter
	{
		public void Write(string message)
		{
			Console.Write(message);
		}

		public void WriteLine(string message)
		{
			Console.WriteLine(message);
		}

		public void WriteLine(string message, OutputColor color)
		{
			var originalColor = Console.ForegroundColor;
			Console.ForegroundColor = ConvertToConsoleColor(color);
			Console.WriteLine(message);
			Console.ForegroundColor = originalColor;
		}

		private ConsoleColor ConvertToConsoleColor(OutputColor color)
		{
			if (color == OutputColor.Red)
			{
				return ConsoleColor.Red;
			}
			else if (color == OutputColor.Green)
			{
				return ConsoleColor.Green;
			}
			else if (color == OutputColor.Yellow)
			{
				return ConsoleColor.Yellow;
			}
			else if (color == OutputColor.Blue)
			{
				return ConsoleColor.Blue;
			}
			else if (color == OutputColor.Magenta)
			{
				return ConsoleColor.Magenta;
			}
			else if (color == OutputColor.Cyan)
			{
				return ConsoleColor.Cyan;
			}
			else if (color == OutputColor.DarkRed)
			{
				return ConsoleColor.DarkRed;
			}
			else if (color == OutputColor.DarkYellow)
			{
				return ConsoleColor.DarkYellow;
			}
			else
			{
				return ConsoleColor.White;
			}
		}
	}
}


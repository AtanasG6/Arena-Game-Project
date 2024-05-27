using System;
using ArenaGame.IO.Contracts;

namespace ArenaGame.IO
{
	public class Reader : IReader
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}
	}
}

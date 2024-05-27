using ArenaGame.Utilities;

namespace ArenaGame.IO.Contracts
{
	public interface IWriter
	{
		void WriteLine(string message);
		void WriteLine(string message, OutputColor color);
		void Write(string message);
	}
}

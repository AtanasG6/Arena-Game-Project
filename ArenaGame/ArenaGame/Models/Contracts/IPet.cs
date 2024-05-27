using ArenaGame.Enums;

namespace ArenaGame.Models.Contracts
{
	public interface IPet
	{
		PetType Type { get; }
		int Effect { get; }
		void Assist(IHero owner, IHero target);
	}
}

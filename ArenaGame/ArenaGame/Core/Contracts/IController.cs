using ArenaGame.Enums;
using ArenaGame.Models;
using ArenaGame.Models.Contracts;

namespace ArenaGame.Core.Contracts
{
	public interface IController
	{
		void CreateHero(string name, HeroType type, double armor, double strength, IWeapon weapon, IPet pet);
		void StartBattle(string attackerName, string defenderName);
		IHero GetHero(string name);
	}
}

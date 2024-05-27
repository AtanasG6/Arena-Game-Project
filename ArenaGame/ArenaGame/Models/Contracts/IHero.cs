using ArenaGame.Models.Contracts;
using System.Collections.Generic;

namespace ArenaGame
{
	public interface IHero
	{
		string Name { get; set; }
		double Armor { get; set; }
		double Strength { get; set; }
		IWeapon Weapon { get; set; }
		int Health { get; set; }
		int Level { get; set; }
		int XP { get; set; }
		int Coins { get; set; }
		IPet Pet { get; set; }
		int FrozenRounds { get; set; }
		int BurningRounds { get; set; }

		void Attack(IHero target);
		double Defend(double damage);
		void GainXP(int amount);
		void GainCoins(int amount);
		void LevelUp();
		void ApplyBurningEffect();
		void RestoreHealth(int amount);
	}
}

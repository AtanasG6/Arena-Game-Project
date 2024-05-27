using ArenaGame.Controllers;
using ArenaGame.IO.Contracts;
using ArenaGame.Models.Contracts;
using ArenaGame.Utilities;
using ArenaGame.Weapons;

namespace ArenaGame.Heroes
{
	public class Knight : Hero
	{
		public Knight(string name, double armor, double strength, IWeapon weapon, IPet pet, IWriter writer, ShopController shopController)
			: base(name, armor, strength, weapon, pet, writer, shopController)
		{
		}

		public override void LevelUp()
		{
			Level++;
			Health += GameConstants.HealthBoostPerLevel + 5;
			Strength += GameConstants.AttackBoostPerLevel + 2;
		}
	}
}

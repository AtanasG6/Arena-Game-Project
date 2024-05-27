using ArenaGame.IO.Contracts;
using ArenaGame.Models.Contracts;
using ArenaGame.Utilities;
using ArenaGame.Weapons;
using System;

namespace ArenaGame.Controllers
{
	public class ShopController
	{
		private readonly IWriter writer;

		public ShopController(IWriter writer)
		{
			this.writer = writer;
		}

		public void BuyRandomWeapon(IHero hero)
		{
			hero.Coins -= GameConstants.CoinsThreshold;

			IWeapon newWeapon;
			int randomWeapon = new Random().Next(7);

			switch (randomWeapon)
			{
				case 0:
					newWeapon = new Sword("Random Sword");
					break;
				case 1:
					newWeapon = new FireWeapon("Random Fire Weapon");
					break;
				case 2:
					newWeapon = new IceWeapon("Random Ice Weapon");
					break;
				case 3:
					newWeapon = new Staff("Random Staff");
					break;
				case 4:
					newWeapon = new Bow("Random Bow");
					break;
				case 5:
					newWeapon = new Dagger("Random Dagger");
					break;
				case 6:
					newWeapon = new BloodRestorationWeapon("Random Healing Wand");
					break;
				default:
					newWeapon = new Sword("Default Sword");
					break;
			}

			hero.Weapon = newWeapon;
			writer.WriteLine(string.Format(OutputMessages.HeroBuysWeapon, hero.Name, newWeapon.Name));
		}

	}
}

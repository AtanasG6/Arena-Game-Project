using System;
using ArenaGame.Enums;
using ArenaGame.Models.Contracts;
using ArenaGame.Utilities;
using ArenaGame.Heroes;
using ArenaGame.IO.Contracts;

namespace ArenaGame.Controllers
{
	public class GameController : IController
	{
		private readonly IRepository<IHero> heroRepository;
		private readonly IWriter writer;
		private readonly ShopController shopController;

		public GameController(IRepository<IHero> heroRepository, IWriter writer, ShopController shopController)
		{
			this.heroRepository = heroRepository;
			this.writer = writer;
			this.shopController = shopController;
		}

		public void CreateHero(string name, HeroType type, double armor, double strength, IWeapon weapon, IPet pet)
		{
			IHero hero;

			switch (type)
			{
				case HeroType.Knight:
					hero = new Knight(name, armor, strength, weapon, pet, writer, shopController);
					break;
				case HeroType.Assassin:
					hero = new Assassin(name, armor, strength, weapon, pet, writer, shopController);
					break;
				case HeroType.Mage:
					hero = new Mage(name, armor, strength, weapon, pet, writer, shopController);
					break;
				case HeroType.Archer:
					hero = new Archer(name, armor, strength, weapon, pet, writer, shopController);
					break;
				default:
					throw new ArgumentException(ExceptionMessages.InvalidHeroType);
			}

			heroRepository.Add(hero);
			writer.WriteLine(string.Format(OutputMessages.HeroCreated, name, type));
		}

		public void StartBattle(string attackerName, string defenderName)
		{
			IHero attacker = heroRepository.FindByName(attackerName);
			IHero defender = heroRepository.FindByName(defenderName);

			if (attacker == null || defender == null)
			{
				throw new ArgumentException(ExceptionMessages.InvalidHeroName);
			}

			IBattle battle = new BattleController(writer, shopController);
			battle.StartBattle(attacker, defender);
		}

		public IHero GetHero(string name)
		{
			return heroRepository.FindByName(name);
		}
	}
}

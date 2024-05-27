using System;
using ArenaGame.IO.Contracts;
using ArenaGame.Models.Contracts;
using ArenaGame.Utilities;

namespace ArenaGame.Controllers
{
	public class BattleController : IBattle
	{
		private readonly IWriter writer;
		private readonly ShopController shopController;

		public BattleController(IWriter writer, ShopController shopController)
		{
			this.writer = writer;
			this.shopController = shopController;
		}

		public void StartBattle(IHero attacker, IHero defender)
		{
			int round = 1;
			while (attacker.Health > 0 && defender.Health > 0)
			{
				writer.WriteLine($"Round {round}:");
				attacker.Attack(defender);
				if (defender.Health <= 0)
				{
					writer.WriteLine(string.Format(OutputMessages.HeroDefeated, defender.Name));
					break;
				}

				defender.Attack(attacker);
				if (attacker.Health <= 0)
				{
					writer.WriteLine(string.Format(OutputMessages.HeroDefeated, attacker.Name));
					break;
				}

				writer.WriteLine(string.Format(OutputMessages.Status, attacker.Name, attacker.Health, defender.Name, defender.Health));
				round++;
				Console.WriteLine();
			}
		}
	}
}
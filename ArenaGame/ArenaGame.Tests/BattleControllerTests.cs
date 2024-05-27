using Xunit;
using FluentAssertions;
using ArenaGame.Controllers;
using ArenaGame.Heroes;
using ArenaGame.Weapons;
using ArenaGame.Utilities;
using ArenaGame.Enums;
using ArenaGame.Models;
using ArenaGame.IO;

namespace ArenaGame.Tests
{
	public class BattleControllerTests
	{
		private readonly Writer writer;
		private readonly ShopController shopController;
		private readonly BattleController battleController;
		private readonly Knight hero;
		private readonly Assassin target;

		public BattleControllerTests()
		{
			writer = new Writer();
			shopController = new ShopController(writer);
			battleController = new BattleController(writer, shopController);
			hero = new Knight("Knight1", 50, 100, new Sword("Excalibur"), new Pet(PetType.Attack, 10), writer, shopController);
			target = new Assassin("Assassin1", 30, 80, new Dagger("Shadow Blade"), new Pet(PetType.Defense, 5), writer, shopController);
		}

		[Fact]
		public void BattleControllerShouldStartBattle()
		{
			// Act
			battleController.StartBattle(hero, target);

			// Assert
			target.Health.Should().BeLessThan(GameConstants.BaseHealth);
		}
	}
}

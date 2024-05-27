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
	public class ShopControllerTests
	{
		private readonly Writer writer;
		private readonly ShopController shopController;
		private readonly Knight hero;

		public ShopControllerTests()
		{
			writer = new Writer();
			shopController = new ShopController(writer);
			hero = new Knight("Knight1", 50, 100, new Sword("Excalibur"), new Pet(PetType.Attack, 10), writer, shopController);
		}

		[Fact]
		public void ShopControllerShouldBuyRandomWeapon()
		{
			// Arrange
			hero.GainCoins(GameConstants.CoinsThreshold);

			// Act
			shopController.BuyRandomWeapon(hero);

			// Assert
			hero.Weapon.Should().NotBeNull();
			hero.Coins.Should().Be(0);
		}
	}
}

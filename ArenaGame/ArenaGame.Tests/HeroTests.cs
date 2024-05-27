using Xunit;
using FluentAssertions;
using ArenaGame.Heroes;
using ArenaGame.Weapons;
using ArenaGame.Controllers;
using ArenaGame.Utilities;
using ArenaGame.Enums;
using ArenaGame.Models;
using ArenaGame.IO;

namespace ArenaGame.Tests
{
	public class HeroTests
	{
		private readonly Writer writer;
		private readonly ShopController shopController;
		private readonly Knight hero;
		private readonly Assassin target;

		public HeroTests()
		{
			writer = new Writer();
			shopController = new ShopController(writer);
			hero = new Knight("Knight1", 50, 100, new Sword("Excalibur"), new Pet(PetType.Attack, 10), writer, shopController);
			target = new Assassin("Assassin1", 30, 80, new Dagger("Shadow Blade"), new Pet(PetType.Defense, 5), writer, shopController);
		}

		[Fact]
		public void HeroShouldHaveInitialValues()
		{
			// Assert
			hero.Name.Should().Be("Knight1");
			hero.Armor.Should().Be(50);
			hero.Strength.Should().Be(100);
			hero.Weapon.Name.Should().Be("Excalibur");
			hero.Health.Should().Be(GameConstants.BaseHealth);
			hero.Level.Should().Be(1);
			hero.XP.Should().Be(0);
			hero.Coins.Should().Be(0);
			hero.Pet.Type.Should().Be(PetType.Attack);
			hero.Pet.Effect.Should().Be(10);
		}

		[Fact]
		public void HeroShouldGainXPAndLevelUp()
		{
			// Act
			hero.GainXP(150); 

			// Assert
			hero.XP.Should().Be(150);
			hero.Level.Should().Be(2);
			hero.Health.Should().Be(GameConstants.BaseHealth + GameConstants.HealthBoostPerLevel + 5); // Assuming each level adds HealthBoostPerLevel + 5 health
			hero.Strength.Should().Be(100 + GameConstants.AttackBoostPerLevel + 2); // Assuming each level adds AttackBoostPerLevel + 2 strength
		}

		[Fact]
		public void HeroShouldTakeDamageAndDefend()
		{
			// Act
			double damageTaken = hero.Defend(200);

			// Assert
			damageTaken.Should().Be(200 - (50 + hero.Weapon.BlockingPower));
		}

		[Fact]
		public void HeroShouldAttackAndApplyEffects()
		{
			// Act
			hero.Attack(target);

			// Assert
			target.Health.Should().BeLessThan(GameConstants.BaseHealth);
		}
	}
}

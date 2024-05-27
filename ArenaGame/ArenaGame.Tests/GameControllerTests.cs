using Xunit;
using FluentAssertions;
using ArenaGame.Controllers;
using ArenaGame.Heroes;
using ArenaGame.Weapons;
using ArenaGame.Utilities;
using ArenaGame.Enums;
using ArenaGame.Models;
using ArenaGame.Repositories;
using ArenaGame.IO;

namespace ArenaGame.Tests
{
	public class GameControllerTests
	{
		private readonly Writer writer;
		private readonly ShopController shopController;
		private readonly Repository<IHero> heroRepository;
		private readonly GameController gameController;

		public GameControllerTests()
		{
			writer = new Writer();
			shopController = new ShopController(writer);
			heroRepository = new Repository<IHero>();
			gameController = new GameController(heroRepository, writer, shopController);
		}

		[Fact]
		public void GameControllerShouldCreateHero()
		{
			// Act
			gameController.CreateHero("Knight1", HeroType.Knight, 50, 100, new Sword("Excalibur"), new Pet(PetType.Attack, 10));

			// Assert
			var hero = heroRepository.FindByName("Knight1");
			hero.Should().NotBeNull();
			hero.Name.Should().Be("Knight1");
		}

		[Fact]
		public void GameControllerShouldStartBattle()
		{
			// Arrange
			gameController.CreateHero("Knight1", HeroType.Knight, 50, 100, new Sword("Excalibur"), new Pet(PetType.Attack, 10));
			gameController.CreateHero("Assassin1", HeroType.Assassin, 30, 80, new Dagger("Shadow Blade"), new Pet(PetType.Defense, 5));

			// Act
			gameController.StartBattle("Knight1", "Assassin1");

			// Assert
			var hero = heroRepository.FindByName("Knight1");
			var target = heroRepository.FindByName("Assassin1");
			target.Health.Should().BeLessThan(GameConstants.BaseHealth);
		}
	}
}

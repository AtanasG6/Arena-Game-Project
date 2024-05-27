using System;
using ArenaGame.Controllers;
using ArenaGame.Repositories;
using ArenaGame.Core.Contracts;
using ArenaGame.Models.Contracts;
using ArenaGame.Enums;
using ArenaGame.Repositories.Contracts;
using ArenaGame.Weapons;
using ArenaGame.Models;
using ArenaGame.Utilities;
using ArenaGame.IO.Contracts;
using ArenaGame.IO;

namespace ArenaGame.Core
{
	public class Engine : IEngine
	{
		private readonly IReader reader;
		private readonly IWriter writer;
		private readonly IController controller;
		private readonly ShopController shopController;

		public Engine()
		{
			this.reader = new Reader();
			this.writer = new Writer();
			IRepository<IHero> heroRepository = new Repository<IHero>();
			this.shopController = new ShopController(writer);
			this.controller = new GameController(heroRepository, writer, shopController);
		}

		public void Run()
		{
			PrintInstructions();
			string input;
			while ((input = reader.ReadLine()) != "End")
			{
				try
				{
					ProcessCommand(input);
				}
				catch (Exception ex)
				{
					writer.WriteLine(ex.Message, OutputColor.Red);
				}
			}
		}

		private void PrintInstructions()
		{
			writer.WriteLine("Welcome to Arena Game!", OutputColor.Green);
			writer.WriteLine("To create a hero, use the following command format:", OutputColor.Yellow);
			writer.WriteLine("CreateHero <Name> <HeroType> <Armor> <Strength> <WeaponType> <PetType> <PetEffect>", OutputColor.Cyan);
			writer.WriteLine("Example: CreateHero Knight1 Knight 50 100 Sword Attack 10", OutputColor.Default);
			writer.WriteLine("HeroType can be: Knight, Assassin, Archer, Mage", OutputColor.Magenta);
			writer.WriteLine("WeaponType can be: Sword, FireWeapon, IceWeapon, Staff, Bow, Dagger, BloodRestorationWeapon", OutputColor.Magenta);
			writer.WriteLine("PetType can be: Attack, Defense", OutputColor.Magenta);
			writer.WriteLine("\n");
			writer.WriteLine("To start a battle, use the following command format:", OutputColor.Yellow);
			writer.WriteLine("StartBattle <AttackerName> <DefenderName>", OutputColor.Cyan);
			writer.WriteLine("Example: StartBattle Knight1 Assassin1");
			writer.WriteLine("\n");
			writer.WriteLine("To end the game, type: End", OutputColor.Red);
			writer.WriteLine("\n");
		}

		private void ProcessCommand(string input)
		{
			string[] inputArgs = input.Split();
			string command = inputArgs[0];

			switch (command)
			{
				case "CreateHero":
					string name = inputArgs[1];
					HeroType heroType = (HeroType)Enum.Parse(typeof(HeroType), inputArgs[2]);
					double armor = double.Parse(inputArgs[3]);
					double strength = double.Parse(inputArgs[4]);
					IWeapon weapon = CreateWeapon(inputArgs[5]);
					IPet pet = CreatePet(inputArgs[6], int.Parse(inputArgs[7]));
					controller.CreateHero(name, heroType, armor, strength, weapon, pet);
					break;
				case "StartBattle":
					string attackerName = inputArgs[1];
					string defenderName = inputArgs[2];
					controller.StartBattle(attackerName, defenderName);
					break;
			}
		}

		private IWeapon CreateWeapon(string weaponType)
		{
			if (weaponType == "Sword")
			{
				return new Sword("Default Sword");
			}
			else if (weaponType == "FireWeapon")
			{
				return new FireWeapon("Default FireWeapon");
			}
			else if (weaponType == "IceWeapon")
			{
				return new IceWeapon("Default IceWeapon");
			}
			else if (weaponType == "Staff")
			{
				return new Staff("Default Staff");
			}
			else if (weaponType == "Bow")
			{
				return new Bow("Default Bow");
			}
			else if (weaponType == "Dagger")
			{
				return new Dagger("Default Dagger");
			}
			else if (weaponType == "BloodRestorationWeapon")
			{
				return new BloodRestorationWeapon("Default Healing Wand");
			}
			else
			{
				throw new ArgumentException(ExceptionMessages.InvalidWeaponType);
			}
		}

		private IPet CreatePet(string petType, int effect)
		{
			if (petType == "Attack")
			{
				return new Pet(PetType.Attack, effect);
			}
			else if (petType == "Defense")
			{
				return new Pet(PetType.Defense, effect);
			}
			else
			{
				throw new ArgumentException(ExceptionMessages.InvalidPetType);
			}
		}
	}
}
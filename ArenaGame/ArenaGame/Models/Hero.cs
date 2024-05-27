using System;
using ArenaGame.Controllers;
using ArenaGame.Enums;
using ArenaGame.IO.Contracts;
using ArenaGame.Models;
using ArenaGame.Models.Contracts;
using ArenaGame.Utilities;

namespace ArenaGame.Heroes
{
	public abstract class Hero : IHero
	{
		protected Random random;
		protected IWriter writer;
		protected ShopController shopController;

		public string Name { get; set; }
		public double Armor { get; set; }
		public double Strength { get; set; }
		public IWeapon Weapon { get; set; }
		public int Health { get; set; }
		public int Level { get; set; }
		public int XP { get; set; }
		public int Coins { get; set; }
		public IPet Pet { get; set; }
		public int FrozenRounds { get; set; }
		public int BurningRounds { get; set; }

		protected Hero(string name, double armor, double strength, IWeapon weapon, IPet pet, IWriter writer, ShopController shopController)
		{
			Name = name;
			Armor = armor;
			Strength = strength;
			Weapon = weapon;
			Pet = pet;
			this.writer = writer;
			this.shopController = shopController;
			random = new Random();
			Health = GameConstants.BaseHealth;
			Level = 1;
			XP = 0;
			Coins = 0;
			FrozenRounds = 0;
			BurningRounds = 0;
		}

		public virtual void Attack(IHero target)
		{
			if (FrozenRounds > 0)
			{
				writer.WriteLine(string.Format(OutputMessages.HeroFrozen, Name, Level), OutputColor.Cyan);
				FrozenRounds--;
				return;
			}

			double damage = Strength + Weapon.AttackDamage;
			double finalDamage = target.Defend(damage);
			target.Health -= (int)finalDamage;
			Pet?.Assist(this, target);
			Weapon.ApplyEffect(this, target);

			writer.WriteLine(string.Format(OutputMessages.HeroAttacks, Name, Level, target.Name, Weapon.Name, finalDamage), OutputColor.Red);
			if (Pet != null)
			{
				writer.WriteLine($"{Pet.Type} pet assists {Name}, providing an additional effect.", OutputColor.Yellow);
			}

			GainCoins(GameConstants.CoinsPerAttack);
			writer.WriteLine(string.Format(OutputMessages.HeroGainsCoins, Name, GameConstants.CoinsPerAttack, Coins), OutputColor.Green);

			if (Coins >= GameConstants.CoinsThreshold)
			{
				shopController.BuyRandomWeapon(this);
			}

			ApplyBurningEffect();
			if (BurningRounds > 0)
			{
				writer.WriteLine(string.Format(OutputMessages.HeroBurning, Name, GameConstants.BurningDamagePerRound), OutputColor.DarkRed);
			}

			FindItem();
		}

		public virtual double Defend(double damage)
		{
			double reducedDamage = damage - (Armor + Weapon.BlockingPower);
			return reducedDamage > 0 ? reducedDamage : 0;
		}


		public void ApplyBurningEffect()
		{
			if (BurningRounds > 0)
			{
				Health -= GameConstants.BurningDamagePerRound;
				BurningRounds--;
			}
		}

		public void GainXP(int amount)
		{
			XP += amount;
			writer.WriteLine(string.Format(OutputMessages.HeroGainsXP, Name, amount, XP, Level), OutputColor.Magenta);

			if (XP >= Level * GameConstants.XPPerLevel)
			{
				LevelUp();
				writer.WriteLine(string.Format(OutputMessages.HeroLevelsUp, Name, Level), OutputColor.DarkYellow);
			}
		}

		public void GainCoins(int amount)
		{
			Coins += amount;
		}

		public void RestoreHealth(int amount)
		{
			Health += amount;
			writer.WriteLine(string.Format(OutputMessages.HeroRestoresHealth, Name, amount, Health), OutputColor.Green);
		}

		public abstract void LevelUp();

		private void FindItem()
		{
			// Random chance to find an item
			if (random.NextDouble() < GameConstants.ItemFindChance)
			{
				Item item = GenerateRandomItem();
				writer.WriteLine(string.Format(OutputMessages.HeroFindsItem, Name, item.Name, item.Rarity, item.XPBonus), OutputColor.Cyan);
				GainXP(item.XPBonus);
				Health += item.HealthBonus;
				Strength += item.AttackBonus;
				writer.WriteLine(string.Format(OutputMessages.HeroGainsHealth, Name, item.HealthBonus, Health), OutputColor.Green);
				writer.WriteLine(string.Format(OutputMessages.HeroGainsStrength, Name, item.AttackBonus, Strength), OutputColor.Green);
			}
		}

		private Item GenerateRandomItem()
		{
			int rarityValue = random.Next(1, 101); 
			Rarity rarity;

			if (rarityValue <= 50)
				rarity = Rarity.Common;
			else if (rarityValue <= 80)
				rarity = Rarity.Uncommon;
			else if (rarityValue <= 95)
				rarity = Rarity.Rare;
			else
				rarity = Rarity.Epic;

			int xpBonus = (int)rarity * GameConstants.XPPerRarityLevel;
			int healthBonus = (int)rarity * GameConstants.HealthBonusPerRarityLevel;
			int attackBonus = (int)rarity * GameConstants.AttackBonusPerRarityLevel;

			return new Item("Random Item", rarity, xpBonus, healthBonus, attackBonus);
		}
	}
}

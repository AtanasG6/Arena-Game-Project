using ArenaGame.Enums;

namespace ArenaGame.Models
{
	public class Item
	{
		public string Name { get; }
		public Rarity Rarity { get; }
		public int XPBonus { get; }
		public int HealthBonus { get; }
		public int AttackBonus { get; }

		public Item(string name, Rarity rarity, int xpBonus, int healthBonus, int attackBonus)
		{
			Name = name;
			Rarity = rarity;
			XPBonus = xpBonus;
			HealthBonus = healthBonus;
			AttackBonus = attackBonus;
		}
	}
}

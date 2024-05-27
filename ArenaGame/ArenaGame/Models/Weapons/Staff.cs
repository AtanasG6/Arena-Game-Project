namespace ArenaGame.Weapons
{
	public class Staff : IWeapon
	{
		public string Name { get; set; }
		public double AttackDamage { get; private set; }
		public double BlockingPower { get; private set; }

		public Staff(string name)
		{
			Name = name;
			AttackDamage = 25;
			BlockingPower = 5;
		}

		public void ApplyEffect(IHero attacker, IHero target)
		{
			// Без допълнителни ефекти за жезъла
		}
	}
}

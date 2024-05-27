namespace ArenaGame.Weapons
{
	public class Bow : IWeapon
	{
		public string Name { get; set; }
		public double AttackDamage { get; private set; }
		public double BlockingPower { get; private set; }

		public Bow(string name)
		{
			Name = name;
			AttackDamage = 20;
			BlockingPower = 3;
		}

		public void ApplyEffect(IHero attacker, IHero target)
		{
			// Без допълнителни ефекти за лъка
		}
	}
}

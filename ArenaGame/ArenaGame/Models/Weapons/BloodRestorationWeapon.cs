namespace ArenaGame.Weapons
{
	public class BloodRestorationWeapon : IWeapon
	{
		public string Name { get; set; }
		public double AttackDamage { get; private set; }
		public double BlockingPower { get; private set; }

		public BloodRestorationWeapon(string name)
		{
			Name = name;
			AttackDamage = 15;
			BlockingPower = 5;
		}

		public void ApplyEffect(IHero attacker, IHero target)
		{
			attacker.RestoreHealth(10);
		}
	}
}

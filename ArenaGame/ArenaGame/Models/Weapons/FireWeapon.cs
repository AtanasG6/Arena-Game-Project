using ArenaGame.Utilities;

namespace ArenaGame.Weapons
{
	public class FireWeapon : IWeapon
	{
		public string Name { get; set; }
		public double AttackDamage { get; private set; }
		public double BlockingPower { get; private set; }

		public FireWeapon(string name)
		{
			Name = name;
			AttackDamage = 20;
			BlockingPower = 5;
		}

		public void ApplyEffect(IHero attacker, IHero target)
		{
			target.BurningRounds = GameConstants.BurningRoundsDuration;
		}
	}
}

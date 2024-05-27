using ArenaGame.Utilities;

namespace ArenaGame.Weapons
{
	public class IceWeapon : IWeapon
	{
		public string Name { get; set; }
		public double AttackDamage { get; private set; }
		public double BlockingPower { get; private set; }

		public IceWeapon(string name)
		{
			Name = name;
			AttackDamage = 10;
			BlockingPower = 10;
		}

		public void ApplyEffect(IHero attacker, IHero target)
		{
			// Freeze target for a few rounds
			target.FrozenRounds = GameConstants.FrozenRoundsDuration;
		}
	}
}

namespace ArenaGame.Models.Contracts
{
	public interface IBattle
	{
		void StartBattle(IHero attacker, IHero defender);
	}
}

using ArenaGame.Enums;
using ArenaGame.Models.Contracts;

namespace ArenaGame.Models
{
	public class Pet : IPet
	{
		public PetType Type { get; private set; }
		public int Effect { get; private set; }

		public Pet(PetType type, int effect)
		{
			Type = type;
			Effect = effect;
		}

		public void Assist(IHero owner, IHero target)
		{
			switch (Type)
			{
				case PetType.Attack:
					target.Health -= Effect;
					break;
				case PetType.Defense:
					owner.Health += Effect;
					break;
			}
		}
	}
}

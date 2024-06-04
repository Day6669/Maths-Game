using System;
namespace OOP_2
{
	public interface IMathsApp
	{
		public abstract int Menu();
		public abstract void DisplayEquation(List<Card> equation);
		public abstract bool DealOnce();
		public abstract void Play();
	}
}


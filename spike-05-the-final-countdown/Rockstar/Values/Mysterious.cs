using Rockstar.Expressions;

namespace Rockstar.Values;

class Mysterious : Value {
	private Mysterious() : base(Source.None) { }
	public static Mysterious Instance = new();
	public override bool Truthy => false;
}

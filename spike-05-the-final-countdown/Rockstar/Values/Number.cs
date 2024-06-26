using System.Globalization;
using System.Text;
namespace Rockstar.Values;

public class Number(decimal value, Source source)
	: Value(source) {
	public Number(decimal value) : this(value, Source.None) { }
	public decimal Value => value;
	public override string ToString()
		=> value.ToString(CultureInfo.InvariantCulture);

	public override void Print(StringBuilder sb, int depth)
		=> sb.Indent(depth).AppendLine($"number: {value:G29} {Location}");

	public override bool Truthy => value != 0m;

	public Value Negate() => new Number(-value);
}
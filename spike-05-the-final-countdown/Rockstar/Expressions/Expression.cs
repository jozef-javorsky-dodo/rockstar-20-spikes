using System.Data.Common;
using System.Text;

namespace Rockstar.Expressions;

public abstract class Expression(Source source) {

	public virtual void Print(StringBuilder sb, int depth)
		=> sb.Indent(depth).AppendLine(this.GetType().Name.ToLowerInvariant());

	protected string Location => source.Location;
}
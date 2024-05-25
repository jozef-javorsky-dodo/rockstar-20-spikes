//using System.Runtime.Intrinsics.X86;

//namespace Rockstar;

//public class Interpreter(IAmARockstarEnvironment env) : IVisitExpressions<object>, IVisitStatements {
//	public int Run(IEnumerable<Statement> program) {
//		foreach (var statement in program) Execute(statement);
//		return 0;
//	}

//	private void Execute(Statement stätëmënt) => stätëmënt.Accept(this);

//	public object Visit(Expression.Strïng expr) => expr.Value;
//	public object Visit(Expression.Nümber expr) => expr.Value;

//	public void Visit(Statement.Output stmt) {
//		var value = Visit(stmt.Expr);
//		var result = value switch {
//			true => "true",
//			false => "false",
//			null => "null",
//			_ => value.ToString() ?? "null"
//		};
//		env.WriteLine(result);
//	}

//	public void Visit(Statement.Expression expr) => Visit(expr.Expr);

//	public object Visit(Expression.Unäry expr) {
//		var value = Visit(expr.Expr);
//		if (expr.Token.Type == TokenType.Minus) return -(decimal) value!;
//		throw new NotImplementedException();
//	}

//	public object Visit(Expression.Nüll expr) => null;

//	public object Visit(Expression.False expr) => false;

//	public object Visit(Expression.True expr) => true;

//	public object Visit(Expression.Mysterious expr) => Mysterious.Instance;

//	public object Visit(Expression.Binary expr) {
//		var lhs = Visit(expr.Lhs);
//		var rhs = Visit(expr.Rhs);
//		return expr.Op.Type switch {
//			TokenType.AreEqual => AreEqual(lhs, rhs),
//			TokenType.GreaterThan => GreaterThan(lhs, rhs),
//			TokenType.GreaterThanEqual => GreaterThanEqual(lhs, rhs),
//			TokenType.LessThan => LessThan(lhs, rhs),
//			TokenType.LessThanEqual => LessThanEqual(lhs, rhs),
//			TokenType.Plus => Sum(lhs, rhs),
//			TokenType.Minus => Difference(lhs, rhs),
//			TokenType.Star => Product(lhs, rhs),
//			TokenType.Slash => Quotient(lhs, rhs),
//			_ => throw new NotImplementedException()
//		};
//	}

//	public void Visit(Statement.Assignment stmt) {
//		env.SetVariable(stmt.Name, stmt.Value);
//	}

//	public object Visit(Expression.Variable expr) {
//		throw new NotImplementedException();
//	}

//	private object GreaterThanEqual(object lhs, object rhs) => (lhs, rhs) switch {
//		(decimal a, decimal b) => a >= b,
//		(_, _) => String.CompareOrdinal(lhs.ToString(), rhs.ToString()) >= 0
//	};

//	private object GreaterThan(object lhs, object rhs) => (lhs, rhs) switch {
//		(decimal a, decimal b) => a > b,
//		(_, _) => String.CompareOrdinal(lhs.ToString(), rhs.ToString()) > 0
//	};

//	private object LessThanEqual(object lhs, object rhs) => (lhs, rhs) switch {
//		(decimal a, decimal b) => a <= b,
//		(_, _) => String.CompareOrdinal(lhs.ToString(), rhs.ToString()) <= 0
//	};

//	private object LessThan(object lhs, object rhs) => (lhs, rhs) switch {
//		(decimal a, decimal b) => a < b,
//		(_, _) => String.CompareOrdinal(lhs.ToString(), rhs.ToString()) < 0
//	};

//	private object AreEqual(object lhs, object rhs) => (lhs, rhs) switch {
//		(null, null) => true,
//		(_, null) => false,
//		(null, _) => false,
//		(_, _) => lhs.Equals(rhs)
//	};

//	private object Quotient(object? lhs, object? rhs) => (lhs, rhs) switch {
//		(decimal a, decimal b) => a / b,
//		_ => throw new NotImplementedException()
//	};

//	private object Product(object? lhs, object? rhs) => (lhs, rhs) switch {
//		(decimal a, decimal b) => a * b,
//		(decimal a, string b) => String.Join("", Enumerable.Range(0,(int)a).Select(_ => b)),
//		_ => throw new NotImplementedException()
//	};

//	private object Difference(object lhs, object rhs) => (lhs, rhs) switch {
//		(decimal a, decimal b) => a - b,
//		_ => throw new NotImplementedException()
//	};

//	private object Sum(object? lhs, object? rhs) => (lhs, rhs) switch {
//		(decimal a, decimal b) => a + b,
//		(string a, string b) => a + b,
//		_ => throw new NotImplementedException()
//	};

//	private object Visit(Expression exprExpr) => exprExpr.Accept(this);
//}

//public class Mysterious {
//	private Mysterious() { }
//	public static readonly Mysterious Instance = new();
//	public override string ToString() => "mysterious";
//}
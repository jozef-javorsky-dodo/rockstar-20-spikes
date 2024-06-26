namespace Rockstar;

public static class Program {
	private static readonly IAmARockstarEnvironment env = new ConsoleEnvironment();
	private static readonly Parser parser = new();
	public static void Main(string[] args) {
		switch (args.Length) {
			case > 1:
				Console.WriteLine("Usage: rockstar <program.rock>");
				Environment.Exit(64);
				break;
			case 1:
				RunFile(args[0]);
				break;
			default:
				// RunFile("D:\\Projects\\github\\dylanbeattie\\rockstar-20-spikes\\spike-05-the-final-countdown\\Rockstar.Test\\fixtures\\math\\operators.rock");
				Run("value's 2");
				//Run("""
				//    shout 1+2
				//    shout 2
				//    shout 4
				//    """);
				break;
		}
	}

	private static void RunFile(string path) => Run(File.ReadAllText(path));

	private static void RunPrompt() {
		while (true) {
			env.Write("> ");
			var line = env.ReadInput();
			if (line == null) break;
			Run(line);
		}
	}

	private static void Run(string source) {
		try {
			var program = parser.Parse(source);
			Console.WriteLine(program);
			Console.WriteLine(String.Empty.PadLeft(40, '-'));
			var interpreter = new Interpreter(env);
			interpreter.Run(program);
		} catch (FormatException ex) {
			Console.Error.WriteLine(ex);
		}
	}
}
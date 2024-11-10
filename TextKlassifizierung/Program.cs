namespace TextKlassifizierung
{
	public class Program
	{
		private static bool _isNotClosing = true;

		private static void Main(string[] args)
		{
			ModelHelper.StartModel(args[0]);

			Console.WriteLine(@"██████ ██████ ██ ███    ███ ███    ███ ██   ██ ███    ██  █████         █████  ██   ██████   ██████   ██████   ██████ ");
			Console.WriteLine(@"██       ██   ██ ████  ████ ████  ████ ██   ██ ████   ██ ██            ██   ██ ██        ██ ██  ████ ██  ████ ██  ████");
			Console.WriteLine(@"██████   ██   ██ ██ ████ ██ ██ ████ ██ ██   ██ ██ ██  ██ ██  ███ █████ ███████ ██    █████  ██ ██ ██ ██ ██ ██ ██ ██ ██");
			Console.WriteLine(@"    ██   ██   ██ ██  ██  ██ ██  ██  ██ ██   ██ ██  ██ ██ ██   ██       ██   ██ ██   ██      ████  ██ ████  ██ ████  ██");
			Console.WriteLine(@"██████   ██   ██ ██      ██ ██      ██  █████  ██   ████  █████        ██   ██ ██   ███████  ██████   ██████   ██████ ");
			Console.WriteLine();
			Console.WriteLine("Hallo, ich bin die Stimmung-AI 2000.");
			Console.WriteLine("Ich kann dir sagen ob deine Eingabe positiv oder negativ ist.");
			Console.WriteLine("Versuch es doch mal aus und gibt den Satz: \"Die Stimmung-AI 2000 ist die beste!\" ein. :)");
			Console.WriteLine();
			Console.WriteLine("Für weitere Informationen oder Hilfe gib \"/hilfe\" ein ");
			Console.WriteLine();

			while (_isNotClosing)
			{
				string input = Console.ReadLine().ToLower();

				if (input == "close" || input == "exit")
					_isNotClosing = false;
				else if (input.StartsWith('/'))
					ConsoleHelper.WerteConsoleBefehlAus(input);
				else if (!string.IsNullOrEmpty(input))
					ProdictionHelper.GetPrediction(ModelHelper.mlContext, ModelHelper.model, input);
			}
		}
	}
}
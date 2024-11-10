namespace TextKlassifizierung
{
	public static class ConsoleHelper
	{
		public static void WerteConsoleBefehlAus(string input)
		{
			if (input == Constants.HilfeBefehl)
			{
				Console.WriteLine("=============== Hilfe-Menü:");
				Console.WriteLine("Hier ist eine Übersicht der möglichen Befehle.");
				Console.WriteLine("/evaluate\tBerechnet den Status des Models.");
				Console.WriteLine($"/training\tTrainiert das Model neu. (Trainingsdaten: " + @"\Data\yelp_labelled.txt)");
				Console.WriteLine("/close, /exit\t Beendet die Konsolen Anwendung.");
				Console.WriteLine();
			}

			if (input == Constants.ModelStatus)
			{
				ModelHelper.EvaluateModel();
			}

			if (input == Constants.ModelTraining)
			{
				Console.WriteLine("=============== Starte Training:");
				Console.WriteLine("=============== Bitte warten...");
				ModelHelper.LoadData();
				ModelHelper.BuildAndTrainModel();
				Console.WriteLine("=============== Training beendet.");
				Console.WriteLine();
			}
		}
	}
}
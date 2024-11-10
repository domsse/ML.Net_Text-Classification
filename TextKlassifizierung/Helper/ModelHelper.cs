using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.DataOperationsCatalog;

namespace TextKlassifizierung
{
	public static class ModelHelper
	{
		public static MLContext mlContext;
		private static DataViewSchema _modelSchema;
		private static TrainTestData splitDataView;
		public static ITransformer model;

		public static string _dataPath;

		public static void StartModel(string dataFilePath)
		{
			Console.WriteLine("Beginn der Initialisierung vom Model");

			try
			{
				_dataPath = dataFilePath;

				if (string.IsNullOrEmpty(_dataPath))
					throw new Exception("Es wurde in Parametern kein Pfad zur Datei angegeben.");

				mlContext = new MLContext();
				LoadData();

				if (File.Exists($@"{Environment.CurrentDirectory}\Models\StimmungAI.zip"))
				{
					model = mlContext.Model.Load($@"{Environment.CurrentDirectory}\Models\StimmungAI.zip", out _modelSchema);
					Console.WriteLine($@"Model ""\Models\StimmungAI.zip"" wurde erfolgreich geladen.");
				}
				else
				{
					BuildAndTrainModel();
					Console.WriteLine(@"Model wurde erfolgreich erstellt und in ""\\Models\\StimmungAI.zip"" gespeichert.");
				}

				Console.WriteLine("Das Model ist jetzt einsatzbereit!");
				Console.WriteLine("\n\n\n");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Beim starten ist es zu einem Fehler gekommen.");
				Console.WriteLine("Fehler: " + ExceptionHandler.PostException(ex));
				Environment.Exit(1);
			}
		}

		public static void LoadData()
		{
			IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentData>(_dataPath, hasHeader: false);

			splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.1);
		}

		public static void BuildAndTrainModel()
		{
			var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
				.Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

			model = estimator.Fit(splitDataView.TrainSet);

			string modelFilePath = $@"{Environment.CurrentDirectory}\Models\StimmungAI.zip";

			if (!Directory.Exists(Path.GetDirectoryName(modelFilePath)))
				Directory.CreateDirectory(Path.GetDirectoryName(modelFilePath));

			if (File.Exists(modelFilePath))
				File.Delete(modelFilePath);

			mlContext.Model.Save(model, splitDataView.TrainSet.Schema, $@"{Environment.CurrentDirectory}\Models\StimmungAI.zip");
		}

		public static void EvaluateModel()
		{
			IDataView predictions = model.Transform(splitDataView.TestSet);
			CalibratedBinaryClassificationMetrics metrics = mlContext.BinaryClassification.Evaluate(predictions, "Label");

			Console.WriteLine("=============== Status des Models:");
			Console.WriteLine($"Genauigkeit: {metrics.Accuracy:P2}");
			Console.WriteLine($"Auc: {metrics.AreaUnderRocCurve:P2} (Wie sicher das Modell korrekt klassifizieren kann.)");
			Console.WriteLine($"Gleichgewicht: {metrics.F1Score:P2}");
			Console.WriteLine();
		}
	}
}
using Microsoft.ML;

namespace TextKlassifizierung
{
	public static class ProdictionHelper
	{
		// Einzelne Eingabe auswerten:
		public static void GetPrediction(MLContext mlContect, ITransformer model, string inputText)
		{
			PredictionEngine<SentimentData, SentimentPrediction> predictionFunction = mlContect.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);

			SentimentData data = new()
			{
				SentimentText = inputText
			};

			var result = predictionFunction.Predict(data);

			Console.WriteLine();
			Console.WriteLine("=============== Ergebniss:");

			Console.WriteLine();
			Console.WriteLine($"Eingabe: {result.SentimentText}");
			Console.WriteLine($"Ergebnis: {(Convert.ToBoolean(result.Prediction) ? "Positive Stimmung" : "Negative Stimmung")}");
			Console.WriteLine($"Score: {(result.Probability * 100).ToString("0.00")} (0 Negativ, 100 Positiv)");
			Console.WriteLine();

			Console.WriteLine($"=============== {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
			Console.WriteLine();
		}

		// Mehrere Eingaben auswerten:
		// Not implemented!
		private static void UseModelWithBatchItems(MLContext mlContext, ITransformer model)
		{
			IEnumerable<SentimentData> sentiments = new[]
			{
			new SentimentData
			{
				SentimentText = "This was a horrible meal"
			},
			new SentimentData
			{
				SentimentText = "Oh i love this spaghetti.....!"
			}
		};

			IDataView batchComments = mlContext.Data.LoadFromEnumerable(sentiments);
			IDataView predictions = model.Transform(batchComments);

			// Use model to predict wheter comment data is Positive (1) or Negative (0).
			IEnumerable<SentimentPrediction> predictedResults = mlContext.Data.CreateEnumerable<SentimentPrediction>(predictions, reuseRowObject: false);

			//Console.WriteLine("============== Testen mit einem Models mit mehreren Beispielen ==============");

			foreach (SentimentPrediction prediction in predictedResults)
			{
				//Console.WriteLine($"Beispieltext: {prediction.SentimentText} | Prediction: {(Convert.ToBoolean(prediction.Prediction))}");
			}

			//Console.WriteLine("============Ende des Test der vorhersage mit mehreren Beispielen ============");
		}
	}
}
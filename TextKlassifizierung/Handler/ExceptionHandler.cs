using System.Text;

namespace TextKlassifizierung
{
	public static class ExceptionHandler
	{
		public static string PostException(Exception ex)
		{
			Exception exception = ex;
			StringBuilder sb = new StringBuilder();

			while (exception != null)
			{
				sb.Append(exception.Message);
				exception = exception.InnerException;
			}

			return sb.ToString();
		}
	}
}
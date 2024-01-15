namespace Toy_Robot {

	/// <summary>
	/// Obtains user input commands, from command line or a text file
	/// </summary>
	internal class InputReader {

		/// <summary>
		/// C'tor with no argument will read from command line
		/// </summary>
		public InputReader() {
			// Unused, can be removed
		}

		/// <summary>
		/// C'tor with non-null argument will read from the text file of that name
		/// </summary>
		public InputReader(string? textFilename) : base() {
			_textFileName = textFilename;
		}

		private string? _textFileName;

		public IEnumerable<string> ReadFrom() {
			string? line;
			if (_textFileName == null) {
				while (!String.IsNullOrEmpty(line = Console.ReadLine())) {
					yield return line;
				}
			}
			else {
				using (var reader = File.OpenText(_textFileName)) {
					while ((line = reader.ReadLine()) != null) {
						yield return line;
					}
				}
			}
		}
	}
}

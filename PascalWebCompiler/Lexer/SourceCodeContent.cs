namespace PascalWebCompiler.Lexer
{
    public class SourceCodeContent
    {

        private int _row;
        private int _column;
        private readonly string _input;
        private int _currentIndex;

        public SourceCodeContent(string input)
        {
            _input = input;
            _currentIndex = 0;
            _row = 0;
            _column = 0;
        }

        public Symbol NextSymbol()
        {


            if (_currentIndex >= _input.Length)
                return new Symbol { Row = _row, Column = _column, CurrentSymbol = '\0' };

            var currentSym = new Symbol { Row = _row, Column = _column, CurrentSymbol = _input[_currentIndex++] };

            if (currentSym.CurrentSymbol.Equals('\n'))
            {
                _column = 0;
                _row += 1;
            }
            else
            {
                _column += 1;
            }


            return currentSym;
        }

    }
}

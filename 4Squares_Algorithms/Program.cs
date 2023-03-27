using System.Text;


char[] alphabet = { 'a','b','c','ç','d','e','f','g','ğ','h','ı','i','j','k','l','m',
'n','o','ö','p','r','s','ş','t','u','ü','v','y','z','x'};


string input = "akşamabamyavar";
StringBuilder value = new StringBuilder(input);

char[,] alphabetMatrix1 = AlphabetMatrixCreated();
char[,] alphabetMatrix2 = AlphabetMatrixCreated();
char[,] permutationMatrix1 = PermutationAlphabetMatrixCreated(alphabet);
char[,] permutationMatrix2 = PermutationAlphabetMatrixCreated(alphabet);


DisplayMatrix(alphabetMatrix1, permutationMatrix1);
Console.WriteLine(" ");
DisplayMatrix(permutationMatrix2, alphabetMatrix2);





var a = Syllable(value);

Encrypt(a);
void Encrypt(string[] inputValue)
{
    StringBuilder encrypt= new StringBuilder();
    for (int i = 0; i < inputValue.Length; i++)
    {
         var (firstLetterRow, firstLetterColumn) = SearcIndex(inputValue[i][0], alphabetMatrix1);
         var (secondtLetterRow, secondLettercolumn) = SearcIndex(inputValue[i][1], alphabetMatrix2);  
         encrypt.Append(permutationMatrix1[firstLetterRow, secondLettercolumn]);
         encrypt.Append(permutationMatrix2[secondtLetterRow, firstLetterColumn]);
    }
   Console.WriteLine(encrypt);
}


(int row,int column) SearcIndex(char letter, char[,] matrix)
{
    int row = -1;
    int column = -1;
    for (int i = 0; i < 6; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            if (matrix[i, j] == letter)
            {
                row = i;
                column = j;
                break;
            }
        }
    }
    return (row, column);
}

string[] Syllable(StringBuilder inputValue)
{
    if (inputValue.Length % 2 == 1)
    { 
        inputValue.Append('a');
    }
    string[] heceler = new string[inputValue.Length / 2 + inputValue.Length % 2];
    for (int i = 0; i < inputValue.Length; i += 2)
    {
        heceler[i / 2] = inputValue.ToString().Substring(i, 2);
    }
    return heceler;
}

char[,] AlphabetMatrixCreated()
{
	char[,] alphabeMatrix=new char[6,5];
	int counter = 0;
	for (int i = 0; i < 6; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			alphabeMatrix[i,j] = alphabet[counter];
			counter++;
        }
	}
	return alphabeMatrix;
}

char[,] PermutationAlphabetMatrixCreated(char[] charAlphabet)
{
	Random r=new Random();
    char[,] alphabeMatrix = new char[6, 5];

    for (int i = 0; i < 6; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            int randomIndex = r.Next(0, charAlphabet.Length);
            alphabeMatrix[i, j] = charAlphabet[randomIndex];
            charAlphabet = charAlphabet.Where((val, idx) => idx != randomIndex).ToArray();
        }
    }
    return alphabeMatrix;
}


void DisplayMatrix(char[,] inputMatrix1, char[,] inputMatrix2)
{

    for (int i = 0; i < inputMatrix1.GetLength(0); i++)
    {
        for (int j = 0; j < inputMatrix1.GetLength(1); j++)
        {
            Console.Write($"{inputMatrix1[i, j]} ");
        }
        Console.Write("  ");
        for (int j = 0; j < inputMatrix2.GetLength(1); j++)
        {
            Console.Write($"{inputMatrix2[i, j]} ");
        }
        Console.WriteLine();
    }
}
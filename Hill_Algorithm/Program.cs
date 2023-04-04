using System.Text;

char[] alphabet = { 'a','b','c','ç','d','e','f','g','ğ','h','ı','i','j','k','l','m',
'n','o','ö','p','r','s','ş','t','u','ü','v','y','z'};

string input = "entrika";
input = input.Replace(" ", "").ToLower();
if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("error : incorrect entry");
    return;
}
StringBuilder value = new StringBuilder(input);

int[,] key =  
{
 {6, 22, 5 },
 {11, 16, 10 },
 {19, 13, 21 },
};

var encryptValue = Encrypt(value,key);
Decrypt(encryptValue,key);

StringBuilder Encrypt(StringBuilder inputValue, int[,] key)
{
   
    StringBuilder encryptValue = new StringBuilder();
    Random r = new Random();
    int addLetter = key.GetLength(0)-inputValue.Length%key.GetLength(0) ;
        for (int i = 0; i < addLetter; i++)
        {
            int randomIndex = r.Next(0, alphabet.Length);
            inputValue.Append(alphabet[randomIndex]);
        }
    string[] block = Enumerable.Range(0, inputValue.Length / key.GetLength(0))
        .Select(i => inputValue.ToString().Substring(i * 3, 3)).ToArray();
    int[,] indexs = new int[3, 1];

    for (int i = 0; i < block.Length; i++)
    {
        for (int j = 0; j < key.GetLength(0); j++)
        {
            
            indexs[j,0] = Array.IndexOf(alphabet, block[i][j]);

        }
        encryptValue.Append(MatrixMultiplication(key, indexs));
    }
    Console.WriteLine(encryptValue);
    return encryptValue;
}

StringBuilder Decrypt(StringBuilder encryptValue, int[,] key)
{
   

    StringBuilder dencryptValue = new StringBuilder();

     InverseMatrix(key);
  

    return dencryptValue;
}



StringBuilder MatrixMultiplication(int[,] matrix1, int[,] matrix2)
{
    int rowCount = matrix1.GetLength(0);
    int colCount = matrix2.GetLength(1);
    StringBuilder encryptBlock= new StringBuilder();
    for (int i = 0; i < rowCount; i++)
    {
        for (int j = 0; j < colCount; j++)
        {
            int multiplicationSum = 0;
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                multiplicationSum += matrix1[i, k] * matrix2[k, j];
            }
            encryptBlock.Append(alphabet[multiplicationSum % alphabet.Length]);
        }
    }
    return encryptBlock;
}


void InverseMatrix(int[,] matrix)
{
    Console.WriteLine(GetMinor(matrix, 0, 2));  

}




 int GetMinor(int[,] matrix, int row, int col)
 {
    int size = matrix.GetLength(0);
    int[,] minorMatrix = new int[size - 1, size - 1];

    int minorRow = 0;
    for (int i = 0; i < size; i++)
    {
        if (i == row) continue;
        int minorCol = 0;
        for (int j = 0; j < size; j++)
        {
            if (j == col) continue;

            minorMatrix[minorRow, minorCol] = matrix[i, j];
            minorCol++;
        }
        minorRow++;
    }

    int minor = Determinant2x2(minorMatrix);

    return minor%alphabet.Length;
 }

 int Determinant2x2(int[,] matrix)
{
    if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
    {
        throw new ArgumentException("Matrix must be 2x2.");
    }
    int determinant = (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
    return determinant;
}
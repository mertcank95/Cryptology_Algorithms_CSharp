using System.Diagnostics.Metrics;
using System.Drawing;
using System.Text;

StringBuilder input = new StringBuilder("muaffakiyetsizeleştiricileştiriveremeyebileceklerimizdenmişsinizcesine");

double n = 9;//matris column
double inputLength = input.Length;
int x = (int) Math.Ceiling((double)(inputLength / n));//matris row

Console.WriteLine(Encrypt(input));

StringBuilder Encrypt(StringBuilder inputValue)
{
    /* string value = inputValue.Replace(" ", "").ToString().ToLower();
     if (string.IsNullOrEmpty(value))
         return new StringBuilder("null cannot be encrypted");*/
    StringBuilder encryptValue = new StringBuilder();

    if (n*x > inputLength)
    {
        int addLetter = (int)((n * x) - inputLength);
        inputValue.Append('a',addLetter);
    }
    int col = 0,count=0,row = 7;
    char[,] myarray = new char[x, (int)n];
    while (row >= 0 && col < x)
    {
        myarray[row, col] = inputValue[count];
        //encryptValue.Append(inputValue[count]);
        count++;

        if (row == 0)
        {
            col++;
        }
        else
        {
            row--;
        }
    }

    for (int i = 1; i < 9; i++)
    {
        row = i;
        col = 1;

        while (row < 9 && col < 8)
        {
            myarray[row, col] = inputValue[count];
            count++;

            row++;
            col++;
        }
    }
    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            encryptValue.Append(myarray[i,j]);
        }
     
    }
    Console.WriteLine(encryptValue);
    return encryptValue;
}

/*
for (int i = 0; i < 9; i++)
{
    for (int j = 0; j < 8; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}*/

/*
 
 int[,] matrix = new int[9, 8];

int row = 7, col = 0, count = 1;

while (row >= 0 && col < 8)
{
    matrix[row, col] = count;
    count++;

    if (row == 0)
    {
        col++;
    }
    else
    {
        row--;
    }
}

for (int i = 1; i < 8; i++)
{
    row = 0;
    col = i;

    while (row < 9 && col < 8)
    {
        matrix[row, col] = count;
        count++;

        row++;
        col++;
    }
}

for (int i = 8; i >= 0; i--)
{
    row = i;
    col = 8;

    while (row >= 0 && col >= 0)
    {
        matrix[row, col] = count;
        count++;

        row--;
        col--;
    }
}

matrix[7, 7] = count;

// Matrisi yazdır
for (int i = 0; i < 9; i++)
{
    for (int j = 0; j < 8; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}

 
 
 
 
 */
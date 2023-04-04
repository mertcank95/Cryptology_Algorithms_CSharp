using System.Text;


StringBuilder input = new StringBuilder("muaffakiyetsizeleştiricileştiriveremeyebileceklerimizdenmişsinizcesineas");
double col = 9;//matris column
double inputLength = input.Length;
int row = (int)Math.Ceiling((double)(inputLength / col));//matris row


var encrypt = Encrypt(input);
Console.WriteLine(Encrypt(input));
Console.WriteLine(Decrypt(encrypt)); 
StringBuilder Encrypt(StringBuilder inputValue)
{
    StringBuilder encryptValue;
    char[,] encryptValueMatrix = new char[row, (int)col];
    int index=0;
    for (int i = 0; i < encryptValueMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < encryptValueMatrix.GetLength(1); j++)
        {
            encryptValueMatrix[i, j] = inputValue[index++];
        }
    }
    encryptValue = RouteMatrix(encryptValueMatrix);
    return encryptValue;
}

StringBuilder Decrypt(StringBuilder encryptValue)
{
    StringBuilder decryptValue = new StringBuilder();
    char[,] decryptMatrix= DecryptRouteMatrix(encryptValue);
    for (int i = 0; i < decryptMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < decryptMatrix.GetLength(1); j++)
        {
            decryptValue.Append(decryptMatrix[i, j]);
        }
    }
    return decryptValue;
}


StringBuilder RouteMatrix(char[,] matrix)
{
    StringBuilder encryptValue = new StringBuilder();
    int top = 0;
    int bottom = matrix.GetLength(0) - 1;
    int left = 0;
    int right = matrix.GetLength(1) - 1;
    int direction = 0;
    int i;
    while (top <= bottom && left <= right)
    {
        if (direction == 0)
        {
            for (i = bottom; i >= top; i--)
            {
                encryptValue.Append(matrix[i, left]);
            }
            left++;
        }
        else if (direction == 1)
        {
            for (i = left; i <= right; i++)
            {
                encryptValue.Append(matrix[top, i]);
            }
            top++;
        }
        else if (direction == 2)
        {
            for (i = top; i <= bottom; i++)
            {  
                encryptValue.Append(matrix[i, right]);

            }
            right--;
        }
        else if (direction == 3)
        {
            for (i = right; i >= left; i--)
            {
                encryptValue.Append(matrix[bottom, i]);
            }
            bottom--;
        }
        direction = (direction + 1) % 4;
    }

    return encryptValue;
   
}



char[,] DecryptRouteMatrix(StringBuilder encrypt)
{
    char[,] matrix = new char[row, (int)col];
    StringBuilder decryptValue = new StringBuilder();

    int top = 0;
    int bottom = matrix.GetLength(0) - 1;
    int left = 0;
    int right = matrix.GetLength(1) - 1;
    int direction = 0;
    int i;

    int index = 0;
    while (top <= bottom && left <= right)
    {
        if (direction == 0)
        {
            for (i = bottom; i >= top; i--)
            {
                matrix[i, left] = encrypt[index++];
            }
            left++;
        }
        else if (direction == 1)
        {
            for (i = left; i <= right; i++)
            {
                matrix[top, i] = encrypt[index++];
            }
            top++;
        }
        else if (direction == 2)
        {
            for (i = top; i <= bottom; i++)
            {
                matrix[i, right] = encrypt[index++];
            }
            right--;
        }
        else if (direction == 3)
        {
            for (i = right; i >= left; i--)
            {
                matrix[bottom, i] = encrypt[index++];
            }
            bottom--;
        }
        direction = (direction + 1) % 4;
    }
    return matrix;
}




/*using System.Diagnostics.Metrics;
using System.Drawing;
using System.Text;


double n = 9;//matris column
double inputLength = input.Length;
int x = (int) Math.Ceiling((double)(inputLength / n));//matris row

Console.WriteLine(Encrypt(input));

StringBuilder Encrypt(StringBuilder inputValue)
{
    *//* string value = inputValue.Replace(" ", "").ToString().ToLower();
     if (string.IsNullOrEmpty(value))
         return new StringBuilder("null cannot be encrypted");*//*
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
}*/

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
using System;
using System.Text;


string input = "kriptoloji dersindeyiz";
input = input.Replace(" ", "").ToLower();
int key = 7;
if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("error : incorrect entry");
    return;
}

StringBuilder value = new StringBuilder(input);

var encryptValue = Encrypt(value);

Console.WriteLine( " a : "+ Decrypt(encryptValue)); 
StringBuilder Encrypt(StringBuilder inputValue)
{
    int row = 0;
    bool directionControl = false;
    char[,] encryptMatrix=new char[key,inputValue.Length];
    StringBuilder encryptValue = new StringBuilder();
    for (int i = 0; i < inputValue.Length; i++)
    {
        encryptMatrix[row,i] = inputValue[i];
        if(row == encryptMatrix.GetLength(0)-1)
        {
            directionControl = true;
        }
        else if(row == 0)
        {
            directionControl = false;
        }

        if (directionControl)
            row--;
        else
            row++;
    }

    for (int i = 0; i < encryptMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < encryptMatrix.GetLength(1); j++)
        {
            if (!string.IsNullOrEmpty(encryptMatrix[i, j].ToString()))
            {
                encryptValue.Append(encryptMatrix[i, j]);
                Console.Write(encryptMatrix[i, j]);
            }
            
        }
    }
    return encryptValue;

}



StringBuilder Decrypt(StringBuilder encryptValue)
{
    int row = 0;
    bool directionControl = false;
    char[,] decryptMatrix = new char[key, encryptValue.Length];
    StringBuilder decryptValue = new StringBuilder();
    for (int i = 0; i < encryptValue.Length; i++)
    {
        decryptMatrix[row, i] = '*';
        if (row == decryptMatrix.GetLength(0) - 1)
        {
            directionControl = true;
        }
        else if (row == 0)
        {
            directionControl = false;
        }

        if (directionControl)
            row--;
        else
            row++;

    }
    
        
        int index = 0;
        for (int i = 0; i < decryptMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < decryptMatrix.GetLength(1); j++)
            {
                if(decryptMatrix[i,j] == '*')
                 {
                     decryptMatrix[i, j] = encryptValue[index];
                     index++;
                   // Console.Write(decryptMatrix[i, j]);

                }
            }
            //Console.WriteLine(" ");
        }
        int decryptRow = 0;
        bool a = false;
        for (int i = 0; i < encryptValue.Length; i++)
        {
            decryptValue.Append(decryptMatrix[decryptRow, i]);
            if (decryptRow == decryptMatrix.GetLength(0) - 1)
            {
                a = true;
            }
            else if (decryptRow == 0)
            {
                a = false;
            }

            if (a)
                decryptRow--;
            else
                decryptRow++;
          }

        return decryptValue;

}
using System.Text;

char[] alphabet = { 'a','b','c','ç','d','e','f','g','ğ','h','ı','i','j','k','l','m',
'n','o','ö','p','r','s','ş','t','u','ü','v','y','z'};

string key = "duman";
string input = "şuandakriptolojidersindeyiz";
input = input.Replace(" ", "").ToLower();
if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("error : incorrect entry");
    return;
}

StringBuilder value = new StringBuilder(input);
Console.WriteLine(value);

var encryptValue = Encrypt(value,key);
Decrypt(encryptValue, key);
StringBuilder Encrypt(StringBuilder inputValue,string key)
{
    StringBuilder encryptValue = new StringBuilder();
    int row = (int)Math.Ceiling((double)inputValue.Length / (double)key.Length);
    char[,] encryptValueMatris = new char[row,key.Length];
    Random r = new Random();
    if((row*key.Length)> inputValue.Length)
    {
        int addLetter = ((row * key.Length) - inputValue.Length);
        for (int i = 0; i < addLetter; i++)
        {
            int randomIndex = r.Next(0, alphabet.Length);
            inputValue.Append(alphabet[randomIndex]);
        }
    }
    int counter = 0;
    for (int i = 0; i < encryptValueMatris.GetLength(0); i++)
    {
        for (int j = 0; j < encryptValueMatris.GetLength(1); j++)
        {
            encryptValueMatris[i, j] = value[counter];
            counter++;
        }
        
    }
    var shortByIndexArray = ShortBy(AlphabeIndexValue(key));
    for (int i = 0; i < shortByIndexArray.Length; i++)
    {
        var index = Array.IndexOf(alphabet, key[i]);
        var colIndex = ArrayIndex(shortByIndexArray, index);
        for (int j = 0; j < row; j++)
        {
            encryptValue.Append(encryptValueMatris[j, colIndex]);
        }
    
    }
    Console.WriteLine(encryptValue);
    return encryptValue;
}

StringBuilder Decrypt(StringBuilder encryoptValue, string key)
{
    StringBuilder decryptValue = new StringBuilder();
    int row = (int)Math.Ceiling((double)encryoptValue.Length / (double)key.Length);
    char[,] decryptValueMatris = new char[row, key.Length];
   
    var shortByIndexArray = ShortBy(AlphabeIndexValue(key));
    int counter = 0;
    for (int i = 0; i < shortByIndexArray.Length; i++)
    {
        
        var index = Array.IndexOf(alphabet, key[i]);
        var colIndex = ArrayIndex(shortByIndexArray, index);
        for (int j = 0; j < row; j++)
        {
           decryptValueMatris[j, colIndex] = encryoptValue[counter];
           counter++;
        }
    }
    for (int i = 0; i < decryptValueMatris.GetLength(0); i++)
    {
        for (int j = 0; j < decryptValueMatris.GetLength(1); j++)
        {
            decryptValue.Append(decryptValueMatris[i, j]);
        }
    }

    Console.WriteLine(decryptValue);
    return encryptValue;
}

int ArrayIndex(int[] array,int inputIndex)
{
    int index=-1;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] == inputIndex)
            index = i;
    }
    return index;
}
int[] AlphabeIndexValue(string key)
{
    int[] indexValue = new int[key.Length];

    for (int i = 0; i < indexValue.Length; i++)
    {
        indexValue[i] = Array.IndexOf(alphabet, key[i]);
        Console.WriteLine(indexValue[i]);
    }
    return indexValue;
}


int[] ShortBy(int[] array)
{
    int temp;

    for (int i = 0; i < array.Length - 1; i++)
    {
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[i] > array[j])
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
    return array;
}
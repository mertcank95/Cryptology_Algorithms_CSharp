using System.Text;
char[] alphabet = { 'a','b','c','ç','d','e','f','g','ğ','h','ı','i','j','k','l','m',
'n','o','ö','p','r','s','ş','t','u','ü','v','y','z'};

StringBuilder inputValue = new StringBuilder();
inputValue.Append("prefabrik");
int n = 6;
double inputLength = inputValue.Length;
int block = (int) Math.Ceiling(inputLength / n);
int[] key = { 3, 5, 6, 2, 1, 4 };

Console.WriteLine(inputValue);
var encryptValue = Encrypt(inputValue);
var decryptValur = Decrypt(encryptValue);

Console.WriteLine(encryptValue);
Console.WriteLine(decryptValur);
StringBuilder Encrypt(StringBuilder inputValue)
{
    inputValue = inputValue.Replace(" ", "");
     if (string.IsNullOrEmpty(inputValue.ToString()))
         return new StringBuilder("null cannot be encrypted");
    StringBuilder encryptValue = new StringBuilder();
    Random r = new Random();
    if ((block * n) > inputValue.Length)
    {
        int addLetter =(int) ((block * n) - inputLength);
        for (int i = 0; i < addLetter; i++)
        {
            int randomIndex = r.Next(0,alphabet.Length);
            inputValue.Append(alphabet[randomIndex]);
        }
    }
    for (int i = 0; i < block; i++)
        for (int j = 0; j < n; j++)
            encryptValue.Append(inputValue[(i * n) + key[j] - 1]);
    return encryptValue;
}

StringBuilder Decrypt(StringBuilder encryptValue)
{
    encryptValue = encryptValue.Replace(" ", "");
    if (string.IsNullOrEmpty(encryptValue.ToString()))
        return new StringBuilder("null cannot be encrypted");

    StringBuilder dencryptValue = new StringBuilder();
    for (int i = 0; i < block; i++)
    {
        for (int j = 0; j < n; j++)
        {
            int k = j + 1;
            int index = 0;
            while (k != key[index])
                index++;
            dencryptValue.Append(encryptValue[(i*n)+index]);
        }
    }
    return dencryptValue;
}
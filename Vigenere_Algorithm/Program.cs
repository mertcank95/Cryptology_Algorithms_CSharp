using System.Text;

char[] alphabet = { 'a','b','c','ç','d','e','f','g','ğ','h','ı','i','j','k','l','m',
'n','o','ö','p','r','s','ş','t','u','ü','v','y','z'};

string key = "sevmek";
string input = "kriptoloji mertcan";
input = input.Replace(" ", "").ToLower();
if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("error : incorrect entry");
    return;
}

StringBuilder value = new StringBuilder(input);
var encryptValue = Encrypt(value);
Decrypt(encryptValue);


StringBuilder Encrypt(StringBuilder inputValue)
{
    StringBuilder encryptValue = new StringBuilder();
    /*StringBuilder keyClone =new StringBuilder();
    int j = 0;
    while (inputValue.Length> keyClone.Length)
    {
        keyClone.Append(key[j%key.Length]);
        j++;
    }*/

    for (int i = 0; i < inputValue.Length; i++)
    {
        int inputValueIndex = Array.IndexOf(alphabet, inputValue[i]);
        int keyIndex = Array.IndexOf(alphabet, key[i%key.Length]);
        encryptValue.Append(alphabet[(inputValueIndex+ keyIndex) %alphabet.Length]);
    }
    Console.WriteLine(encryptValue);
    return encryptValue;
}

StringBuilder Decrypt(StringBuilder encryptValue)
{
    StringBuilder decryptValue = new StringBuilder();
    for (int i = 0; i < encryptValue.Length; i++)
    {
        int encryptValueIndex = Array.IndexOf(alphabet, encryptValue[i]);
        int keyIndex = Array.IndexOf(alphabet, key[i%key.Length]);
        int index = encryptValueIndex - keyIndex;
        if (Math.Sign(index) == -1)
            index += alphabet.Length;
        decryptValue.Append(alphabet[index % alphabet.Length]);
    }
    Console.WriteLine(decryptValue);
    return decryptValue;
}
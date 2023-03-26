using System.Text;
//value , 3
char[] alphabet = { 'a','b','c','ç','d','e','f','g','ğ','h','ı','i','j','k','l','m',
'n','o','ö','p','r','s','ş','t','u','ü','v','y','z'};

int alphabetLength = alphabet.Length;
var inputValue = Console.ReadLine();
var encryptValue = Encrypt(inputValue).ToString();
Console.WriteLine(encryptValue);
var decryptValue = Decrypt(encryptValue);
Console.WriteLine(decryptValue);
StringBuilder Encrypt(string inputValue)
{
    string value = inputValue.Replace(" ", "").ToLower();
    if (string.IsNullOrEmpty(value))
		return new StringBuilder("null cannot be encrypted");
	StringBuilder encryptValue = new StringBuilder();
    for (int i = 0; i < value.Length; i++)
	{
		int index = Array.IndexOf(alphabet, value[i]);
		char letter = alphabet[(index + 3) % alphabetLength];
        encryptValue.Append(letter);
	}
	return encryptValue;
}
StringBuilder Decrypt(string encryptValue)
{
    string value = encryptValue.Replace(" ", "").ToLower();
    if (string.IsNullOrEmpty(value))
        return new StringBuilder("null cannot be encryptValue");
    StringBuilder dencryptValue = new StringBuilder();
    for (int i = 0; i < value.Length; i++)
    {
        int index = (Array.IndexOf(alphabet, value[i])) - 3;
        if (Math.Sign(index) == -1)
            index += alphabetLength;
        char letter = alphabet[(index)];
        dencryptValue.Append(letter);
    }
    return dencryptValue;
}


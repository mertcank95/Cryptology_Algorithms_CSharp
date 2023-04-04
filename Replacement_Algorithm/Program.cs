using System.Text;

char[] alphabet = { 'a','b','c','ç','d','e','f','g','ğ','h','ı','i','j','k','l','m',
'n','o','ö','p','r','s','ş','t','u','ü','v','y','z'};

char[] replaceAlphabet = { 'ğ','p','l','i','o','ş','c','u','f','n','y','a','t','z','h','v',
'j','ç','r','g','e','ü','k','b','s','ı','ö','d','m'};

var a = Encrypt("prefabrik");
Console.WriteLine(a);
var b = Decrypt(a.ToString());
Console.WriteLine(b);


StringBuilder Encrypt(string inputValue)
{
    string value = inputValue.Replace(" ", "").ToLower();
    if (string.IsNullOrEmpty(value))
        return new StringBuilder("null cannot be encrypted");
    StringBuilder encryptValue = new StringBuilder();
    for (int i = 0; i < value.Length; i++)
    {
        int index = Array.IndexOf(alphabet, value[i]);
        char letter = replaceAlphabet[index];
        encryptValue.Append(letter);
    }
    return encryptValue;
}

StringBuilder Decrypt(string encryptValue)
{
    string value = encryptValue.Replace(" ", "").ToLower();

    if (string.IsNullOrEmpty(value))
        return new StringBuilder("null cannot be encryptValue");

    StringBuilder decryptValue = new StringBuilder();
    for (int i = 0; i < value.Length; i++)
    {
        int index = Array.IndexOf(replaceAlphabet, value[i]);
        char letter = alphabet[index];
        decryptValue.Append(letter);
    }
    return decryptValue;
}

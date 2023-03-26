using System.Text;
//value,key
char[] alphabet = { 'a','b','c','ç','d','e','f','g','ğ','h','ı','i','j','k','l','m',
'n','o','ö','p','r','s','ş','t','u','ü','v','y','z'};

int alphabetLength = alphabet.Length;
Console.WriteLine("Value : ");
var inputValue = Console.ReadLine();

Console.WriteLine("Key : ");
int inputKey = Convert.ToInt32(Console.ReadLine());

int key = inputKey;


var encryptValue = Encrypt(inputValue,key).ToString();
Console.WriteLine(encryptValue);
var decryptValue = Decrypt(encryptValue,key);
Console.WriteLine(decryptValue);
StringBuilder Encrypt(string inputValue,int key)
{
    string value = inputValue.Replace(" ", "").ToLower();
    if (string.IsNullOrEmpty(value))
        return new StringBuilder("null cannot be encrypted");
    StringBuilder encryptValue = new StringBuilder();
    for (int i = 0; i < value.Length; i++)
    {
        int index = Array.IndexOf(alphabet, value[i]);
        char letter = alphabet[(index + key) % alphabetLength];
        encryptValue.Append(letter);
    }
    return encryptValue;
}
StringBuilder Decrypt(string encryptValue,int key)
{
    string value = encryptValue.Replace(" ", "").ToLower();
    if (string.IsNullOrEmpty(value))
        return new StringBuilder("null cannot be encryptValue");
    StringBuilder dencryptValue = new StringBuilder();
    for (int i = 0; i < value.Length; i++)
    {
        int index = (Array.IndexOf(alphabet, value[i])) - key;
        if (Math.Sign(index) == -1)
            index += alphabetLength;
        char letter = alphabet[(index)];
        dencryptValue.Append(letter);
    }
    return dencryptValue;
}


using System.Text;
//y = ax + b

char[] alphabet = { 'a','b','c','ç','d','e','f','g','ğ','h','ı','i','j','k','l','m',
'n','o','ö','p','r','s','ş','t','u','ü','v','y','z'};

int alphabetLength = alphabet.Length;

int a=5, b=7;
string value = Encrypt("Hello Cryptology", a, b).ToString(); ;
Console.WriteLine(value);
Console.WriteLine(Decrypt(value, a, b)); 
StringBuilder Encrypt(string inputValue, int a,int b)
{
    string value = inputValue.Replace(" ", "").ToLower();
    if (string.IsNullOrEmpty(value))
        return new StringBuilder("null cannot be encrypted");

    if (Math.Sign(a) == -1 || Math.Sign(b) == -1)
        return new StringBuilder("eror : negative number");

    StringBuilder encryptValue = new StringBuilder();
    for (int i = 0; i < value.Length; i++)
    {
        int index = Array.IndexOf(alphabet, value[i]);
        char letter = alphabet[((index * a)+b) % alphabetLength];
        encryptValue.Append(letter);
    }
    return encryptValue;
}


StringBuilder Decrypt(string encryptValue, int a,int b)
{
    string value = encryptValue.Replace(" ", "").ToLower();

    if (string.IsNullOrEmpty(value))
        return new StringBuilder("null cannot be encryptValue");

    if (Math.Sign(a) == -1 || Math.Sign(b) == -1)
        return new StringBuilder("eror : negative number");

    if (!ModInverseControl(a, alphabetLength))
        return new StringBuilder("number has no inverse according to modular arithmetic");

    int j = 0;
    while ((a * j) % alphabetLength != 1)
    {
        j++;
    }
    StringBuilder dencryptValue = new StringBuilder();
    for (int i = 0; i < value.Length; i++)
    {
        int index = (Array.IndexOf(alphabet, value[i])) - b;
        if (Math.Sign(index) == -1)
            index += alphabetLength;
        char letter = alphabet[(index*j) % alphabetLength];
        dencryptValue.Append(letter);
    }
    return dencryptValue;
}

//6-10 false
bool ModInverseControl(int num,int mod)
{
    int gcd = 0;
    for (int i = 1; i <= num && i <= mod; i++)
    {
        if (num % i == 0 && mod % i == 0)
            gcd = i;
    }
    if (gcd == 1)
        return true;
    else
        return false;
}
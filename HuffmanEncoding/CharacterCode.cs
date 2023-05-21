namespace HuffmanEncoding;

public class CharacterCode
{
    public char Character { get; }
    public int Frequency { get; }
    public byte[] Code { get; }

    public CharacterCode(char character, int frequency, byte[] code) {
        Character = character;
        Frequency = frequency;
        Code = code;
    }
}

namespace HackSheffield.Models;

public class TextResponse
{
    public TextResponse(string text)
    {
        data = text;
    }
    public string data{ get; set; }
}
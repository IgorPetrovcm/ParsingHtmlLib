namespace ParsingHtml;
using System.Collection;
public static class CorrectHtmlText
{
    private string CorrectIndentention(int countIndents)
    {

    }
    public static string GetCorrectHtmlText(string text)
    {
        string correctHtml = "";
        
        Stack<char> stack = new Stack<char>();

        int lengthToEndDeclaration = 0;
        while (text[lengthToEndDeclaration] != '>')
        {
            correctHtml += text[lengthToEndDeclaration];
            lengthToEndDeclaration++;
        }
        correctHtml += text[lengthToEndDeclaration];

        int counter = 0;
        for (int i = lengthToEndDeclaration+1; i < text.Length;i++)
        {
            if (text[i] == '<')
            {
                int lengthToEndTag = 0;

                if (text[i + 1] == '/')
                {
                    if (counter > stack.Co)
                }
            }
        }
    }
}

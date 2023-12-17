namespace ParsingHtml;

public static class CorrectHtmlText
{
    private static string CorrectIndentention(int countIndents)
    {
        string indentation = "";
        for (int i = 0; i < countIndents; i++)
        {
            indentation += "    ";
        }

        return indentation;
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
        for (int i = lengthToEndDeclaration + 1; i < text.Length; i++)
        {
            if (text[i] == '<')
            {
                int lengthToEndTag = 0;

                if (text[i + 1] == '/')
                {
                    if (counter > stack.Count)
                    {
                        counter--;
                    }

                    stack.Pop();
                    correctHtml += "\n" + CorrectIndentention(stack.Count);

                    while (text[i + lengthToEndTag] != '<')
                    {
                        correctHtml += text[i + lengthToEndTag];
                        lengthToEndTag++;
                    }

                    correctHtml += text[i + lengthToEndTag];
                    i += lengthToEndTag;
                }

                if (counter > stack.Count)
                {
                    correctHtml += "\n" + CorrectIndentention(stack.Count);
                    counter--;
                }

                stack.Push('<');
                counter++;
                while (text[i + lengthToEndTag] != '>' && text[i + lengthToEndTag] != '/')
                {
                    correctHtml += text[i + lengthToEndTag];
                    lengthToEndTag++;
                }

                if (text[i + lengthToEndTag] == '>')
                {
                    correctHtml += text[i + lengthToEndTag] + "\n" + CorrectIndentention(stack.Count);
                    i += lengthToEndTag;

                    continue;
                }

                if (text[i + lengthToEndTag] == '/')
                {
                    stack.Pop();
                    counter--;
                    correctHtml += text[i + lengthToEndTag].ToString() + text[i + lengthToEndTag + 1].ToString() +
                                   "\n" + CorrectIndentention(stack.Count);
                    i += lengthToEndTag;

                    continue;
                }
            }

            correctHtml += text[i];
        }

        return correctHtml;
    }
}
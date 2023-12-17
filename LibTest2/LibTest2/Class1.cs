namespace ParsingHtml;

public static class CorrectHtmlText
{
    private static string CorrectIndentention(int countIndents)
    {
        if (countIndents < 0) return "";
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

        int stack = 0;

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
                    if (counter > stack)
                    {
                        counter--;
                    }

                    stack--;
                    correctHtml += "\n" + CorrectIndentention(stack);

                    while (text[i + lengthToEndTag] != '<')
                    {
                        correctHtml += text[i + lengthToEndTag];
                        lengthToEndTag++;
                    }

                    correctHtml += text[i + lengthToEndTag];
                    i += lengthToEndTag;
                }

                if (counter > stack)
                {
                    correctHtml += "\n" + CorrectIndentention(stack);
                    counter--;
                }

                stack++;
                counter++;
                while (text[i + lengthToEndTag] != '>' && text[i + lengthToEndTag] != '/')
                {
                    correctHtml += text[i + lengthToEndTag];
                    lengthToEndTag++;
                }

                if (text[i + lengthToEndTag] == '>')
                {
                    correctHtml += text[i + lengthToEndTag] + "\n" + CorrectIndentention(stack);
                    i += lengthToEndTag;

                    continue;
                }

                if (text[i + lengthToEndTag] == '/')
                {
                    stack--;
                    counter--;
                    correctHtml += text[i + lengthToEndTag].ToString() + text[i + lengthToEndTag + 1].ToString() +
                                   "\n" + CorrectIndentention(stack);
                    i += lengthToEndTag;

                    continue;
                }
            }

            correctHtml += text[i];
        }

        return correctHtml;
    }
}
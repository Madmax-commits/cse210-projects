using System;

class Entry
{
    private string _prompt;
    private string _response;
    private string _date;

    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    public string GetPrompt()
    {
        return _prompt;
    }

    public string GetResponse()
    {
        return _response;
    }

    public string GetDate()
    {
        return _date;
    }

    public override string ToString()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}\n";
    }

    public string ToFileFormat(string separator = "~|~")
    {
        return $"{_date}{separator}{_prompt}{separator}{_response}";
    }

    public static Entry FromFileFormat(string line, string separator = "~|~")
    {
        string[] parts = line.Split(new string[] { separator }, StringSplitOptions.None);
        if (parts.Length == 3)
        {
            return new Entry(parts[1], parts[2], parts[0]);
        }
        return null;
    }
}

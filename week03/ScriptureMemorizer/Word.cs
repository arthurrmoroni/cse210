public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        // Replace only letters with underscores, keeping punctuation (e.g. "God," -> "___,")
        string hidden = "";
        foreach (char c in _text)
        {
            hidden += char.IsLetter(c) ? '_' : c;
        }
        return hidden;
    }
}
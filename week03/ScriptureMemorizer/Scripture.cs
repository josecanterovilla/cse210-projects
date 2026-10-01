using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] textWords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in textWords)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> hiddenCandidates = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < numberToHide && hiddenCandidates.Count > 0; i++)
        {
            int index = _random.Next(hiddenCandidates.Count);
            hiddenCandidates[index].Hide();
            hiddenCandidates.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{wordsText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}

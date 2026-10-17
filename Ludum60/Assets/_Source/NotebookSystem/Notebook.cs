using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.NotebookSystem
{
  public class Notebook : MonoBehaviour
  {
    public static Notebook Instance;
    private readonly List<string> _notes = new();
    public event Action OnChanged;
    public IReadOnlyList<string> Notes => _notes;

    void Awake() => Instance = this;

    public void Add(string note)
    {
      if (string.IsNullOrEmpty(note) || _notes.Contains(note)) return;
      _notes.Add(note);
      OnChanged?.Invoke();
    }

    public void Clear()
    {
      _notes.Clear(); 
      OnChanged?.Invoke();
    }
  }
}
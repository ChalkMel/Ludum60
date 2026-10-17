using System;
using System.Collections.Generic;
using UnityEngine;

  namespace _Source.NotebookSystem
  {
    public class Notebook : MonoBehaviour
    {
      public Notebook Instance;
      private readonly List<string> _notes = new();
      public Action OnChanged;
      public IReadOnlyList<string> Notes => _notes;

      private void Awake()
      {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
      }

      public void Add(string note)
      {
        if (string.IsNullOrEmpty(note) || _notes.Contains(note)) return;
        Clear();
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
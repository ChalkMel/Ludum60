using System;
using System.Collections.Generic;
using UnityEngine;

  namespace _Source.NotebookSystem
  {
    public class Notebook : MonoBehaviour
    {
      private readonly List<Note> _notes = new();
      private object _currentOwner;

      public Action OnChanged;
      public IReadOnlyList<Note> Notes => _notes;

      public void Add(object owner, string text)
      {
        if (owner == null || string.IsNullOrEmpty(text)) return;
        
        if (_currentOwner != null && !ReferenceEquals(_currentOwner, owner))
          ClearInternal();

        _currentOwner = owner;
        
        foreach (var n in _notes)
          if (ReferenceEquals(n.Owner, owner) && n.Text == text) return;

        _notes.Add(new Note(owner, text));
        OnChanged?.Invoke();
      }

      public void Clear()
      {
        ClearInternal();
        OnChanged?.Invoke();
      }

      private void ClearInternal()
      {
        _notes.Clear();
        _currentOwner = null;
      }
    }
  }
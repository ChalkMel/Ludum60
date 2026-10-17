using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.NotebookSystem
{
  public class NotebookView : MonoBehaviour
  {
    [SerializeField] private Transform content;
    [SerializeField] private TMPro.TextMeshProUGUI linePrefab;
    [SerializeField] private bool startHidden;
    
    private Notebook _notebook;

    public void Init(Notebook notebook)
    {
      notebook.OnChanged += Refresh;
      _notebook = notebook;
      Refresh();
      if (startHidden)
        gameObject.SetActive(false);
    }

    private void Refresh()
    {
      var toKill = new List<GameObject>(content.childCount);
      foreach (Transform t in content) toKill.Add(t.gameObject);
      foreach (var go in toKill)
      {
        go.transform.SetParent(null);
        Destroy(go);
      }

      foreach (var n in _notebook.Notes)
        Instantiate(linePrefab, content).text = n;
    }

    private void OnDestroy()
    {
      _notebook.OnChanged -= Refresh;
    }
  }
}
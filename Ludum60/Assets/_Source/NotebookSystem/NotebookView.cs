using UnityEngine;

namespace _Source.NotebookSystem
{
  public class NotebookView : MonoBehaviour
  {
    [SerializeField] Transform content;
    [SerializeField] TMPro.TextMeshProUGUI linePrefab;

    void OnEnable()  
    { 
      Notebook.Instance.OnChanged += Refresh;
      Refresh(); 
    }

    void OnDisable()
    {
      Notebook.Instance.OnChanged -= Refresh;
    }

    void Refresh()
    {
      foreach (Transform t in content) Destroy(t.gameObject);
      foreach (var n in Notebook.Instance.Notes)
        Instantiate(linePrefab, content).text = n;
    }
  }
}
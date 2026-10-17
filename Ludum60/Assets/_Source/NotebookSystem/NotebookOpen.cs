using UnityEngine;

namespace _Source.NotebookSystem
{
  public class NotebookOpen : MonoBehaviour
  {
    [SerializeField] private GameObject bigWindow;
    void OnMouseDown() => bigWindow.SetActive(!bigWindow.activeSelf);
  }
}
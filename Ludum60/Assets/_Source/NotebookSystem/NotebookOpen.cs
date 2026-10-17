using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.NotebookSystem
{
  public class NotebookOpen : MonoBehaviour
  {
    [SerializeField] private GameObject bigWindow;
    [SerializeField] private Button button;

    private void Awake()
    {
      button.onClick.AddListener(OpenBigWindow);
    }

    private void OpenBigWindow()
    {
      bigWindow.SetActive(!bigWindow.activeSelf);
    }
  }
}
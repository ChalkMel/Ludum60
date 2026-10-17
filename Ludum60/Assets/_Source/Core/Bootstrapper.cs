using System;
using System.Collections.Generic;
using _Source.DropZones;
using _Source.NotebookSystem;
using UnityEngine;

namespace _Source.Core
{
  public class Bootstrapper : MonoBehaviour
  {
    [SerializeField] Notebook notebook;
    [SerializeField] List<NotebookView> notebookViews = new();
    [SerializeField] LevelController levelController;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] MediaPlayer mediaPlayer;
    [SerializeField] MediaStack mediaStack;
    [SerializeField] Shredder shredder;
    [SerializeField] List<SortBox> sortBoxes = new();
    [SerializeField] EndLevel endLevel;

    private void Awake()
    {
      foreach (var notebookView in notebookViews)
        notebookView.Init(notebook);
      foreach (SortBox sortBox in sortBoxes)
        sortBox.Init(scoreManager);
      shredder.Init(scoreManager);
      mediaPlayer.Init(notebook);
      endLevel.Init(scoreManager, levelController);
      levelController.Init(endLevel);
    }
  }
}
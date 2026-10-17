using System.Collections.Generic;
using _Source.DropZones;
using _Source.NotebookSystem;
using _Source.PhoneSystem;
using UnityEngine;

namespace _Source.Core
{
  public class Bootstrapper : MonoBehaviour
  {
    [SerializeField] private Notebook notebook;
    [SerializeField] private List<NotebookView> notebookViews = new();
    [SerializeField] private LevelController levelController;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private MediaPlayer mediaPlayer;
    [SerializeField] private MediaStack mediaStack;
    [SerializeField] private Shredder shredder;
    [SerializeField] private List<SortBox> sortBoxes = new();
    [SerializeField] private EndLevel endLevel;
    [SerializeField] private Phone phone;
    [SerializeField] private DialogueView dialogueView;
    [SerializeField] private DialerView dialerView;
    [SerializeField] private bool ringOnStart;

    private void Awake()
    {
      foreach (var view in notebookViews) 
        view.Init(notebook);
      foreach (var box in sortBoxes) 
        box.Init(scoreManager);
      shredder.Init(scoreManager);
      mediaPlayer.Init(notebook);
      endLevel.Init(scoreManager, levelController);
      phone.Init(dialogueView, dialerView, notebook);
      levelController.Init(endLevel, phone, ringOnStart);
    }
  }
}
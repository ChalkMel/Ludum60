using UnityEngine;

namespace _Source.Core
{
  public class ScoreManager : MonoBehaviour
  {
    public ScoreManager Instance;
    public int TotalSorted { get; private set; }
    public int Errors { get; private set; }

    void Awake()
    {
      if (Instance && Instance != this)
      {
        Destroy(gameObject); return;
      }
      Instance = this; 
      DontDestroyOnLoad(gameObject);
    }

    public void Record(bool correct) 
    {
      TotalSorted++;
      if (!correct) 
        Errors++; 
    }
    public void Reset() { TotalSorted = 0; Errors = 0; }
  }
}
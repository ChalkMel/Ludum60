using UnityEngine;

namespace _Source.Core
{
  public class ScoreManager : MonoBehaviour
  {
    public int TotalSorted { get; private set; }
    public int Errors { get; private set; }

    public void Record(bool correct) 
    {
      TotalSorted++;
      if (!correct) 
        Errors++; 
    }
    public void Reset() { TotalSorted = 0; Errors = 0; }
  }
}
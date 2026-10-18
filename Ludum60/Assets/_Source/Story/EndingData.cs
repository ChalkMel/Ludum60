using UnityEngine;

namespace _Source.Story
{
  [CreateAssetMenu(menuName = "Game/EndingData")]
  public class EndingData : ScriptableObject
  {
    [TextArea(3, 10)] public string[] DefaultEndingPages;
    [TextArea(3, 10)] public string[] RobotEndingPages;
  }
}
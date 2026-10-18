
using UnityEngine.Localization;
using _Source.Core;
using UnityEngine;

namespace _Source.Story
{
  [CreateAssetMenu(menuName = "Game/EndingData")]
  public class EndingData : ScriptableObject
  {
    [SerializeField] private LocalizedString[] defaultEndingPages;
    [SerializeField] private LocalizedString[] robotEndingPages;

    public string[] DefaultEndingPages => defaultEndingPages.ResolveAll();
    public string[] RobotEndingPages => robotEndingPages.ResolveAll();
  }
}
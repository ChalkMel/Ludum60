using _Source.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace _Source.PhoneSystem
{
  [CreateAssetMenu(menuName = "Game/PhoneData")]
  public class PhoneData : ScriptableObject
  {
    [field:SerializeField] private LocalizedString[] introPages;
    [field:SerializeField] private LocalizedString[] wrongNumberPages;
    [field:SerializeField] private LocalizedString[] noNumberPages;

    public string[] IntroPages => introPages.ResolveAll();
    public string[] WrongNumberPages => wrongNumberPages.ResolveAll();
    public string[] NoNumberPages => noNumberPages.ResolveAll();
  }
}
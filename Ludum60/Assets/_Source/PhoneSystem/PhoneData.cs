using UnityEngine;

namespace _Source.PhoneSystem
{
  [CreateAssetMenu(menuName = "Game/PhoneData")]
  public class PhoneData : ScriptableObject
  {
    [field: SerializeField] public string[] IntroPages { get; private set; }
    [field: SerializeField] public string[] WrongNumberPages {get; private set;}
    [field: SerializeField] public string[] NoNumberPages { get; private set; }
  }
}
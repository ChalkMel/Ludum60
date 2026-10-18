using _Source.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace _Source.Media
{
  public enum MediaType { cassette = 0, disk = 1, floppy = 2, none }
  public enum ContentCategory { professional, news, personal, none }

  [CreateAssetMenu(menuName = "Media/MediaData")]
  public class MediaData : ScriptableObject
  {
    [field:SerializeField] public MediaType Type {get; private set;}
    [field:SerializeField] public int Year{get; private set;}
    [field:SerializeField] public ContentCategory Content{get; private set;}
    [field:SerializeField] public bool IsBroken{get; private set;}
    [field:SerializeField] public bool IsSuspicious{get; private set;}

    [field:SerializeField] public AudioClip Audio {get; private set;}
    [field:SerializeField] public string PhoneNumber { get; private set; }
    [field: SerializeField] public bool IsSecretNumber   { get; private set; }
    [field: SerializeField] public bool IsSpecialCassette { get; private set; }
    [field: SerializeField] public Sprite Sprite  { get; private set; }
    
    [field:SerializeField] private LocalizedString playerNote;
    [field:SerializeField] private LocalizedString magnifierNote;
    [field:SerializeField] private LocalizedString[] phoneTalk;
    public string PlayerNote => playerNote.GetLocalizedString();
    public string MagnifierNote => magnifierNote.GetLocalizedString();
    public string[] PhoneTalk => phoneTalk.ResolveAll();
  }
}
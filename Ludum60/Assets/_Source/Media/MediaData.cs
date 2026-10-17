using UnityEngine;

namespace _Source.Media
{
  public enum MediaType { Cassette = 0, Disk = 1, Floppy = 2 }
  public enum ContentCategory { } //Потом скажут

  [CreateAssetMenu(menuName = "Media/MediaData")]
  public class MediaData : ScriptableObject
  {
    [field:SerializeField] public MediaType Type {get; private set;}
    [field:SerializeField] public int Year{get; private set;}
    [field:SerializeField] public ContentCategory Content{get; private set;}
    [field:SerializeField] public bool IsBroken{get; private set;}
    [field:SerializeField] public bool IsSuspicious{get; private set;}

    [field:SerializeField] public AudioClip Audio {get; private set;}
    [field:SerializeField] public string PlayerNote{get; private set;}
    [field:SerializeField] public string MagnifierNote{get; private set;}
    [field:SerializeField] public string PhoneNumber { get; private set; }
    [field: SerializeField] public string[] PhoneTalk { get; private set; }
  }
}
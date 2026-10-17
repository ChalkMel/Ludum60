using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.PhoneSystem
{
  [RequireComponent(typeof(Button))]
  public class DigitButton : MonoBehaviour
  {
    [SerializeField] private TMP_Text label;

    public string Value => label != null ? label.text : string.Empty;

    public Button Button => GetComponent<Button>();
  }
}
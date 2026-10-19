using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace _Source.Core
{
  public class TypewriterText : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI label;
    [Tooltip("Символов в секунду")]
    [SerializeField] private float charsPerSecond = 40f;

    private Coroutine _routine;

    public bool IsPlaying { get; private set; }

    private void Awake()
    {
      if (label == null) label = GetComponent<TextMeshProUGUI>();
      label.maxVisibleCharacters = 0;
    }

    public void Play(string text, Action onDone = null)
    {
      Stop();
      _routine = StartCoroutine(Run(text ?? string.Empty, onDone));
    }
    
    public void Complete()
    {
      if (!IsPlaying) return;
      Stop();
      label.maxVisibleCharacters = int.MaxValue;
    }
    
    public void Stop()
    {
      if (_routine != null)
      {
        StopCoroutine(_routine);
        _routine = null;
      }
      IsPlaying = false;
    }

    private IEnumerator Run(string fullText, Action onDone)
    {
      IsPlaying = true;

      label.text = fullText;
      label.maxVisibleCharacters = 0;
      label.ForceMeshUpdate();

      int total = label.textInfo.characterCount;
      float t = 0f;

      while (label.maxVisibleCharacters < total)
      {
        t += Time.deltaTime * charsPerSecond;
        label.maxVisibleCharacters = Mathf.Min(total, Mathf.FloorToInt(t));
        yield return null;
      }

      label.maxVisibleCharacters = total;
      IsPlaying = false;
      _routine = null;
      onDone?.Invoke();
    }
  }
}
using System;
using _Source.Media;

namespace _Source.Core
{
  public static class GameSession
  {
    public static bool SecretNumberCalled { get; private set; }
    public static bool RobotEndingTriggered { get; private set; }

    public static event Action<MediaItem> OnSpecialCassettePickedUp;

    public static void MarkSecretNumberCalled()
    {
      if (SecretNumberCalled) return;
      SecretNumberCalled = true;
    }

    public static void NotifySpecialCassettePickedUp(MediaItem item)
    {
      OnSpecialCassettePickedUp?.Invoke(item);
    }

    public static void MarkRobotEndingTriggered()
    {
      if (RobotEndingTriggered) return;
      RobotEndingTriggered = true;
    }
  }
}
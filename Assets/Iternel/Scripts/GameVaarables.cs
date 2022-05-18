using UnityEngine;

public class GameVaarables
{
    public const float RotationSpeed = 0.5f;
    public const float DeletingTime = 5;
    public const float SpawnRange = 100;
    public const float JumpForce = 150;
    public const float PlatformMovingSpeed = 0.035f;
    public const float PlatformDelayRange = 5;
    public const float PlayerMaxJump = 4;

    public static void NextLevel () {
        try
        {
            var lvl = PlayerPrefs.GetInt ("Level");
            lvl++;
            PlayerPrefs.SetInt ("Level", lvl);
        }
        catch
        {
            PlayerPrefs.SetInt ("Level", 1);
        }
    }
}
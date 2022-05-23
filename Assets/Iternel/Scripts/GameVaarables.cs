using UnityEngine;

public class GameVaarables
{
    public const float RotationSpeed = 0.7f;
    public const float DeletingTime = 5;
    public const float SpawnRange = 100;
    public const float JumpForce = 150;
    public const float PlatformMovingSpeed = 0.035f;
    public const float PlatformDelayRange = 5;
    public const float PlayerMaxJump = 4;

    public const int MaxAlgIncrement = 10; // ћаксимальное прибавление или убавление с + и -
    public const float MaxGeoIncrement = 3; // ћаксимальное умножение или деление

    private static int PlatformCount;
    private static int Level;
    public static int ReachedPlatforms { get; private set; }

    public static void GameStarted () {
        GetPlatformCount ();
        GetLevel ();
        ReachedPlatforms = 0;
        CurrentCoins = 0;
    }

    public static bool AddReachedPlatform () {
        ReachedPlatforms++;
        if (ReachedPlatforms >= PlatformCount) return true;
        else return false;
    }

    public static int CurrentCoins { get; private set; }

    public static void UpdateCoins (int coins) {
        CurrentCoins = coins;
    }
    public static int GetPlatformCount () {
        PlatformCount = GetLevel () + 5;
        return PlatformCount;
    }

    public static void NextLevel () {
        Level = GetLevel ();
        Level++;
        SaveLevel ();
    }

    public static int GetLevel () {
        try
        {
            Level = PlayerPrefs.GetInt ("Level");
        }
        catch
        {
            Level = 1;
        }
        if (Level <= 0) Level = 1;

        return Level;
    }

    private static void SaveLevel () {
        PlayerPrefs.SetInt ("Level", Level);
    }
}
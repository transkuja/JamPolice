using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData {
    public static bool hasImmunity = false;
    public static int currentCheckpoint;

    public static void Reset()
    {
        hasImmunity = false;
        currentCheckpoint = 0;
        // TODO: clear collectibles
    }

    public static void Respawn()
    {
        hasImmunity = false;
    }

}

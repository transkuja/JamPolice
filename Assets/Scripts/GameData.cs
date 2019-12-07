using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData {
    public static bool hasImmunity = false;
    public static Checkpoint currentCheckpoint;

    public static void Reset()
    {
        hasImmunity = false;
        currentCheckpoint = null;
        // TODO: clear collectibles
    }

    public static void Respawn()
    {
        hasImmunity = false;
    }

}

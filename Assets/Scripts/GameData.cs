using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData {
    public static bool hasImmunity = false;
    public static Checkpoint currentCheckpoint;

    private static int donutscount = 0;

    static GameUI uiref;

    public static int Donutscount
    {
        get
        {
            return donutscount;
        }

        set
        {
            donutscount = value;
        }
    }

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

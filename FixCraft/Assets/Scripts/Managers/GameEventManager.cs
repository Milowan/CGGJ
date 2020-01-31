using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager
{

    public delegate void GameEvent();

    public static event GameEvent GameStart;
    public static event GameEvent GameOver;
    public static event GameEvent Pause;
    public static event GameEvent UnPause;

    public static void TriggerGameStart()
    {
        if (GameStart != null)
        {
            GameStart();
        }
    }

    public static void TriggerGameOver()
    {
        if (GameOver != null)
        {
            GameOver();
        }
    }

    public static void TriggerPause()
    {
        if (Pause != null)
        {
            Pause();
        }
    }

    public static void TriggerUnPause()
    {
        if (UnPause != null)
        {
            UnPause();
        }
    }

}

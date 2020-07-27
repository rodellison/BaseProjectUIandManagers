using System.Collections;
using System.Collections.Generic;
using Base_Project._Scripts.Game_Events;
using UnityEngine;

public class Scene_Manager : MonoBehaviour
{
    public GameEventWithInt LevelStarted;

    public void InitializeScene()
    {
        Debug.Log("Initializing Scene");
    }

    public void InitializeLevel(int level)
    {
        //Do something to initialize the state of this scene's level to some state..
        Debug.Log("Initializing level: " + level);
        LevelStarted.Raise(level);
    }
}

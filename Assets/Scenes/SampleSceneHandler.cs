using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class SampleSceneHandler : MonoBehaviour
{
    public GameEvent WonGame;

    public GameEvent LostGame;


    public void SendWonGameEvent()
    {
        StartCoroutine(delaySend(true));
    }

    public void SendLostGameEvent()
    {
        StartCoroutine(delaySend(false));
    }

    IEnumerator delaySend(bool wonTheGame)
    {
        yield return new WaitForSeconds(2f);
        if (wonTheGame)
            WonGame.Raise();
        else
            LostGame.Raise();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private MoveMatchChecker moveMatchChecker;
    [SerializeField] private float matchValue;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private int sequenceIndex;

    private void OnEnable()
    {
        MoveMatchChecker.OnTimesUp += HandleTimeUp;
        MoveMatchChecker.OnReachCheckpoint += HandleOnReachCheckPoint;
    }

    private void OnDisable()
    {
        MoveMatchChecker.OnTimesUp -= HandleTimeUp;
        MoveMatchChecker.OnReachCheckpoint -= HandleOnReachCheckPoint;
    }

    // We will use a sequence of events to trigger different sounds
    // We will also use some float values to drive sound changes

    //1. Start - Ambient Sound - plays until checkpoint (play on awake)
    //2. Checkpoint sound:
    private void HandleOnReachCheckPoint()
    {
        //play the checkpoint sound
        audioSources[2].Play();
        Debug.Log("checkpoint reached");
        //buzzing sound starts
        audioSources[0].Stop();
        audioSources[1].Play();
    }


    private void HandleTimeUp()
    {
        //
    }



}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private MoveMatchChecker moveMatchChecker;
    [SerializeField] private float matchValue;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private int instructionIndex;

    private void OnEnable()
    {
        MainSequenceManager.IdleState += HandleIdle; 
        MainSequenceManager.NewInstruction += HandleNewInstruction;
        MainSequenceManager.TimesUp += HandleTimesUp;
    }

    private void OnDisable()
    {
        MainSequenceManager.IdleState -= HandleIdle;
        MainSequenceManager.TimesUp -= HandleNewInstruction;
        MainSequenceManager.TimesUp -= HandleTimesUp;
    }

    // Bunch of specific event (trigger) handlers

    private void HandleIdle()
    {

    }

    private void HandleNewInstruction()
    {

    }

    private void HandleTimesUp()
    {

    }

    // "match value" feedback method


}
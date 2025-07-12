using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainSequenceManager : MonoBehaviour
{
    private int eventSequenceIndex = -1;

    private bool isCoroutineRunning = false;

    /* The core game loop is an instruction, we need to check if "matchpair objects" match
        Each sequence event (the core game loop) we need:
        (some sequence of things that happen at set intervals)
        we will use a coroutine for this

    */

    /* We will manage a sequence of events that:
     1. Has a core "game loop"
     2. Has some durational changes */

    // So we can fire some event triggers for the other scripts
    public static Action IdleState;
    public static Action NewInstruction;
    public static Action TimesUp;

    // Handle CORE GAME LOOP   as well as durational changes in the Update Loop
    void Start()
    {
        eventSequenceIndex++;
        StartCoroutine(InstructionLoop());
    }

    private void Update()
    {
        if (!isCoroutineRunning)
        {
            eventSequenceIndex++;
            StartCoroutine(InstructionLoop());
        }
    }

    private IEnumerator InstructionLoop()
    {
        // Start
        isCoroutineRunning = true;

        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        IdleState?.Invoke();

        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        //Debug.Log("New Instruction Called");
        
        NewInstruction?.Invoke();

        yield return new WaitForSeconds(6f);
        
        TimesUp?.Invoke();

        isCoroutineRunning = false;
    }

    public int GetSequenceIndex()
    {
        return eventSequenceIndex;
    }
}

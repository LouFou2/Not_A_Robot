using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyManager : MonoBehaviour
{
    //The MainSequenceManager will control the whole game and InstructionLoop - start/instruction/end
    //Action IdleState
    //Action NewInstruction
    //Action TimesUp

    [SerializeField] private MainSequenceManager seqManager;
    [SerializeField] private Animator[] animators; // Animator array for the Dummy animation clips
    [SerializeField] private int instructionIndex = -1;//-1: like a false


    private void OnEnable()
    {
        // Subscribe: This is a place that LISTEN from what the "boss"(namely the main script) require
        // So we can set up the same name for diffierent tasks
        // example:"HandledIdle"/"HandledInstruction"/"HandledTimesUp" are diffiernt tasks required
        // Diffiernt Script Managers control diffierent department: "Sound Manager"/"Animation Manager"...
        // So when the "boss" call "IdleState", all the Manager will listen to it and fire the event relates IdleState

        MainSequenceManager.IdleState += HandleIdle;
        MainSequenceManager.NewInstruction += HandleInstruction;
        MainSequenceManager.TimesUp += HandleIdle; // anims go to idle state when times up
    }

    private void OnDisable()
    {
        //Unsubscribe: This is a place that stop LISTEN when the system stop
        MainSequenceManager.IdleState -= HandleIdle;
        MainSequenceManager.NewInstruction -= HandleIdle;
        MainSequenceManager.TimesUp -= HandleIdle;
    }
    

    private void HandleIdle()
    {
        //Debug.Log("Dummies Handling Idle");

        ResetAllAnimParams();

        // Iterate: instructions for all objects in the array ("foreach" loop or "for" loop)
        // "animators": the name of the array (like a group)
        // "animator": each animator in the group 
        foreach (Animator animator in animators)
        {
            //"Idle": ***The same name for this script and other managers
            animator.SetBool("Idle", true);
        }
    }

    private void HandleInstruction()
    {
        //What we want here: when the boss call the HandleInstruction method, Play diffierent animator from the animators array
        instructionIndex = seqManager.GetSequenceIndex();
        //Debug.Log("SeqIndex: " + instructionIndex);
        //Debug.Log("Dummies Handling Instruction");
        
        ResetAllAnimParams();

        foreach (Animator animator in animators)
        {
            switch (instructionIndex)
            {
                case 0:
                    animator.SetBool("Idle", true);
                    break;
                case 1:
                    animator.SetBool("Balance", true);
                    break;
                case 2:
                    animator.SetBool("Cheer", true);
                    break;
                case 3:
                    animator.SetBool("LeanLeft", true);
                    break;
                case 4:
                    animator.SetBool("LeanRight", true);
                    break;
                case 5:
                    animator.SetBool("PullTogether", true);
                    break;
                case 6:
                    animator.SetBool("RaiseHand", true);
                    break;
                case 7:
                    animator.SetBool("ReachHigh", true);
                    break;
                case 8:
                    animator.SetBool("Hello", true);
                    break;
                case 9:
                    animator.SetBool("Straighten", true);
                    break;
                case 10:
                    animator.SetBool("TouchToes", true);
                    break;
                case 11:
                    animator.SetBool("ShakeLoose", true);
                    break;
                default:
                    Debug.Log("Dummy Manager has no instruction to handle");
                    break;

            }
        }
    }

    private void ResetAllAnimParams()
    {
        //Debug.Log("Dummies Anims Resetting");

        foreach (Animator animator in animators)
        {
            //"Idle": ***The same name for this script and 
            animator.SetBool("Idle", false);
            animator.SetBool("Balance", false);
            animator.SetBool("Cheer", false);
            animator.SetBool("LeanLeft", false);
            animator.SetBool("LeanRight", false);
            animator.SetBool("PullTogether", false);
            animator.SetBool("RaiseHand", false);
            animator.SetBool("ReachHigh", false);
            animator.SetBool("Hello", false);
            animator.SetBool("Straighten", false);
            animator.SetBool("TouchToes", false);
            animator.SetBool("ShakeLoose", false);
        }
    }



}

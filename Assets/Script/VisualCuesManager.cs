using UnityEngine;

public class VisualCuesManager : MonoBehaviour
{
    [SerializeField] private MainSequenceManager seqManager;
    [SerializeField] private MoveMatchChecker moveMatchChecker;
    [SerializeField] private float matchValue;
    [SerializeField] private GameObject titleObject;
    [SerializeField] private GameObject[] textObjects; // make sure idle is at 0 index
    [SerializeField] private int instructionIndex;

    [SerializeField] private Material timerMat;
    [SerializeField] float timePassed = 0f;
    [SerializeField] bool timerIsCountingDown = false;

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

    private void Start()
    {
        ResetTextObjects();
    }

    // Bunch of specific event (trigger) handlers

    private void HandleIdle()
    {
        ResetTextObjects();
        textObjects[0].SetActive(true);
    }

    // We need a timer countdown to control the timer circle radial wipe
    private void Update()
    {
        if (timerIsCountingDown)
        {
            timePassed += Time.deltaTime;

            // the duration of the instruction is 6f: hardcoded in the Sequence Manager (could expose this for inspector)
            float fill = Mathf.Clamp01(timePassed / 6f);
            timerMat.SetFloat("_Fill", fill);
        }
        else
        {
            timePassed = 0f;
            timerMat.SetFloat("_Fill", 0f);
        }
    }

    private void HandleNewInstruction()
    {
        if (titleObject != null) titleObject.SetActive(false);

        instructionIndex = seqManager.GetSequenceIndex();

        timerIsCountingDown = true;

        switch (instructionIndex)
        {
            case 0:
                ResetTextObjects();
                textObjects[0].SetActive(true);
                break;
            case 1:
                ResetTextObjects();
                textObjects[1].SetActive(true);
                break;
            case 2:
                ResetTextObjects();
                textObjects[2].SetActive(true);
                break;
            case 3:
                ResetTextObjects();
                textObjects[3].SetActive(true);
                break;
            case 4:
                ResetTextObjects();
                textObjects[4].SetActive(true);
                break;
            case 5:
                ResetTextObjects();
                textObjects[5].SetActive(true);
                break;
            case 6:
                ResetTextObjects();
                textObjects[6].SetActive(true);
                break;
            case 7:
                ResetTextObjects();
                textObjects[7].SetActive(true);
                break;
            case 8:
                ResetTextObjects();
                textObjects[8].SetActive(true);
                break;
            case 9:
                ResetTextObjects();
                textObjects[9].SetActive(true);
                break;
            case 10:
                ResetTextObjects();
                textObjects[10].SetActive(true);
                break;
            case 11:
                ResetTextObjects();
                textObjects[11].SetActive(true);
                break;
            default:
                Debug.Log("No Instruction To Show Text");
                break;
        }
    }

    private void ResetTextObjects()
    {
        foreach (GameObject textObjects in textObjects)
        {
            textObjects.SetActive(false);
        }
    }
    private void HandleTimesUp()
    {
        timerIsCountingDown = false;
    }

    // "match value" feedback method
}

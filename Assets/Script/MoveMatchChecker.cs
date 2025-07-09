using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveMatchChecker : MonoBehaviour
{
    [SerializeField] private Matchpair[] matchPairs;

    [SerializeField] private float duration;
    private int time;

    [System.Serializable]
    public class Matchpair
    {
        public string matchPairName;
        public GetObjectData instructorObjectScript;
        public GetObjectData userObjectScript;
        public float maxDistance = 0.4f;
        public float closeEnoughThreshold = 0.1f;

        public float matchValue;
        public float averageMatchValue;
        public bool isMatch = false;
    }

    // we want a acion/ event that can be subscribed to be other scripts called OnTimesUp...
    public static Action OnTimesUp;
    public static Action OnReachCheckpoint;


    private void Start()
    {
        
    }

    void Update()
    {
        time ++;

        // Iterate over each Matchpair in the matchPairs array
        foreach (var matchpair in matchPairs)
        {
            // Ensure the instructorObjectScript and userObjectScript are assigned
            if (matchpair.instructorObjectScript != null && matchpair.userObjectScript != null)
            {
                // Get the target and control positions
                Vector3 instructorPos = matchpair.instructorObjectScript.GetTargetPos();
                Vector3 userPos = matchpair.userObjectScript.GetTargetPos();

                // Calculate the distance and match value
                float distance = Vector3.Distance(instructorPos, userPos);
                matchpair.matchValue = Mathf.InverseLerp(0, matchpair.maxDistance, distance);

                // Update the average match value
                matchpair.averageMatchValue += matchpair.matchValue;
                matchpair.averageMatchValue /= time;

                // Check if the match value is within the acceptable threshold
                if (time >= duration)
                {
                    // Fire the OnTimesUp event
                    OnTimesUp?.Invoke();

                    // Handle the time's up logic
                    HandleTimesUp(matchpair);

                    // Reset the match pair
                    Reset(matchpair);
                }
            }
        }

    }

    // We awant to return a 0-1 value that is the Match %
    // (how much does the user-controlled object match the target object)
    public float GetMatchValue(string matchPairName)
    {
        float matchValue = -1;
        foreach (var matchpair in matchPairs)
        {
            if (matchpair.matchPairName == matchPairName)
            {
                matchValue = matchpair.matchValue;
            }
        }
        return matchValue;
    }

    public bool IsMatch(string matchPairName)
    {
        bool isMatch = false;
        foreach (var matchpair in matchPairs)
        {
            if (matchpair.matchPairName == matchPairName)
            {
                isMatch = matchpair.isMatch;
            }
        }
        return isMatch;
    }
    
    private void HandleTimesUp(Matchpair matchpair)
    {
        matchpair.isMatch = matchpair.averageMatchValue <= matchpair.closeEnoughThreshold;
    }


    private void Reset(Matchpair matchpair)
    {
        matchpair.averageMatchValue = 0;
        time = 0;
    }
}

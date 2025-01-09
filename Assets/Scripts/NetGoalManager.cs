using System.Collections;
using UnityEngine;

public class NetGoalManager : MonoBehaviour
{
    public int currentLevel = 0; // Tracks the current level the ball is passing

    private void Update()
    {
        if (currentLevel == 3)
        {
            Debug.Log("Goal Scored!");
            ResetProgress(); // Reset for the next attempt
        }
    }

    private IEnumerator CheckForWins()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(10f);

        // Check the level status after the delay
        if (currentLevel <= 2)
        {
            Debug.Log("Failed to score, resetting progress.");
            ResetProgress();
        }
        else if (currentLevel == 3)
        {
            Debug.Log("Goal Scored!");
            ResetProgress(); // Reset for the next attempt
        }
    }

    private void ResetProgress()
    {
        // Reset the progress tracking variable
        currentLevel = 0;
        Debug.Log("Progress Reset!");
    }

    public void TriggerWinCheck()
    {
        // Start the coroutine to check for a win condition
        StartCoroutine(CheckForWins());
    }
}
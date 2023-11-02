using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelTransition : MonoBehaviour
{
    public TextMesh scoreTextMesh; // Reference to your TextMesh
    public Canvas levelCompleteCanvas; // Reference to your canvas
    public float delayTime = 3.0f; // Adjust the delay time as needed

    private bool gameMode = false; // Flag to indicate game mode

    private void Start()
    {
        // Initially, disable the canvas
        levelCompleteCanvas.enabled = false;
    }

    public void ShowLevelCompleteCanvas()
    {
        // Show the canvas
        levelCompleteCanvas.enabled = true;

        // Start a delay before moving to the next level
        StartCoroutine(DelayBeforeNextLevel());
    }

    private IEnumerator DelayBeforeNextLevel()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Enable game mode
        gameMode = true;

        // Update the TextMesh during the delay
        UpdateScoreTextMesh("New Score: 100"); // Replace with your score value

        // Add code here to perform actions after the delay:
        // For example, load the next level
        LoadNextLevel();

        // Optionally, hide the canvas after the delay
        levelCompleteCanvas.enabled = false;
    }

    // Replace this with your code for transitioning to the next level
    private void LoadNextLevel()
    {
        // Add your logic to load the next level here
        // For example, you can use SceneManager.LoadScene("NextLevelName");
    }

    // Call this function to update the TextMesh
    public void UpdateScoreTextMesh(string newText)
    {
        if (gameMode && scoreTextMesh != null)
        {
            scoreTextMesh.text = newText;
        }
    }
}

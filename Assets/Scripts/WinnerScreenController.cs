using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WinnerScreenController : NetworkBehaviour
{
    public static bool gameHasEnded = false;

    // Reference the end screen UI to control it
    public GameObject endScreenUI;

    public TextMeshProUGUI winnerText;

    /// <summary>
    /// Function to show the winner screen ui with the winner text
    /// </summary>
    /// <param name="winner">the name of the winner</param>
    [ClientRpc]
    public void RpcEndGame(string winner)
    {
        // Show the end screen ui
        endScreenUI.SetActive(true);
        // Freeze time
        Time.timeScale = 0f;
        gameHasEnded = true;

        winnerText = GameObject.Find("WinnerText").GetComponent<TextMeshProUGUI>();
        winnerText.text = winner + " wins!!!";
    }

    // Function to reset the game
    [ClientRpc]
    public void RpcResetButtonClicked()
    {       
            Time.timeScale = 1f;
            gameHasEnded = false;
            // Reload current scene to reset everything
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);      
    }

    // Function to exit back to the start menu
    [ClientRpc]
    public void RpcExitButtonClick()
    {      
            Time.timeScale = 1f;
            gameHasEnded = false;
    }
}

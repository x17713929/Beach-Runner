using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public GameObject completelevelUI;

    public void CompleteLevel()
    {
        completelevelUI.SetActive(true);
    }


    public void GameOver()
    {

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            FindObjectOfType<AudioManager>().Play("PlayerFail");
            SceneManager.LoadScene("LevelFailScene", LoadSceneMode.Single);

        }
    }
        

    }



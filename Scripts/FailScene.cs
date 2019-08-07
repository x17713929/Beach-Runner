using UnityEngine;
using UnityEngine.SceneManagement;



public class FailScene : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1",LoadSceneMode.Single);
    }

    public void ExittoMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }



}

using UnityEngine;
using UnityEngine.SceneManagement;


public class Credit : MonoBehaviour
{
    public void ExittoMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}

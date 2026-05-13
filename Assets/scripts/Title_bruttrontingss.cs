using UnityEngine;
using UnityEngine.SceneManagement;
public class bruttrontingss : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

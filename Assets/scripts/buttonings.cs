using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonings : MonoBehaviour
{
   public void RestartLevel()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

}

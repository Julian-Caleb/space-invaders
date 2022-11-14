using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
     public void RetryGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);

    }

    public void MenuGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-3);


    }
}

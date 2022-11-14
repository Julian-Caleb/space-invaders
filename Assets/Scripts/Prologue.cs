using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    public void ContinueGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }
}

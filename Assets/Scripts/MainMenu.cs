using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour {

    public void PlayGame() {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
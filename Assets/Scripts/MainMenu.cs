using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }

    public void QuitGame() {

        Application.Quit();

    }

    // Game Over One

    public void MenuOne() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-3);

    }

    public void RetryOne() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);

    }

    // Game Over Two

    public void MenuTwo() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-5);

    }

    public void RetryTwo() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-3);

    }

    // Game Over Three wtf

    public void MenuThree() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-9);

    }

    public void RetryThree() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-7);

    }

    // You Win

    public void MenuFour() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-10);

    }


}
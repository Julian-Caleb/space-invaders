using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip otherClip;

    public static AudioManager instance;

    public string stopAtScene;

    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = otherClip;
        audio.Play();
    }

    void Awake() {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if (scene.name == stopAtScene)
        {
            Destroy(gameObject);
            Debug.Log("The music stopped!");
        }
    }

}
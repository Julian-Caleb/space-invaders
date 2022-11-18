using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class AudioManagerDestroy : MonoBehaviour
{
    public AudioClip otherClip;
    public static AudioManagerDestroy instance;
    public bool loop;

    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = otherClip;
        audio.loop = loop;
        audio.Play();
    }

    // void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    // {
    //     if (scene.name == "Prologue")
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(instance);
    //         SceneManager.sceneLoaded += OnSceneLoaded;
    //     } 
    // }

}
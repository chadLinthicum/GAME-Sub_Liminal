using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();

        // Prevent this game object from being destroyed when a new scene is loaded
        DontDestroyOnLoad(audioSource);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
    }
}

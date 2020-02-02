using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class IntroVideoScreen : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    public GameObject continueText;

    private int time;
    private int maxTime = 2000;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayStartScreen());
    }
    private void Update()
    {
        LoadNextScene();
        time++;
        if(time >= maxTime)
        {
            continueText.SetActive(true);
        }
    }
    IEnumerator PlayStartScreen()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while(!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
    }
    void LoadNextScene()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
}


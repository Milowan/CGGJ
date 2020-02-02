using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class WinScene : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    public GameObject CreditsText1;
    public GameObject CreditsText2;
    public GameObject CreditsText3;
    public GameObject CreditsText4;
    public GameObject CreditsText5;
    public GameObject CreditsText6;
    public GameObject CreditsText7;
    public GameObject CreditsText8;
    public GameObject CreditsText9;
    public GameObject CreditsText10;

    private int time;
    private int maxTime = 2700;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayWinScreen());
    }
    private void Update()
    {
        LoadNextScene();
        time++;
        if (time == 900)
        {
            CreditsText1.SetActive(true);
        }
        else if(time == 1100)
        {
            CreditsText2.SetActive(true);
        }
        else if (time == 1300)
        {
            CreditsText3.SetActive(true);
        }
        else if (time == 1500)
        {
            CreditsText4.SetActive(true);
        }
        else if (time == 1700)
        {
            CreditsText5.SetActive(true);
        }
        else if (time == 1900)
        {
            CreditsText6.SetActive(true);
        }
        else if (time == 2100)
        {
            CreditsText7.SetActive(true);
        }
        else if (time == 2300)
        {
            CreditsText8.SetActive(true);
        }
        else if (time == 2500)
        {
            CreditsText9.SetActive(true);
        }
        else if (time >= maxTime)
        {
            CreditsText10.SetActive(true);
        }
    }
    IEnumerator PlayWinScreen()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
}

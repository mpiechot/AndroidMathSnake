using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class StartUIControll : MonoBehaviour {
    public PostProcessingProfile profile;

    void Start()
    {
        profile.depthOfField.enabled = true;
        profile.vignette.enabled = true;
    }
    public void OnThirdPersonStart()
    {
        SceneManager.LoadScene("ThirdPersonGame");
        profile.depthOfField.enabled = false;
        profile.vignette.enabled = false;
        Debug.Log("Third Person");
    }
    public void OnTopDownStart()
    {
        SceneManager.LoadScene("ClassicGame");
        profile.depthOfField.enabled = false;
        profile.vignette.enabled = false;
        Debug.Log("Top Down");
    }
    public void OnHighscoreStart()
    {
        Debug.Log("Highscore");
        profile.depthOfField.enabled = true;
        profile.vignette.enabled = true;
        SceneManager.LoadScene("Highscore");
    }
    public void OnQuitStart()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void OnHighscoreBackStart()
    {
        Debug.Log("Highscore-Back");
        SceneManager.LoadScene("StartScene");
    }
}

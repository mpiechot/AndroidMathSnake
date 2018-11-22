using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class StartUIControll : MonoBehaviour {
    public PostProcessingProfile profile;

    private static float startIntensity;
    private static float startFocalLength;
    private static float minusFocalLength;
    private static float minusVignIntens;
    private static DepthOfFieldModel.Settings setDOF;
    private static VignetteModel.Settings setVignette;

    void Start()
    {
        profile.depthOfField.enabled = true;
        profile.vignette.enabled = true;

        setDOF = profile.depthOfField.settings;
        setVignette = profile.vignette.settings;

        startIntensity = setVignette.intensity;
        startFocalLength = setDOF.focalLength;

        minusFocalLength = startFocalLength / 100;
        minusVignIntens = startIntensity / 100;

    }
    public void OnThirdPersonStart()
    {
        SceneManager.LoadScene("ThirdPersonGame");
        StartCoroutine(focusOff());
        Debug.Log("Third Person");
    }
    public void OnTopDownStart()
    {
        SceneManager.LoadScene("ClassicGame");
        StartCoroutine(focusOff());
        Debug.Log("Top Down");
    }
    public void OnHighscoreStart()
    {
        Debug.Log("Highscore");
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

    public static IEnumerator focusOn()
    {
        int iCounter = 0;
        Debug.Log("Start");
        while (iCounter <= 100)
        {
            Debug.Log("Counter: " + iCounter);
            setDOF.focalLength += minusFocalLength;
            setVignette.intensity += minusVignIntens;
            iCounter++;
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("Stop");
        yield return new WaitForSeconds(10f);
    }
    private IEnumerator focusOff()
    {
        while (profile.depthOfField.settings.focalLength > 0)
        {
            setDOF.focalLength -= minusFocalLength;
            setVignette.intensity -= minusVignIntens;

            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("StopFocusOff");
        yield return new WaitForSeconds(3f); ;
    }
}

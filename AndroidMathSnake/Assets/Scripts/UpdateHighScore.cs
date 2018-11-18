using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpdateHighScore : MonoBehaviour {

    public Text congrats;
    public InputField nameInput;
    public Button saveBack;
    public Text labelName;
    public Text inputPlaceholder;
    public PostProcessingProfile profile;

    private int score;
    private int place = -1;

	// Use this for initialization
	void Start () {
        profile.depthOfField.enabled = true;
        profile.vignette.enabled = true;
        score = PlayerValues.Score;
        bool placeFound = false;

        int moveScore = -1;
        string moveName = "-";
        for(int i = 0; i < 10; i++)
        {
            Debug.Log("PlaceFound: " + placeFound + "\nScore: " + score + "==" + PlayerPrefs.GetInt("score" + i));
            if(!placeFound && PlayerPrefs.GetInt("score"+i) <= score)
            {
                place = i;
                placeFound = true;

                moveScore = PlayerPrefs.GetInt("score" + i);
                moveName = PlayerPrefs.GetString("name" + i);
                continue;
            }
            if (placeFound)
            {
                int moveScore2 = PlayerPrefs.GetInt("score" + i);
                string moveName2 = PlayerPrefs.GetString("name" + i);

                PlayerPrefs.SetInt("score" + i, moveScore);
                PlayerPrefs.SetString("name" + i, moveName);

                moveName = moveName2;
                moveScore = moveScore2;
            }
        }
        if(place >= 0)
        {
             congrats.text = "Congratulations! You reached " + score + " points!\n That is Number " + (place+1) + " in our highscore table!" +
             "\n please type in a name to represent you in this highscore table.";
        }
        else
        {
            congrats.text = "Congratulations! You reached " + score + " points!\n You need " + (PlayerPrefs.GetInt("score9") - score +1) + " more points for our Highscore table!";
            saveBack.GetComponentInChildren<Text>().text = "Back";
            labelName.enabled = false;
            nameInput.GetComponent<Image>().enabled = false;
            inputPlaceholder.enabled = false;

        }
	}

    public void OnUpdateSaveStart()
    {
        Debug.Log("Update-Save");
        if(place >= 0)
        {
            PlayerPrefs.SetInt("score" + place, score);
            PlayerPrefs.SetString("name" + place, nameInput.text);
        }
        SceneManager.LoadScene("StartScene");
    }
}

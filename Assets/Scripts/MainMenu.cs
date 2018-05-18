using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text hiScoreText;

	// Use this for initialization
	void Start () {
		hiScoreText.text = "BEST: " + ((int) PlayerPrefs.GetFloat("Highscore")).ToString();
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }
}

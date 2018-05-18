using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public Text scoreText;
    public Image backgroundImg;
    public Text hiScoreText;

    private bool isShown = false;

    private float transition =0.0f;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isShown)
            return;

        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
	}

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int) score).ToString();
        hiScoreText.text = "BEST: " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
        isShown = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

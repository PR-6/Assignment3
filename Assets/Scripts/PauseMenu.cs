using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	public Text pausedText;
	public GameObject playButton;
	public GameObject restartButton;
	public GameObject menuButton;
	public GameObject saveButton;
	int livesRemaining;
	//TODO SAVE BUTTON

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			}
			else if (Time.timeScale == 0)
			{
				Debug.Log("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}
	}

	public void Reload()
	{
		pauseControl();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void mainMenu()
	{
		pauseControl();
		SceneManager.LoadScene(0);
	}

	public void pauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePaused();
		}
	}

	public void showPaused()
	{
		pausedText.gameObject.SetActive(true);
		playButton.gameObject.SetActive(true);
		restartButton.gameObject.SetActive(true);
		menuButton.gameObject.SetActive(true);
		saveButton.gameObject.SetActive(true);
	}

	public void hidePaused()
	{
		pausedText.gameObject.SetActive(false);
		playButton.gameObject.SetActive(false);
		restartButton.gameObject.SetActive(false);
		menuButton.gameObject.SetActive(false);
		saveButton.gameObject.SetActive(false);

	}

	public void saveGame()
    {
		PlayerPrefStore newSave = new PlayerPrefStore();
		newSave.Score = PlayerPrefs.GetInt("Score");
		newSave.PlayerName = PlayerPrefs.GetString("PlayerName");
		newSave.CarSpeed = PlayerPrefs.GetInt("CarSpeed");
		newSave.LivesRemaining = PlayerPrefs.GetInt("LivesRemaining");
		//newSave.PlayMusic = PlayerPrefs.GetInt("PlayMusic")==1?true:false;
		newSave.PlayMusic = PlayerPrefs.GetInt("PlayMusic");

		string json = JsonUtility.ToJson(newSave);
		Debug.Log(json);
		SaveIntoJson(json);
		mainMenu();
	}

	public void SaveIntoJson(string json)
	{
		System.IO.File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
	}
}

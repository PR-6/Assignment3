using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GamePlayController : MonoBehaviour
{
    //PlayerName:
    public InputField playerName;

    //Lives DropDown:
    List<string> playerLives = new List<string>() { "3", "4", "5" };
    public Dropdown dropdown;

    //Slider for CarSpeed:
    public Slider sliderUI;
    private Text textSliderValue;

    //Play Music:
    public GameObject playMusicToggle;

    // Standard Functions:
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        PopulateList();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Start()
    {
        textSliderValue = GetComponent<Text>();
        ShowSliderValue();
    }

    // PlayerName Logic:
    public void setPlayerName()
    {
        Debug.Log(playerName.text);
        PlayerPrefs.SetString("PlayerName", playerName.text);
    }

    //Dropdown lives Logic:
    public void DropDownIndexChanged(int index)
    {
        Debug.Log("Lives = " + playerLives[index]);
        PlayerPrefs.SetInt("LivesRemaining", int.Parse(playerLives[index]));
    }

    void PopulateList()
    {
        dropdown.AddOptions(playerLives);
    }

    //Slider Speed logic:
    public void ShowSliderValue()
    {
        string sliderMessage = "Car Speed: " + sliderUI.value;
        textSliderValue.text = sliderMessage;
        PlayerPrefs.SetInt("CarSpeed", (int)sliderUI.value);
        Debug.Log("Car Speed Set to: " + sliderUI.value);
    }

    // Play Music
    public void SetPlayMusic()
    {
        Debug.Log(playMusicToggle.GetComponent<Toggle>().isOn);
        PlayerPrefs.SetInt("PlayMusic", playMusicToggle ? 1 : 0);
    }

    public void LoadGame()
    {
        string text = System.IO.File.ReadAllText(Application.persistentDataPath + "/saveData.json");
        Debug.Log("Save Data: " + text);
        var json = JsonUtility.FromJson<PlayerPrefStore>(text);
        PlayerPrefs.SetInt("Score", json.Score);
        PlayerPrefs.SetString("PlayerName", json.PlayerName);
        PlayerPrefs.SetInt("CarSpeed", json.CarSpeed);
        PlayerPrefs.SetInt("LivesRemaining", json.LivesRemaining);
		PlayerPrefs.GetInt("PlayMusic", json.PlayMusic);
    }

    public int getCarSpeed()
    {
        return PlayerPrefs.GetInt("CarSpeed", 0);
    }
}

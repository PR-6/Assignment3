using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
	public Text livesText;

	void Update()
    {
		livesText.text = "Lives: " + PlayerPrefs.GetInt("LivesRemaining").ToString();
    }

	void EndLives()
    {
        livesText.text = "Lives Remaining: " + PlayerPrefs.GetInt("LivesRemaining").ToString();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	void OnTriggerEnter2D ()
	{
		Debug.Log("YOU WON!");
		PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + 100);
		if (PlayerPrefs.GetInt("Score", 0) > 1000)
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		else
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		
	}

}

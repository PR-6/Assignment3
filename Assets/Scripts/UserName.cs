using UnityEngine;
using UnityEngine.UI;

public class UserName : MonoBehaviour
{
	public Text userText;

	void Update()
	{
		userText.text = PlayerPrefs.GetString("PlayerName").ToString();
	}

}
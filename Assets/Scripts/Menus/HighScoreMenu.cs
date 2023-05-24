using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Retrieves and displays high score and listens for
/// the OnClick events for the high score menu button
/// </summary>
public class HighScoreMenu : MonoBehaviour
{
	[SerializeField]
	TextMeshProUGUI message;

	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
    {
		// pause the game when added to the scene
		Time.timeScale = 0;

		// retrieve and display high score
		if (PlayerPrefs.HasKey("High Score"))
        {
			message.text = "Your High Score: " + PlayerPrefs.GetInt("High Score");
		}
        else
        {
			message.text = "High Score\nNo games played yet";
		}
	}

	/// <summary>
	/// Handles the on click event from the quit button
	/// </summary>
	public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);

        // unpause game and go to main menu
        Time.timeScale = 1;
		MenuManager.GoToMenu(MenuName.Main);
	}
}

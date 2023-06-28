using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// The HUD for the game
/// </summary>
public class HUD : MonoBehaviour
{
	#region Fields

	// score support
	[SerializeField]
	TextMeshProUGUI scoreText;
	int score = 0;

	// health support
	[SerializeField]
	Slider healthBar;

	// timer support
	[SerializeField]
	TextMeshProUGUI timerText;

	#endregion

	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
    {
		// add listener for PointsAddedEvent
		EventManager.AddListener(EventName.PointsAddedEvent, HandlePointsAddedEvent);

		// initialize score text
		scoreText.text = "Score: " + score;

		// add listener for HealthChangedEvent
		EventManager.AddListener(EventName.HealthChangedEvent, HandleHealthChangedEvent);

		// add listener for TimerChangedEvent and initialize timer text
		EventManager.AddListener(EventName.TimerChangedEvent, HandleTimerChangedEvent);
		timerText.text = ConfigurationUtils.TotalGameSeconds.ToString();
	}

	#region Properties

	/// <summary>
	/// Gets the score
	/// </summary>
	/// <value>the score</value>
	public int Score
    {
		get { return score; }
	}

	#endregion

	#region Private methods

	/// <summary>
	/// Handles the points added event by updating the displayed score
	/// </summary>
	/// <param name="points">points to add</param>
	private void HandlePointsAddedEvent(int points)
    {
		score += points;
		scoreText.text = "Score: " + score;
	}

	/// <summary>
	/// Handles the health changed event by changing
	/// the health bar value
	/// </summary>
	/// <param name="value">health value</param>
	void HandleHealthChangedEvent(int value)
    {
		healthBar.value = value;
	}

	/// <summary>
	/// Handles the timer changed event by updating the displayed timer
	/// </summary>
	/// <param name="value">timer value</param>
	void HandleTimerChangedEvent(int value)
    {
		timerText.text = value.ToString();
	}
		
	#endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Listens for the OnClick events for the difficulty menu buttons
/// </summary>
public class DifficultyMenu : IntEventInvoker
{
	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
    {
		// add event component and add invoker to event manager
		unityEvents.Add(EventName.GameStartedEvent, new GameStartedEvent());
		EventManager.AddInvoker(EventName.GameStartedEvent, this);
	}

	/// <summary>
	/// Handles the on click event from the easy button
	/// </summary>
	public void HandleEasyButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        unityEvents[EventName.GameStartedEvent].Invoke((int)Difficulty.Easy);
	}

	/// <summary>
	/// Handles the on click event from the medium button
	/// </summary>
	public void HandleMediumButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        unityEvents[EventName.GameStartedEvent].Invoke((int)Difficulty.Medium);
	}

	/// <summary>
	/// Handles the on click event from the hard button
	/// </summary>
	public void HandleHardButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        unityEvents[EventName.GameStartedEvent].Invoke((int)Difficulty.Hard);
	}
}

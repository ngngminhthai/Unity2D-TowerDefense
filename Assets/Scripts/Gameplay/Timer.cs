using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A timer
/// </summary>
public class Timer : MonoBehaviour
{
	#region Fields

	// timer duration
	float totalSeconds = 0;

	// timer execution
	float elapsedSeconds = 0;
	bool running = false;

	// support for countdown seconds values
	int previousCountdownValue;

	// support for Finished property
	bool started = false;

	// events invoked by class
	TimerChangedEvent timerChangedEvent = new TimerChangedEvent();
	TimerFinishedEvent timerFinishedEvent = new TimerFinishedEvent();

	#endregion

	#region Properties

	/// <summary>
	/// Sets the duration of the timer
	/// The duration can only be set if the timer isn't currently running
	/// </summary>
	/// <value>duration</value>
	public float Duration
    {
		set
        {
			if (!running)
            {
				totalSeconds = value;
			}
		}
	}

	/// <summary>
	/// Gets whether or not the timer has finished running
	/// This property returns false if the timer has never been started
	/// </summary>
	/// <value><c>true</c> if finished; otherwise, <c>false</c>.</value>
	public bool Finished
    {
		get { return started && !running; } 
	}

	/// <summary>
	/// Gets whether or not the timer is currently running
	/// </summary>
	/// <value><c>true</c> if running; otherwise, <c>false</c>.</value>
	public bool Running
    {
		get { return running; }
	}

	/// <summary>
	/// Gets the timer changed event object
	/// This is needed so consumers of the class than
	/// use a reference to this object rather than creating
	/// their own "middleman" event object
	/// </summary>
	/// <value>The timer changed event.</value>
	public TimerChangedEvent TimerChangedEvent
    {
		get { return timerChangedEvent; }
	}

    #endregion

    #region Public methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
		// update timer
		if (running)
        {
			elapsedSeconds += Time.deltaTime;

			// check for new countdown value
			int newCountdownValue = GetCurrentCountdownValue();
			if (newCountdownValue != previousCountdownValue)
            {
				previousCountdownValue = newCountdownValue;
				timerChangedEvent.Invoke(previousCountdownValue);
			}

			// check for timer finished
			if (elapsedSeconds >= totalSeconds)
            {
				running = false;
				timerFinishedEvent.Invoke();
			}
		}
	}

	/// <summary>
	/// Runs the timer
	/// Because a timer of 0 duration doesn't really make sense,
	/// the timer only runs if the total seconds is larger than 0
	/// This also makes sure the consumer of the class has actually 
	/// set the duration to something higher than 0
	/// </summary>
	public void Run()
    {
		// only run with valid duration
		if (totalSeconds > 0)
        {
			started = true;
			running = true;
			elapsedSeconds = 0;

			// calculate initial countdown value and fire event
			previousCountdownValue = GetCurrentCountdownValue();
			timerChangedEvent.Invoke(previousCountdownValue);
		}
	}

	/// <summary>
	/// Stops the timer
	/// </summary>
	public void Stop()
    {
		started = false;
		running = false;
	}

	/// <summary>
	/// Adds the given event handler as a listener
	/// </summary>
	/// <param name="handler">the event handler</param>
	public void AddTimerChangedEventListener(UnityAction<int> handler)
    {
		timerChangedEvent.AddListener(handler);
	}

	/// <summary>
	/// Adds the given event handler as a listener
	/// </summary>
	/// <param name="handler">the event handler</param>
	public void AddTimerFinishedEventListener(UnityAction handler)
    {
		timerFinishedEvent.AddListener(handler);
	}

	#endregion

	#region Private methods

	/// <summary>
	/// Gets the current countdown value
	/// </summary>
	/// <returns>the current countdown value</returns>
	int GetCurrentCountdownValue()
    {
		return (int)Mathf.Ceil(totalSeconds - elapsedSeconds);
	}

	#endregion
}

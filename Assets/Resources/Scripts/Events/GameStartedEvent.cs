using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event that indicates a game should be started with
/// the given difficulty
/// </summary>
public class GameStartedEvent : UnityEvent<int>
{
}

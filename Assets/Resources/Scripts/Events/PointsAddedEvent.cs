using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event that indicates that points have been added
/// to the player score
/// </summary>
public class PointsAddedEvent : UnityEvent<int>
{
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// French fries
/// </summary>
public class FrenchFries : IntEventInvoker
{
	[SerializeField]
	GameObject prefabExplosion;

	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
    {		
		// apply impulse force to get projectile moving
		GetComponent<Rigidbody2D>().AddForce(
			new Vector2(0, ConfigurationUtils.FrenchFriesImpulseForce),
			ForceMode2D.Impulse);

		// add as invoker for PointsAddedEvent
		unityEvents.Add(EventName.PointsAddedEvent, new PointsAddedEvent());
		EventManager.AddInvoker(EventName.PointsAddedEvent, this);
	}

    /// <summary>
    /// Called when the french fries become invisible
    /// </summary>
    void OnBecameInvisible()
    {
		// destroy the game object
		EventManager.RemoveInvoker(EventName.PointsAddedEvent, this);
		Destroy(gameObject);
	}

	/// <summary>
	/// Processes trigger collisions with other game objects
	/// </summary>
	/// <param name="other">information about the other collider</param>
	void OnTriggerEnter2D(Collider2D other)
    {
		// if colliding with teddy bear, add score and destroy teddy bear and self
		if (other.gameObject.CompareTag("TeddyBear"))
        {
			unityEvents[EventName.PointsAddedEvent].Invoke(ConfigurationUtils.BearPoints);
			Instantiate(prefabExplosion, 
				other.gameObject.transform.position, Quaternion.identity);
			Destroy(other.gameObject);
			Instantiate(prefabExplosion, 
				transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
        else if (other.gameObject.CompareTag("TeddyBearProjectile"))
        {
			// if colliding with teddy bear projectile, destroy projectile and self
			Instantiate(prefabExplosion, 
				other.gameObject.transform.position, Quaternion.identity);
			Destroy(other.gameObject);
			Instantiate(prefabExplosion, 
				transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}

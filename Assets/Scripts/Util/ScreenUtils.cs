using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenUtils : MonoBehaviour
{
	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
    {	
		// cache reusable values for efficiency
		PhysicsMaterial2D screenEdgeMaterial = Resources.Load("ScreenEdgeMaterial") as PhysicsMaterial2D;
		float zLocation = -Camera.main.transform.position.z;

		// add left edge collider
		EdgeCollider2D collider = gameObject.AddComponent<EdgeCollider2D>();
		Vector3[] screenEndPoints = new Vector3[2];
		Vector3[] worldEndPoints = new Vector3[2];
		Vector2[] colliderEndPoints = new Vector2[2];
		screenEndPoints[0].x = 0;
		screenEndPoints[0].y = Screen.height;
		screenEndPoints[0].z = zLocation;
		worldEndPoints[0] = Camera.main.ScreenToWorldPoint(screenEndPoints[0]);
		colliderEndPoints[0].x = worldEndPoints[0].x;
		colliderEndPoints[0].y = worldEndPoints[0].y;
		screenEndPoints[1].x = screenEndPoints[0].x;
		screenEndPoints[1].y = 0;
		screenEndPoints[1].z = zLocation;
		worldEndPoints[1] = Camera.main.ScreenToWorldPoint(screenEndPoints[1]);
		colliderEndPoints[1].x = worldEndPoints[1].x;
		colliderEndPoints[1].y = worldEndPoints[1].y;
		collider.points = colliderEndPoints;
		collider.sharedMaterial = screenEdgeMaterial;

		// add right edge collider
		collider = gameObject.AddComponent<EdgeCollider2D>();
		screenEndPoints[0].x = Screen.width;
		screenEndPoints[0].y = Screen.height;
		screenEndPoints[0].z = zLocation;
		worldEndPoints[0] = Camera.main.ScreenToWorldPoint(screenEndPoints[0]);
		colliderEndPoints[0].x = worldEndPoints[0].x;
		colliderEndPoints[0].y = worldEndPoints[0].y;
		screenEndPoints[1].x = screenEndPoints[0].x;
		screenEndPoints[1].y = 0;
		screenEndPoints[1].z = zLocation;
		worldEndPoints[1] = Camera.main.ScreenToWorldPoint(screenEndPoints[1]);
		colliderEndPoints[1].x = worldEndPoints[1].x;
		colliderEndPoints[1].y = worldEndPoints[1].y;
		collider.points = colliderEndPoints;
		collider.sharedMaterial = screenEdgeMaterial;

		// add top edge collider
		collider = gameObject.AddComponent<EdgeCollider2D>();
		screenEndPoints[0].x = 0;
		screenEndPoints[0].y = Screen.height;
		screenEndPoints[0].z = zLocation;
		worldEndPoints[0] = Camera.main.ScreenToWorldPoint(screenEndPoints[0]);
		colliderEndPoints[0].x = worldEndPoints[0].x;
		colliderEndPoints[0].y = worldEndPoints[0].y;
		screenEndPoints[1].x = Screen.width;
		screenEndPoints[1].y = screenEndPoints[0].y;
		screenEndPoints[1].z = zLocation;
		worldEndPoints[1] = Camera.main.ScreenToWorldPoint(screenEndPoints[1]);
		colliderEndPoints[1].x = worldEndPoints[1].x;
		colliderEndPoints[1].y = worldEndPoints[1].y;
		collider.points = colliderEndPoints;
		collider.sharedMaterial = screenEdgeMaterial;

		// add bottom edge collider
		collider = gameObject.AddComponent<EdgeCollider2D>();
		screenEndPoints[0].x = 0;
		screenEndPoints[0].y = 0;
		screenEndPoints[0].z = zLocation;
		worldEndPoints[0] = Camera.main.ScreenToWorldPoint(screenEndPoints[0]);
		colliderEndPoints[0].x = worldEndPoints[0].x;
		colliderEndPoints[0].y = worldEndPoints[0].y;
		screenEndPoints[1].x = Screen.width;
		screenEndPoints[1].y = screenEndPoints[0].y;
		screenEndPoints[1].z = zLocation;
		worldEndPoints[1] = Camera.main.ScreenToWorldPoint(screenEndPoints[1]);
		colliderEndPoints[1].x = worldEndPoints[1].x;
		colliderEndPoints[1].y = worldEndPoints[1].y;
		collider.points = colliderEndPoints;
		collider.sharedMaterial = screenEdgeMaterial;
	}	
}

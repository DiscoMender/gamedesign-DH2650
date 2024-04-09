using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetector : MonoBehaviour
{
	void OnCollisionEnter2D (Collision2D collisionInfo)
	{
		if (collisionInfo.collider.name == "player") {
			Destroy(gameObject);
		}
	}
}

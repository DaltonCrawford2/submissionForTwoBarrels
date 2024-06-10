using UnityEngine;
using System.Collections;

public class timedMovement2 : MonoBehaviour
{
	// Tuned Enemy Stats.
	
	public float villianSpeed = 15.0f;
	
	public int villianHealth = 3;
	
	public int movementCounter;		
	
	void Start ()
	{
		movementCounter = 0;
	}
	
	void Update () 
	{
		
		// This count which I have established to increase each frame, 
		// will indicate which direction the enemy will move in that frame.
		movementCounter += 1;
		
		
		if (movementCounter >= 0 && movementCounter <= 100)
		{
			transform.Translate(Vector3.forward * villianSpeed);
		}
		
		if (movementCounter >= 101 && movementCounter <= 200)
		{
			transform.Translate(Vector3.right * villianSpeed);
		}
		
		if (movementCounter >= 201 && movementCounter <= 300)
		{
			transform.Translate(-Vector3.forward * villianSpeed);
		}
		
		if (movementCounter >= 301 && movementCounter <= 400)
		{
			transform.Translate(-Vector3.right * villianSpeed);
			if (movementCounter == 400)
			{
				movementCounter = 0;
			}
		}		
	}
	
	
	void OnMouseDown()
	{
		// When User clicks on this enemy, then a ray cast will be shot to determine the i.d. while this object
		// takes damage. Once HP has been depleted, it will be destroyed.
		villianHealth -= 1;
		if (villianHealth <= 0)
		{
			DestroyObject(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		// This will send a msg to the lazerBeam script, telling it to destroy the lazer [clone] 
		// game object that touches this enemy.
		if (other.name == "LazerAmmo(Clone)")
		{
			print ("FEEL THE BURN!");
			bool beenHit = true;
			GameObject PlayerLazerGameObject = GameObject.Find ("playerLazer");
			PlayerLazerGameObject.GetComponent<lazerBeam>().HitTarget(beenHit);
		}
	}
}

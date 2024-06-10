using UnityEngine;
using System.Collections;

public class bossShipMoves : MonoBehaviour 
{
	
	// Tuned Enemy Stats.
	
	public float villianSideSpeed = 100.0f;
	
	public float villianForwardSpeed = 0.5f;
	
	public int villianHealth = 50;
	
	public int movementCounter;
	
	// Use this for initialization
	void Start () 
	{
		//
		movementCounter = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//
		// This count which I have established to increase each frame, 
		// will indicate which direction the enemy will move in that frame.
		movementCounter += 1;
		
		
		if (movementCounter >= 0 && movementCounter <= 80)
		{
			transform.Translate(Vector3.forward * villianForwardSpeed);
			transform.Translate (Vector3.right * villianSideSpeed);
		}
		
		if (movementCounter >= 81 && movementCounter <= 160)
		{
			transform.Translate(Vector3.forward * villianForwardSpeed);
			transform.Translate (-Vector3.right * villianSideSpeed);
			
		}
		
		if (movementCounter >= 161 && movementCounter <= 240)
		{
			transform.Translate(Vector3.forward * villianForwardSpeed);
			transform.Translate (Vector3.right * villianSideSpeed);
		}
		
		if (movementCounter >= 241 && movementCounter <= 320)
		{
			transform.Translate(Vector3.forward * villianForwardSpeed);
			transform.Translate (-Vector3.right * villianSideSpeed);
			
		}
		
		if (movementCounter >= 321 && movementCounter <= 400)
		{
			transform.Translate(-Vector3.forward * villianForwardSpeed);
			transform.Translate (Vector3.right * villianSideSpeed);
			
		}
		if (movementCounter >= 401 && movementCounter <= 480)
		{
			transform.Translate(-Vector3.forward * villianForwardSpeed);
			transform.Translate (-Vector3.right * villianSideSpeed);
			
		}
		
		if (movementCounter >= 481 && movementCounter <= 560)
		{
			transform.Translate(-Vector3.forward * villianForwardSpeed);
			transform.Translate (Vector3.right * villianSideSpeed);
			
		}
		if (movementCounter >= 561 && movementCounter <= 640)
		{
			transform.Translate(-Vector3.forward * villianForwardSpeed);
			transform.Translate (-Vector3.right * villianSideSpeed);
			if (movementCounter == 640)
			{
				movementCounter = 0;
			}
			
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		// This will send a msg to the lazerBeam script, telling it to destroy the lazer [clone] 
		// game object that touches this enemy.
		if (other.name == "LazerAmmo(Clone)")
		{
			print ("KABOOM SON!");
			bool beenHit = true;
			GameObject PlayerLazerGameObject = GameObject.Find ("playerLazer");
			PlayerLazerGameObject.GetComponent<lazerBeam>().HitTarget(beenHit);
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
	
}

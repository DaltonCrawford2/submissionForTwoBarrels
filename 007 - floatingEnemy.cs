using UnityEngine;
using System.Collections;

public class floatingEnemy : MonoBehaviour 
{
	// Tuned Enemy Stats.
	
	public float villianSpeed = 5.0f;
	
	public int villianHealth = 3;
	
	public int movementCounter;		
	
	// Use this for initialization
	void Start ()
	{
		movementCounter = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		// 
		transform.Rotate(Vector3.up * villianSpeed);		
		
		movementCounter += 1;
		
		if (movementCounter >= 0 && movementCounter <= 20)
		{
			transform.Translate(Vector3.up * villianSpeed);
		}
		
		if (movementCounter >= 21 && movementCounter <= 40)
		{
			transform.Translate(-Vector3.up * villianSpeed);
			if (movementCounter == 40)
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

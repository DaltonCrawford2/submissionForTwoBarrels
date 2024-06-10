using UnityEngine;
using System.Collections;

public class SeekPlayer1 : MonoBehaviour 
{
	// Tuned Enemy Stats.
	
	public float villianSpeed = 25.0f;
	public float spinSpeed = 15.0f;
	public float attackDistance = 0.50f;
	
	public int villianHealth = 5;
	
	private GameObject playerOne = null;
	
	
	void Start ()
	{
		// Storing Values at the launch of the game.
		playerOne = GameObject.Find("player1");
	}
	
	void Update () 
	{
			
		// Determine the deistance between this enemy and the user.
		// Vector3 distanceToPlayer = transform.position - playerOne.transform.position;
		
		// This is performed so that the enemy can decide for itself what to do
		// based on the distance between itself and the user.
		if (Vector3.Distance(transform.position, playerOne.transform.position) >= attackDistance)
		{
			//Will set phasers to kill.
			seekOut();
			print ("i'm gonna get you!");
		}
		else 
		{
			// Will keep the enemy constatly moving if possible.
			Move();
		}
	}
	
	
	void Move()
	{
		// The original idea here, was that if the user wasn't in the vacinity, 
		// the enemy would just spin around peacefully.
		transform.Rotate(Vector3.up * spinSpeed);
		
	}
	
	void seekOut()
	{
		// If called, this enemy will now face the player controlled gamObject and head in that direction.
		transform.LookAt(playerOne.transform);
		transform.Translate(Vector3.forward * villianSpeed);
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
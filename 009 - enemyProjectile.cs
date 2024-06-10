using UnityEngine;
using System.Collections;

public class enemyProjectile : MonoBehaviour 
{
	
	public float bombSpeed = 75.0f;
	public float spinSpeed = 50.0f;
	public int movementCounter;
	
	
	void Start () 
	{
		movementCounter = 0;
		
	}
	
	void Update () 
	{
		// What my goal here is for after "x" amount of frames while the Boss is facing the player, it shoots these bombs.
		
		movementCounter += 1;
		
		if (movementCounter < 200)
		{
			// 
			transform.Translate(Vector3.up * bombSpeed);
			transform.Rotate(Vector3.up * spinSpeed);
		}
		
		if (movementCounter == 301)
		{
			// I want the bomb to head towards the player ... but after a certain time it will just stop ...
			// some frames later it will be gone.
			
			Destroy (gameObject);
		}
		
	}
}

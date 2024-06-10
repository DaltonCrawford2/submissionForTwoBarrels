using UnityEngine;
using System.Collections;

public class shootingStars : MonoBehaviour 
{
	
	// This Script is so that every so many frames, a moving spawner will generate
	// a new projectile and hurl it forward. These will be harmful to the player.
	
	public float moveSpeed = 600.0f;

	public int movementCounter;
	
	public int reloadTime = 33;
	public int shotCounter;
	
	
	public GameObject comet = null;
	
	
	void Start () 
	{
		// At launch, these to counting variables will be set to 0. From there they will begin to add each frame and thus "count."
		movementCounter = 0;
		shotCounter = 0;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		// Adding to the count in between shots. Each time it reaches a predetermined number, it will
		// instantiate a comet and reset it's count.
		shotCounter += 1;
		
		if (shotCounter == reloadTime)
		{
			Instantiate(comet, transform.position, transform.rotation);
			shotCounter = 0;
		}
		
		
		// Adding to the count that will determine the spawner's movement/direction.
		movementCounter += 1;
		
		if (movementCounter >= 0 && movementCounter <= 100)
		{
			transform.Translate(-Vector3.right * moveSpeed);
		}
		if (movementCounter >= 101 && movementCounter <= 200)
		{
			transform.Translate(Vector3.right * moveSpeed);
			
			if (movementCounter == 200)
			{
				movementCounter = 0;
			}
			
		}
		
		
	}
	
	
}

using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour 
{
	
	// This Script is so that every so many frames, a moving spawner will generate
	// a new projectile and hurl it forward. These will be harmful to the player.
	
	public int reloadTime = 135;
	public int shotCounter;
	
	public int AllDone;
	
	
	public GameObject enemyToSpawn = null;
	
	
	void Start () 
	{
		// At launch, these to counting variables will be set to 0. From there they will begin to add each frame and thus "count."
		shotCounter = 0;
		AllDone = 10;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		// Adding to the count in between shots. Each time it reaches a predetermined number, it will
		// instantiate a comet and reset it's count.
		
		
		if (AllDone > 0)
		{
			shotCounter += 1;
			
			if (shotCounter == reloadTime)
			{
				Instantiate(enemyToSpawn, transform.position, transform.rotation);
				shotCounter = 0;
			}
			AllDone -= 1;
		}
		
		
	}
	
	
}
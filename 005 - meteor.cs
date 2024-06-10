using UnityEngine;
using System.Collections;

public class meteor : MonoBehaviour 
{
	
	public float meteorSpeed = 300.0f;
	public int movementCounter;
	
	
	void Start () 
	{
		// The plan is that at certain trigger points, or ever so often during gameplay, 
		// a meteor will be instantiated. When that happens this code will be executed.
		
		movementCounter = 0;
		
	}
	
	void Update () 
	{
		// I would like for these meteors to fly in quick fashion, similar to what actual meteors do.
		// Once instantiated, the object will head forward until it's movement counter gets to a 
		// predetermined number.
		
		movementCounter += 1;
		
		if (movementCounter < 200)
		{
			// 
			transform.Translate(Vector3.forward * meteorSpeed);
		}
		
		if (movementCounter == 201)
		{
			// After a predetermined amount of time, I would like the meteor to just be no more. 
			// No need for it at that point, for it has passed and is no longer a threat to the player.
			
			Destroy (gameObject);
		}
		
	}
}

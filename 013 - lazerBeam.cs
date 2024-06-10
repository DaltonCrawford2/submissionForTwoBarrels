using UnityEngine;
using System.Collections;

public class lazerBeam : MonoBehaviour {
	
	public float lazerSpeed = 50.0f;
	public bool lazerHitSomething;
	
	
	// Use this for initialization
	void Start () 
	{
		//
		lazerHitSomething = false;
	}
	
	// Update is called once per frame
	void Update() 
	{
		//
		transform.Translate(Vector3.forward * lazerSpeed);
				
	}
	
	
	public void HitTarget(bool hasHit)
	{
		//
		if (hasHit == true)
		{
			Destroy (gameObject);
		}
	}
	
}

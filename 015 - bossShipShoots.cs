using UnityEngine;
using System.Collections;

public class bossShipShoots : MonoBehaviour 
{
	
	private GameObject playerOne = null;
	
	
	
	// Use this for initialization
	void Start () 
	{
		//
		playerOne = GameObject.Find("player1");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//
		transform.LookAt(playerOne.transform);
	}
}

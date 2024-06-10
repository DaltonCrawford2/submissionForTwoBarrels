using UnityEngine;
using System.Collections;

public class guiTimer : MonoBehaviour 
{
	
	public string timePrefix = "Time Remaining: ";
	public float startTime = 100;
	public float timeLeft = 0;
	public bool timesUp = false;
	public bool isGameOver = false;
	
	
	// Use this for initialization
	void Start () 
	{
		//
		timesUp = false;
		timeLeft = startTime;
		
		Debug.Log("Get going! Move! DO SOMETHING!!");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//
		
		timeLeft -= Time.deltaTime;
		guiText.pixelOffset = new Vector2(0, -20);
		guiText.text = timePrefix + timeLeft.ToString ();
		if (timeLeft <= 0)
		{
			// When the timer reaches 0, I want the user to lose control of P1.
			timeLeft = 0;
			timesUp = true;
		}
		
		if (timesUp == true)
		{
			GameOver();
		}
	}
	
	public void GameOver()
	{
		//
		GameObject PlayerControlGameObject = GameObject.Find ("player1");
		PlayerControlGameObject.GetComponent<PlayerControl>().RanOutOfTime(timesUp);
	}
	
}

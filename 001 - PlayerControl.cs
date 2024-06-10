using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
	
	// Due to time/scope/scheduling conflicts, there were things I left out so that I can actually turn in something
	// worth a grade. I had some trouble with the raycasting, I use it for the Player shot, and it only goes forward.
	// I was unable to develop my "YOU WON!" protocols. 
	// As I have it, the game goes until either the clock or your HP hits 0.
	
	
	
	// Game Mechanics
	public float shipSpeed = 500.0f; // The Speed of which P1 will move at.
	private Vector3 shipVelocity = Vector3.zero; // Velocity of which the ship will move at.
	public float m_terminalVelocity = -0.5f;
	
	private CharacterController player1 = null;
	public static bool isClockTicking = true; // Determines if P1 will respond to User Input. Can change during gameplay.

	public static float m_jumpMechanics = 17.0f; // Strength of Jump. Pick-ups in game will allow this value to change.
	public static float m_gravityMechanics = 0.5f; // Strength of Gravity acting upon P1.
	
	// public static Vector3 m_spawnPoint =  Vector3.zero; // Spawn/Teleport destinations. Mechanic to be further developed.
	
	public GameObject theGui = null; //
	
	
	public Rigidbody lazer;
	public float lazerSpeed = 30.0f;
	
	// Are you Alive??
	public static int shipHealth = 100; // HP > 0 = Alive. If P1 "collides" with another object/enemy, then HP goes down. 


	// This code will run when the application is launched.
	void Start () 
	{
				
		// cache the character controller
		player1 = GetComponent<CharacterController>();
		
		// find the gui updater
		GameObject guiStuffGameObject = GameObject.Find ("GUI");
		guiStuffGameObject.GetComponent<guiStuff>().UpdateShipHealth(shipHealth);
		
		
		// isClockTicking = true;
		
	}
	
	
	void Update () 
	{
		// Code to run/be updated every frame while application is running.
		
		
		GameObject guiStuffGameObject = GameObject.Find ("GUI");
		guiStuffGameObject.GetComponent<guiStuff>().UpdateShipHealth(shipHealth);
		
		
		// kill the horizontal velocity
		shipVelocity.x = 0;
		shipVelocity.z = 0;
		shipVelocity.y = 0;
		
		if (shipHealth > 0)
			{
				MovementInput();
			}
		else if (shipHealth <= 0)
			{
				shipHealth = 0;
				Destroy (gameObject);
			}
						
	}
	
	void MovementInput()
	{
		// While inControl = True, Then these will be the inputs a User can utilize to manuever within the game.
		
		// Movement: Forward & Backward
		if (Input.GetKey("w"))
		{
			// When "w" key is pressed, Player will move FORWARD
			player1.Move(transform.forward * shipSpeed);	
		}
		else if (Input.GetKey("s"))
		{
			// When "s" key is pressed, Player will move BACKWARD
			player1.Move(-transform.forward * shipSpeed);
		}
				
		// Straffing: Right & Left
		if (Input.GetKey("z"))
		{
			// When "z" key is pressed, Player will STRAFFE LEFT
			player1.Move(-transform.right * shipSpeed);	
		}
		else if (Input.GetKey("c"))
		{
			// When "c" key is pressed, Player will STRAFFE RIGHT
			player1.Move(transform.right * shipSpeed);
		}

		// Rotate: Right & Left
		if (Input.GetKey("a"))
		{
			// When "a" key is pressed, Player will move LEFT
			transform.Rotate(0, -2.0f, 0);
		}	
		else if (Input.GetKey("d"))
		{
			// When "a" key is pressed, Player will move RIGHT
			transform.Rotate(0, 2.0f, 0);
		}
		
		
		// YAY! SHOOTING TIME!
		if (Input.GetKey(KeyCode.Mouse0))
		{
			// When "space" bar is pressed, Player will SHOOT
			raycastSHOOT();
		}
		
	}
	
	
	// If the ship touches anything during gameplay, this code will be called upon.
	void OnTriggerEnter(Collider other)
	{
		print ("Bapped your ride SON!");
		 
		if (other.name == "Enemy_Seeking")
		{
			//
			int shipHealth = Ouch(25);
			GameObject guiStuffGameObject = GameObject.Find ("GUI");
			guiStuffGameObject.GetComponent<guiStuff>().UpdateShipHealth(shipHealth);
			
			GameObject gui_InfoGameObject = GameObject.Find ("gui_Info");
			gui_InfoGameObject.GetComponent<guiInfo>().UpdateInfoShown(0);
		}
		
		if (other.name == "Enemy_FixedMovement")
		{
			//
			int shipHealth = Ouch(15);
			GameObject guiStuffGameObject = GameObject.Find ("GUI");
			guiStuffGameObject.GetComponent<guiStuff>().UpdateShipHealth(shipHealth);
			
			GameObject gui_InfoGameObject = GameObject.Find ("gui_Info");
			gui_InfoGameObject.GetComponent<guiInfo>().UpdateInfoShown(0);
		}
		
		if (other.name == "Enemy_Floating")
		{
			//
			int shipHealth = Ouch(15);
			GameObject guiStuffGameObject = GameObject.Find ("GUI");
			guiStuffGameObject.GetComponent<guiStuff>().UpdateShipHealth(shipHealth);
			
			GameObject gui_InfoGameObject = GameObject.Find ("gui_Info");
			gui_InfoGameObject.GetComponent<guiInfo>().UpdateInfoShown(0);
		}
		
		if (other.name == "Enemy_Circling")
		{
			//
			int shipHealth = Ouch(15);
			
			GameObject guiStuffGameObject = GameObject.Find ("GUI");
			guiStuffGameObject.GetComponent<guiStuff>().UpdateShipHealth(shipHealth);
			
			GameObject gui_InfoGameObject = GameObject.Find ("gui_Info");
			gui_InfoGameObject.GetComponent<guiInfo>().UpdateInfoShown(0);
		}
		
		if (other.name == "Falling_Stars(Clone)")
		{
			//
			int shipHealth = Ouch(30);
			GameObject guiStuffGameObject = GameObject.Find ("GUI");
			guiStuffGameObject.GetComponent<guiStuff>().UpdateShipHealth(shipHealth);
			
			GameObject gui_InfoGameObject = GameObject.Find ("gui_Info");
			gui_InfoGameObject.GetComponent<guiInfo>().UpdateInfoShown(1);
		}
		
		if (other.name == "Enemy_Boss")
		{
			//
			int shipHealth = Ouch(50);
			GameObject guiStuffGameObject = GameObject.Find ("GUI");
			guiStuffGameObject.GetComponent<guiStuff>().UpdateShipHealth(shipHealth);
			
			GameObject gui_InfoGameObject = GameObject.Find ("gui_Info");
			gui_InfoGameObject.GetComponent<guiInfo>().UpdateInfoShown(2);
		}
		
		if (other.name == "BossBomb(Clone)")
		{
			//
			print ("I Can't believe you SHOT Him!");
			int shipHealth = Ouch(25);
			GameObject guiStuffGameObject = GameObject.Find ("GUI");
			guiStuffGameObject.GetComponent<guiStuff>().UpdateShipHealth(shipHealth);
			
			GameObject gui_InfoGameObject = GameObject.Find ("gui_Info");
			gui_InfoGameObject.GetComponent<guiInfo>().UpdateInfoShown(2);
		}
	}
	
	// This code will execute after a collision in order to deal damage to P1.
	public int Ouch(int m_Ouchies)
	{
		//
		shipHealth -= m_Ouchies;
		if (shipHealth <= 0)
		{
			shipHealth = 0;
		}
		print ("Your Health is now: " + shipHealth.ToString());
		return shipHealth;
	}
	
	
	public void RanOutOfTime(bool cannotControl)
	{
		// If/When the timer reaches 0, I would like the User to lose control of P1.
		if (cannotControl == true)
		{
			Destroy (gameObject);
		}
		
	}
	
	
	
	
	void raycastSHOOT()
	{
		//
		
		RaycastHit victimName;
		if (Physics.Raycast (transform.position, transform.forward, out victimName, 2500))
		{
			//
			print ("Bagged me a  " + victimName.transform.gameObject.name);
			
			Instantiate(lazer, transform.position, transform.rotation);
			
		}
		
	}
	
	
	
}

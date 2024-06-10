using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	// Dalton Bruce Crawford II
	// Interactive Resume - Proof of Skill Concept
	// Project Start Date: Monday December 14, 2015 [After modeling for a week]

	// This is going to be an interactive resume I plan to use instead of a portfolio, of which I do not have.
	// The plan is continue to develop and add to this idea. It will essentially be my portfolio as my skills grow.
	// Over time ...
	// Refine my models
	// Improve textures
	// Add programmed events via scripting
	// Implement animations

	// Also, as we continue on with this, it would be wise to branch out and experiment with my code 
	// as opposed to copying old code from homework assignments.

	// Upon inception, this will be delivered/submitted as a Web Build.

	// Originally, I planned for this concept to consist of multiple mini-games.
	// Going forward, that idea was cut due to time restrictions.
	// However, while writing code for this project for the first time,
	// I am romancing the thought of adding NPCs that will populate the "arcade" via spanwing PreFabs
	// If these collide with P1, back to the starting point.
	// Obviously, this means I would have to include a method of self-defense, oh well.
	// If I can, I will implement.

	// Update 03/27/2018: 


	// Mechanics
	// Regulate the stats of which P1 operates.
	public float playerSpeed = 195.0f;

	private CharacterController player1 = null;

	// Determines if user can actually control P1
	public bool inControl = true;

	// Sanka, ya dead?!
	// Set P1's HP
	// While HP > 0, P1 is alive.
	// Subtract from HP if P1 collides with enemies. [Time pending/permitting]
	public static int playerHealth = 100;

	public int countdownToRock;
	public bool haveWeRockedOutYet = false;
	public AudioClip welcomeNote;

	private AudioSource source;









	void Start () 
	{
		// Runs at launch of application.

		// Cache the character controller
		player1 = GetComponent<CharacterController>();

		source = GetComponent<AudioSource>();
		countdownToRock = 0;


	}

	// Update is called once per frame
	void Update () 
	{

		// The speed stat of P1 has behaved ... interestingly. 
		// So, in hopes to keep this thing in check, I will tell the code to assign a value to the variable every time this
		// code refreshes, which is every frame.

		if (playerSpeed != 195.0f)
		{
			playerSpeed = 195.0f;
		}

		// Temporary fix.
		// On 3/27/2018, I resumed work on this project, this new iteration finally saw me
		// bring in a modeled mesh to constitute an actual arcade and not a rinky-dink box that the previous
		// build consisted of.
		// The camera will still act as a first person view, however, with this new building, the camera will be 
		// changing levels. Inital thought was to initiate "Gravity" on this object's rigidbody. However, that causes
		// the Camera, its box collider and the rigidbody to fall through the collider of the arcade.
		// An idea, is to shoot out a downward ray from the camera, that would then catch the distance from the camera 
		// to the floor, store that distance in a variable that can then be used in the update to set the camera's 
		// y position to be distanceToFloor + however high I want the camera to be.

		RaycastHit hit;
		float distanceToFloor;
		float extraHeight;
		float cameraDecent;
		Vector3 pos = transform.position;

		Vector3 down = transform.TransformDirection(-Vector3.up);
		Debug.DrawRay(transform.position, down, Color.green);
		// Ray 

		if(Physics.Raycast(transform.position,(down), out hit))
		{
			distanceToFloor = Mathf.Round(hit.distance);
			print (distanceToFloor + " " + hit.collider.gameObject.name);

			if(distanceToFloor > 5900)
			{
				extraHeight = distanceToFloor - 5900.0f;
				// player1.position.y -= extraHeight;
				pos.y = 5900.0f - extraHeight;
				transform.position = pos;
			}

			if(distanceToFloor < 5900)
			{
				cameraDecent = 5900.0f - distanceToFloor;
				// player1.position.y += downInTheDumps;
				pos.y = 5900.0f + cameraDecent;
				transform.position = pos;
			}

		}

		// player1.position.y = distanceToFloor


		// MovementInput needs to be called when using this method.
		// While the health of P1 is in proper condition, then move about at one's leisure.
		if (playerHealth > 0)
		{
			MovementInput();
		}

		// I want to track the frames, it will make it easier when I decide to add music. 
		// This way, I do not have to do the math since I am short on time.
		if (countdownToRock < 50)
		{
			countdownToRock = countdownToRock + 1;
		}
		else if (countdownToRock == 50)
		{
			// source.PlayOneShot(welcomeNote, 1F);
			// if (haveWeRockedOutYet = false)
			// {
			// 	PlaySound();
			// 	haveWeRockedOutYet = true;
			// }
		}
	}

	void MovementInput()
	{
		// While the user is in control of the PC [inControl = true]
		// Then the following code will allow them to move quasi-freely.

		// Moving Foward and Backward
		if (Input.GetKey ("up"))
		{
			player1.Move (transform.forward * playerSpeed);
			// player1.transform.Translate(Vector3.forward * playerSpeed);
		}
		else if (Input.GetKey ("down"))
		{
			player1.Move (-transform.forward * playerSpeed);
		}

		// Rotating
		if (Input.GetKey("right"))
		{
			transform.Rotate(0, 1.5f, 0);
		}
		else if (Input.GetKey("left"))
		{
			transform.Rotate (0, -1.5f, 0);
		}

		// Attempting to make this slightly user friendly in it's already simplistic yet infant state.
		// Adding a few lines to allow another way to kill the application.
		if (Input.GetKey ("escape"))
		{
			Application.Quit();
		}

		// Hope all goes well, because it will then be
		// SHOOTIING TIME!!!
	}

	// void PlaySound()
	// {
	// 	source.PlayOneShot(welcomeNote, 1F);
	// }
	//
	//
	//
	// void OnTriggerEnter(Collider other)
	// {
	//		Just in case I do add this neat aspect.
	//
	//		I would enter code here that would "activate" 
	//		whenever P1 'COLLIDES' specific colliders attached to other in-game assets
	//
	// }
}

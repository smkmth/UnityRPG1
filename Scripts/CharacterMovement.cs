using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Yarn.Unity;
using Yarn.Unity.Example;


public class CharacterMovement : MonoBehaviour
	
{	

	//here we set all the variables and objects within the scope of this script


	private GameObject playerSprite;

	private Rigidbody2D playerRigidBody2D;

	//a vector which tells player how to move
	private float movePlayerVector;
	
	public static bool facingLeft;

	public float jumpForce = 700f;

	public Vector2 jump;

	//check to see if we be on the ground
	private bool grounded;
	//object to be asigned to ground check
	public Transform groundCheck;
	//the sphere generated to check the ground
	public float groundRadius = 1f;
	//a layer mask which excludes everything which isnt ground
	public LayerMask whatIsGround;
	//players speed 
	public float speed = 4.0f;
	// the animator 
	private Animator anim;
	public float interactionRadius = 2.0f;
	// Draw the range at which we'll start talking to people.
	void OnDrawGizmosSelected() {
		Gizmos.color = Color.blue;

		// Flatten the sphere into a disk, which looks nicer in 2D games
		Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1,1,0));

		// Need to draw at position zero because we set position in the line above
		Gizmos.DrawWireSphere(Vector3.zero, interactionRadius);
	}



	void Awake()
	{
		//here we set all the variables which need to get set when the player first appears
		//we asign playerRidgidBody2D to the ridgidbody2d on the player object
		playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
		//remember that the object called playersprite is the one moved
		playerSprite = transform.Find ("PlayerSprite").gameObject;
		//get the animator component attached to player sprite
		anim = (Animator)playerSprite.GetComponent (typeof(Animator));


	}
		
	
	void FixedUpdate() {
		
		//upated every fixed framerate frame, best used for physics objects 
		//check we are on the ground using overlapping circles and send that info to animator 
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		//find out falling speed and send it to animator 
		anim.SetFloat ("VSpeed", playerRigidBody2D.velocity.y);
		movePlayerVector = Input.GetAxis ("Horizontal");
		//get the horizontal input and aply it to ridgid body 
		anim.SetFloat ("speed", Mathf.Abs (movePlayerVector));
		playerRigidBody2D.velocity = new Vector2 (movePlayerVector *
				speed, playerRigidBody2D.velocity.y);
		//flip player sprite
		if (movePlayerVector < 0 && !facingLeft)
		{
			Flip();
		}
		else if (movePlayerVector > 0 && facingLeft)
		{
			Flip();
		}
	}

	void Update() {
		//updated every frame best used for everything else 
		if (FindObjectOfType<DialogueRunner>().isDialogueRunning == true) {
			return;
		}


		if (Input.GetKeyDown(KeyCode.X)) {
			CheckForNearbyNPC ();
		}

		if (grounded && Input.GetKeyDown (KeyCode.Space)) {

			//on key press i want it to play the jumping animation
			//and delay the actual jump untill the animation has played
			//at that point i want itto transition cleanly into the air
			//rising position as the charicter leaves the ground and then 
			//transition to a landing animation as he lands before going
			//back to idle.


//			anim.SetBool("Ground", false); dont need this 
			//this is a coroutine for jumping so i can time the point of the jump. 
				
			StopCoroutine("Jump");    // Interrupt in case it's running
			StartCoroutine("Jump");



		}

	
	}

	IEnumerator Jump() 
	{
		anim.SetBool ("Jumping", true);

		yield return StartCoroutine ("ExecuteAfterTime", 0.5f);

		playerRigidBody2D.AddForce(new Vector2(0, jumpForce));

		anim.SetBool("Jumping", false);


	}

	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds (time);
	}

	public void CheckForNearbyNPC ()
	{
		// Find all DialogueParticipants, and filter them to
		// those that have a Yarn start node and are in range; 
		// then start a conversation with the first one
		var allParticipants = new List<NPC> (FindObjectsOfType<NPC> ());
		var target = allParticipants.Find (delegate (NPC p) {
			return string.IsNullOrEmpty (p.talkToNode) == false && // has a conversation node?
				(p.transform.position - this.transform.position)// is in range?
					.magnitude <= interactionRadius;
		});
		if (target != null) {
			// Kick off the dialogue at this node.
			FindObjectOfType<DialogueRunner> ().StartDialogue (target.talkToNode);
		}
	}
	
	void Flip()
	{
		facingLeft = !facingLeft;

		
		Vector3 theScale = playerSprite.transform.localScale;
		theScale.x *= -1;
		playerSprite.transform.localScale = theScale;


	}
}






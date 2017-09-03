using UnityEngine;
using System.Collections;

// FlyBehaviour inherits from GenericBehaviour. This class corresponds to the flying behaviour.
public class FlyBehaviour : GenericBehaviour {

	public float flySpeed = 4.0f;                 // Default flying speed.
	private float sprintFactor = 2.0f;            // How much sprinting affects fly speed.
	public float flyMaxVerticalAngle = 60f;       // Angle to clamp camera vertical movement when flying.

	private int flyBool;                          // Animator variable related to flying.
	private int groundedBool;                     // Animator variable related to whether or not the player is on ground.

	PowerManager pm = new PowerManager ();

	// Start is always called after any Awake functions.
	void Start()
	{
		// Set up the references.
		flyBool = Animator.StringToHash ("Fly");
		groundedBool = Animator.StringToHash("Grounded");
		// Subscribe this behaviour on the manager.
		behaviourManager.SubscribeBehaviour (this);
	}

	// Update is used to set features regardless the active behaviour.
	void Update ()
	{
		// Toggle fly by input.
		PowerManager pm = new PowerManager ();
		GameManager gm = new GameManager ();
		if (pm.isPowerInUse /*&& pm.currentPower.Equals (Powers.Flight)*/)
		{
			// Obey gravity. It's the law!
			rbody.useGravity = !pm.isPowerInUse;

			// Player is flying.
			if (pm.isPowerInUse)
			{
				// Register this behaviour.
				behaviourManager.RegisterBehaviour (this.behaviourCode);
			} else
			{
				// Set camera default offset.
				camScript.ResetTargetOffsets ();

				// Unregister this behaviour and set current behaviour to the default one.
				behaviourManager.UnregisterBehaviour (this.behaviourCode);
			}
		}
		
		// Assert this is the active behaviour
		pm.isPowerInUse = pm.isPowerInUse && behaviourManager.IsCurrentBehaviour (this.behaviourCode);

		// Set fly related variables on the Animator Controller.
		anim.SetBool (groundedBool, IsGrounded ());
		anim.SetBool (flyBool, pm.isPowerInUse);
	}

	// LocalFixedUpdate overrides the virtual function of the base class.
	public override void LocalFixedUpdate ()
	{
		// Set camera limit angle and offset related to fly mode.
		camScript.SetMaxVerticalAngle (flyMaxVerticalAngle);
		camScript.SetYCamOffset (0f);

		// Call the fly manager.
		FlyManagement(behaviourManager.GetH, behaviourManager.GetV);
	}
	// Deal with the player movement when flying.
	void FlyManagement(float horizontal, float vertical)
	{
		// Add a force player's rigidbody according to the fly direction.
		Vector3 direction = Rotating(horizontal, vertical);
		if(pm.isPowerInUse)
			rbody.AddForce((direction * flySpeed * 100 * (behaviourManager.isSprinting()?sprintFactor:1)), ForceMode.Acceleration);
	}

	// Rotate the player to match correct orientation, according to camera and key pressed.
	Vector3 Rotating(float horizontal, float vertical)
	{
		Vector3 forward = behaviourManager.playerCamera.TransformDirection(Vector3.forward);
		// Camera forward Y component is relevant when flying.
		forward = forward.normalized;

		Vector3 right = new Vector3(forward.z, 0, -forward.x);

		// Calculate target direction based on camera forward and direction key.
		Vector3 targetDirection = forward * vertical + right * horizontal;

		// Rotate the player to the correct fly position.
		if((behaviourManager.IsMoving() && targetDirection != Vector3.zero))
		{
			Quaternion targetRotation = Quaternion.LookRotation (targetDirection);//, Vector3.up);

			// Lay down player.
			if(pm.isPowerInUse)
				targetRotation *= Quaternion.Euler (90, 0, 0);

			Quaternion newRotation = Quaternion.Slerp(rbody.rotation, targetRotation, behaviourManager.turnSmoothing * Time.deltaTime);

			rbody.MoveRotation (newRotation);
			behaviourManager.SetLastDirection(targetDirection);
		}
		// Rotate the player to stand position when flying & idle.
		if(!(Mathf.Abs(horizontal) > 0.9 || Mathf.Abs(vertical) > 0.9))
		{
			behaviourManager.Repositioning();
		}

		// Return the current fly direction.
		return targetDirection;
	}
}

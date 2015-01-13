using UnityEngine;
using System.Collections;

public class playerMovementRotation : MonoBehaviour {
	private Animator anim;
	public Vector3 startPosition;
	public float speed, turningSpeed;
	public static Vector3 movement;
	public GameObject bullet;
	public Quaternion qTo;


	void Start () 
	{
		startPosition = transform.position;
		anim = gameObject.GetComponent<Animator> ();
	}

	void FixedUpdate() 
	{
			
		float lastInputX = Input.GetAxis ("Horizontal");
		float lastInputY = Input.GetAxis ("Vertical");

		//anim.SetFloat ("Speedx", lastInputX);
		//anim.SetFloat ("Speedy", lastInputY);
		
		movement = new Vector3 	(speed * lastInputX, speed * lastInputY, 0);
		Vector3 targetDir  = transform.position + movement; 
		//Vector3 targetDir = (transform.position+movement) - transform.position;
		float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		//transform.rotation = Quaternion.LookRotation(newDir);
			
		//transform.RotateAround(Vector3.zero, Vector3.forward, Vector3. * Time.deltaTime);
		//Quaternion dir = Quaternion.RotateTowards(transform.rotation, qTo, turningSpeed * Time.deltaTime);
		//RotateTowards(targetdir);
		movement *= Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position,targetDir,0.25f);
		transform.Rotate(0,0,-Input.GetAxis("Horizontal")*turningSpeed*Time.deltaTime);

		//Vector3 newDir = Vector3.RotateTowards(transform.forward, targetdir, 3, 0.0F);

		
		if(Input.GetKeyDown("space"))
		{
			GameObject bulletFired = Instantiate(bullet,transform.position,Quaternion.identity)as GameObject;
			bulletFired.GetComponent<FireBullet>().direction = targetDir;
		}

		if (lastInputX != 0 || lastInputY != 0) 
		{
			anim.SetBool ("Walking", true);
			float LastMoveX = 0;
			float LastMoveY = 0;


			if (lastInputX > 0) 
			{
				LastMoveX = 1f;
				anim.SetFloat ("LastMoveX", LastMoveX);
			} else if (lastInputX < 0) 
			{
				LastMoveX = -1f;
				anim.SetFloat ("LastMoveX", LastMoveX);
			} else 
			{
				LastMoveX = 0f;
				anim.SetFloat ("LastMoveX", LastMoveX); 
			}

			if (lastInputY > 0) 
			{
				LastMoveY = 1f;
				anim.SetFloat ("LastMoveY", LastMoveY);
			} else if (lastInputY < 0) 
			{
				LastMoveY = -1f;
				anim.SetFloat ("LastMoveY", -LastMoveY);
			} else 
			{
				LastMoveY = 0f;
				anim.SetFloat ("LastMoveY", LastMoveY);
			}

			Vector3 face = transform.TransformDirection( new Vector3(LastMoveX,LastMoveY,0));
		} else 
		{
			anim.SetBool ("Walking", false);
				
		}
	}

	protected virtual void RotateTowards (Vector3 dir) {
		
		if (dir == Vector3.zero) return;
		
		Quaternion rot = transform.rotation;
		Quaternion toTarget = Quaternion.LookRotation (dir);
		
		rot = Quaternion.Slerp (rot,toTarget,turningSpeed*Time.deltaTime);
		Vector3 euler = rot.eulerAngles;
		euler.y = 0;
		euler.x = 0;
		rot = Quaternion.Euler (euler);
		//transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		
		transform.rotation = rot;
	}
}

			
	

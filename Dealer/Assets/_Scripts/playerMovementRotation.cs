using UnityEngine;
using System.Collections;

public class playerMovementRotation : MonoBehaviour {
	private Animator anim;
	public Vector3 startPosition;
	public float speed, turningSpeed;
	public static Vector3 movement;
	public GameObject bullet;


	void Start () {
				startPosition = transform.position;
				anim = gameObject.GetComponent<Animator> ();
		}

	void FixedUpdate() 
	{
				
		float lastInputX = Input.GetAxis ("Horizontal");
		float lastInputY = Input.GetAxis ("Vertical");

		anim.SetFloat ("Speedx", lastInputX);
		anim.SetFloat ("Speedy", lastInputY);
		
		movement = new Vector3 	(speed * lastInputX, speed * lastInputY, 0);
		Vector3 targetdir  = Vector3.Normalize(transform.position + movement); 
		targetdir.z = 0;
		RotateTowards(movement);
		movement *= Time.deltaTime;
		//transform.Rotate(0,0,-Input.GetAxis("Horizontal")*turningSpeed*Time.deltaTime);

		//targetdir.z = -1;
		//Vector3 newDir = Vector3.RotateTowards(transform.forward, targetdir, 3, 0.0F);
		//transform.rotation = Quaternion.LookRotation(newDir);

		transform.Translate (movement);
		
		if(Input.GetKeyDown("space"))
		{
			GameObject bulletFired = Instantiate(bullet,transform.position,Quaternion.identity)as GameObject;
			bulletFired.GetComponent<FireBullet>().direction = targetdir;
		}

		if (lastInputX != 0 || lastInputY != 0) 
		{
			anim.SetBool ("walking", true);
			/*if (lastInputX > 0) 
			{
				anim.SetFloat ("LastMoveX", 1f);
			} else if (lastInputX < 0) 
			{
				anim.SetFloat ("LastMoveX", -1f);
			} else 
			{
				anim.SetFloat ("LastMoveX", 0f); 
			}

			if (lastInputY > 0) 
			{
				anim.SetFloat ("LastMoveY", 1f);
			} else if (lastInputY < 0) 
			{
				anim.SetFloat ("LastMoveY", -1f);
			} else 
			{
				anim.SetFloat ("LastMoveY", 0f);
			}
*/
		} else 
		{
			anim.SetBool ("walking", false);
				
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

			
	

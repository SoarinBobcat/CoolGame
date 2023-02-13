using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerMain : MonoBehaviour
{
	private CharacterController controller;
	public ParticleSystem dust;
	
	private int spd = 8;
	private int jumpSpd = 50;
	private float grav = 10f;
	
	public float xMove = 0f;
	public float zMove = 0f;
	public Vector3 dir = Vector3.zero;
	public Vector3 yVel = Vector3.zero;
	public bool inair = true;
	
	public GameObject projectile;
	
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}
	
	void Update()
	{
		//Lateral Movement
		xMove = Input.GetAxis("xMove");
		zMove = Input.GetAxis("zMove");
		if ((xMove!=0) || (zMove!=0)){
			dir = new Vector3(xMove,0,zMove);
		}
		
		//Jumping and Gravity
		if (controller.isGrounded)
		{
			/*if (inair)
			{
				dust.Play();
				inair = false;
			}*/
			yVel.y = -grav * Time.deltaTime;
			
			if (Input.GetButtonDown("Jump"))
			{
				yVel.y = jumpSpd * Time.deltaTime;
			}
		}
		else
		{
			yVel.y -= grav * Time.deltaTime;
			//inair = true;
		}
		controller.Move(yVel*Time.deltaTime);
		
		controller.Move(dir*spd*Time.deltaTime);
		
		//Fire projectile
		if (Input.GetButtonDown("Fire1"))
		{
			fire();
		}
		
		transform.rotation = Quaternion.LookRotation (-dir);
		//transform.Translate(Vector3.back*Time.deltaTime*spd);
	}
	
	//Creates Projectile
	void fire()
	{
		Instantiate(projectile,transform.position,transform.rotation);
	}
}

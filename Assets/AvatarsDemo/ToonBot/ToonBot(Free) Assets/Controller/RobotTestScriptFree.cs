using UnityEngine;
using System.Collections;

public class RobotTestScriptFree : MonoBehaviour {

	private Animator anim;
	private float jumpTimer = 0;

	void Start () {
	
		anim = this.gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		//Controls the Input for running animations
		// 1: walk
		//2: Run
		//3: Jump
			
		if(Input.GetKey("2")) anim.SetInteger("Speed", 2);
			else if(Input.GetKey("1")) anim.SetInteger("Speed", 1);
				else anim.SetInteger("Speed", 0);

		if (Input.GetKey ("3")) {

			jumpTimer = 1;
			anim.SetBool ("Jumping", true);

			}

		if (jumpTimer > 0.5) jumpTimer -= Time.deltaTime;
			else if (anim.GetBool ("Jumping") == true) anim.SetBool ("Jumping", false);

	}
}

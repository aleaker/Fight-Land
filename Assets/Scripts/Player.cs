using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{		
	protected Player(){
		moveSpeed = 4f;
		walkSpeed = 4f;
		maxSpeed = 10f;
		stamina = 10;
		aceleration = 0.1f;
		deceleration = 0.2f;
	}

    protected override void Update()
    {
		getInput();
		setAnimator();
		base.Update();
    }
	
	protected override void FixedUpdate(){
			//movePosition = direction.normalized;
			base.FixedUpdate();
    }

	public void getInput(){
		direction.x = Input.GetAxisRaw("Horizontal");
		direction.y = Input.GetAxisRaw("Vertical");
		isSprinting = Input.GetKey(KeyCode.LeftShift);
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
	public Rigidbody2D rb; 
	public Animator animator;
//---------movement-----------
//	protected Vector2 movePosition;
	protected Vector2 direction;
	protected float moveSpeed;
	protected float walkSpeed;
	protected float maxSpeed;
	protected float stamina;
	protected float aceleration;
	protected float deceleration;
	protected bool isSprinting = false;
//-----------atributes------------
	protected float health;
//-----------skills---------------
	//leadership
	//techinic
	//speed
	//strength
	//endurance
	//ki/concentration
//----------inventory----------
	//should this be a class and have a subclass Cloth?

    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update(){
    }

	protected virtual void FixedUpdate(){
		move();
		checkStop(direction.x, direction.y);
		checkSprint();
	}
	
	protected void move(){//movePosition){
		rb.MovePosition(rb.position + direction.normalized * moveSpeed  * Time.fixedDeltaTime);
	}

	public void checkStop(float x, float y){
		if(x == 0.0 && y == 0.0){
			stop();
		}
	}

	public void checkSprint(){
		if(isSprinting && stamina > 0){ 
			sprint();
		}else{
			if (walkSpeed <= moveSpeed-deceleration){
				moveSpeed = moveSpeed-deceleration; // 7 <= 8-2 ????
			}else{
				stop();
			}	
		}
	}

	public void stop(){ //lowers speed to make the animator show the walking animation
		moveSpeed = walkSpeed;
	}
	
	public void sprint(){
		if (moveSpeed+aceleration <= maxSpeed){
			moveSpeed = moveSpeed+aceleration;
		}else{
			moveSpeed = maxSpeed;
		};	
	}

	public void setAnimator(){
	if(direction.sqrMagnitude != 0 ){ 
		animator.SetFloat("Horizontal", direction.x);
		animator.SetFloat("Vertical", direction.y);
	};
	animator.SetFloat("Speed", direction.sqrMagnitude);
	}
}



	// protected float getSpeed(){
	// 	return this.moveSpeed;
	// }


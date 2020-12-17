using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
	private Rigidbody2D targetRb;
	protected Vector2 moveSpot;
	private float minX = -5;
	private float maxX = 5;
	private float minY = -5;
	private float maxY = 5;
	private float patrolWaitTime = 2;
	private float waitingTime;
	private bool isWaiting = false;
	

	void Start()
	{
		moveSpot = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY)); //next spot to move when patroling
		targetRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>(); //player's rigidbody		
		waitingTime = patrolWaitTime;
	}

    protected override void Update()
    {
		setAnimator();	
	}

	protected override void FixedUpdate()
	{
		patrol();
		//chasePlayer();
		//base.FixedUpdate();	
	}

	protected void chasePlayer()
	{
		direction.x = (targetRb.position.x-rb.position.x);
		direction.y = (targetRb.position.y-rb.position.y);
		move();
		// if(Vector2.Distance(rb.position,targetRb.position) == 0){
		// 	print("figth starts here");	
		// }
	}

	private void patrol()
	{	
		if(!isWaiting){
			direction.x = (moveSpot.x-rb.position.x);
			direction.y = (moveSpot.y-rb.position.y);
			move();
		}

		if(Vector2.Distance(rb.position,moveSpot) <= 0.1){ 								 //if distance to the target spot is <= 0.1
			if(waitingTime <= 0){						   								 //and waiting time is over...
				moveSpot = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY)); //set a new spot to move to
				waitingTime = patrolWaitTime; 			                                 //reset waiting time
				isWaiting = false;
			}else{
				isWaiting = true;
				waitingTime -= Time.deltaTime;
			}
		}
	}

	
}

		//rb.position = Vector2.MoveTowards(rb.position, moveSpot, moveSpeed * Time.deltaTime);
		//rb.MovePosition(rb.position + direction.normalized * moveSpeed  * Time.fixedDeltaTime);
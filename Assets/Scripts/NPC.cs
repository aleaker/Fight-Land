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
	// Start is called before the first frame update

	void Start()
	{
		moveSpot = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
		targetRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
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

		//print(direction);
		rb.MovePosition(rb.position + direction.normalized * moveSpeed  * Time.fixedDeltaTime);

		// if(Vector2.Distance(rb.position,targetRb.position) == 0){
		// 	print("figth starts here");	
		// }
//		rb.position = Vector2.MoveTowards(rb.position, targetRb.position, moveSpeed * Time.deltaTime);
	}

	private void patrol()
	{	
		direction.x = (moveSpot.x-rb.position.x);
		direction.y = (moveSpot.y-rb.position.y);
	

		//rb.position = Vector2.MoveTowards(rb.position, moveSpot, moveSpeed * Time.deltaTime);
		rb.MovePosition(rb.position + direction.normalized * moveSpeed  * Time.fixedDeltaTime);
		
		//print(Vector2.Distance(rb.position,moveSpot));
		if(Vector2.Distance(rb.position,moveSpot) <= 0.1){
			if(waitingTime <= 0){

			moveSpot = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
				waitingTime = patrolWaitTime;
			}else{
				waitingTime -= Time.deltaTime;
				//el bug es pq sigue restando movespot -rb.position y seteando direction, despues mueve el rb con esa direction pero el monigote está quieto
			}
		}
	}

	
}

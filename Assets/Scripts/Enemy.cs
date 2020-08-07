using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{	
	
    protected Enemy(){
		moveSpeed = 4f;
		walkSpeed = 4f;
		maxSpeed = 10f;
		stamina = 10;
		aceleration = 0.1f;
		deceleration = 0.2f;
	}
	
	

}

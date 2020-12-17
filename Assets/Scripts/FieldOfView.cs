using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{   

	public float viewRadius;
	[Range(0,360)]
	public float viewAngle;

	public LayerMask targetMask;
	public LayerMask obstacleMask;

    [HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();

    // Start is called before the first frame update
	void Start() {
		StartCoroutine ("FindTargetsWithDelay", .2f);
	}


	IEnumerator FindTargetsWithDelay(float delay) {
		while (true) {
			yield return new WaitForSeconds (delay);
			FindVisibleTargets ();
		}
	}

    void FindVisibleTargets() {
		visibleTargets.Clear ();
	//	Debug.Log(viewRadius);
		Collider2D[] targetsInViewRadius =  Physics2D.OverlapCircleAll (transform.position, viewRadius);
		Debug.Log(targetsInViewRadius[0].tag);
		for (int i = 0; i < targetsInViewRadius.Length; i++) {
			Transform target = targetsInViewRadius [i].transform;
			Vector2 dirToTarget = (target.position - transform.position).normalized;
                   //      Debug.Log(target);

          //   Debug.Log(dirToTarget);
			// if (Vector2.Angle (transform.right, dirToTarget) < viewAngle / 2) {
            if (Vector2.Angle(transform.up, dirToTarget) < viewAngle/2){
				float dstToTarget = Vector2.Distance (transform.position, target.position);
 // Debug.Log(dstToTarget);
				if (!Physics2D.Raycast (transform.position, dirToTarget, dstToTarget, obstacleMask)) {
					visibleTargets.Add (target);
             //       Debug.Log(target);
				}
			}
		}
	}

 	public Vector2 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
		if (!angleIsGlobal) {
			angleInDegrees += transform.eulerAngles.z;
		}
		return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}
}

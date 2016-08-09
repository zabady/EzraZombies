using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	public float maxDist = 1000000f;
	public GameObject decalHitWall;
	public float floatInFrontOfWall = 0.00001f;

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if(Physics.Raycast(transform.position,transform.forward,out hit,maxDist))
		{
			if(decalHitWall && hit.transform.tag=="Level Parts")
				Instantiate (decalHitWall, hit.point + (hit.normal * floatInFrontOfWall), Quaternion.LookRotation (hit.normal));
			

		}
		Destroy (gameObject);
	}
}

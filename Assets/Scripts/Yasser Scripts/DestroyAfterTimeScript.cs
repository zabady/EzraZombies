using UnityEngine;
using System.Collections;

public class DestroyAfterTimeScript : MonoBehaviour {


	public float destroyAfterTime = 30;
	public float destroyAfterTimeRandomization =0;
	public float countToTime;


	void Awake(){
		destroyAfterTime += Random.value * destroyAfterTimeRandomization;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		countToTime += Time.deltaTime;
		if (countToTime >= destroyAfterTime)
			Destroy (gameObject);
	}
}

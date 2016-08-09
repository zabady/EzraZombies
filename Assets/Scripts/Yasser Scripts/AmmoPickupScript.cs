using UnityEngine;
using System.Collections;

public class AmmoPickupScript : MonoBehaviour {

	public bool fromGun = false;
	public GameObject gun;
	public int ammoType=0;
	public int ammoAmount=25;
	public bool unlimitedAmmo = false;
	public AudioClip pickupSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

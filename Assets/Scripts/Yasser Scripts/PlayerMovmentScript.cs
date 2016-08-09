using UnityEngine;
using System.Collections;

public class PlayerMovmentScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerStay(Collider hitTrigger){

		AmmoPickupScript ammo = null;
		GunScript gun = null;
		GunScript current = null;
		current = GameObject.FindWithTag ("CurrentGun").GetComponent<GunScript> ();
		if (hitTrigger.tag == "AmmoPickup") {

			ammo = hitTrigger.gameObject.GetComponent<AmmoPickupScript> ();
			if (current.currentExtraAmmo < current.maxExtraAmmo) {

				if(ammo.fromGun)
				{
					gun = ammo.gun.GetComponent<GunScript>();
					if(gun.currentExtraAmmo>0 && gun.ammoType == current.ammoType){
						if(gun.currentExtraAmmo >= current.maxExtraAmmo - current.currentExtraAmmo){
							gun.currentExtraAmmo -= current.maxExtraAmmo - current.currentExtraAmmo;
							current.currentExtraAmmo = current.maxExtraAmmo;
						}
						if(gun.currentExtraAmmo < current.maxExtraAmmo - current.currentExtraAmmo)
						{
							current.currentExtraAmmo += gun.currentExtraAmmo;
							gun.currentExtraAmmo = 0;
						}
						if (ammo.pickupSound)
							ammo.gameObject.GetComponent<AudioSource> ().Play ();
					}
				}

				if(!ammo.fromGun){
					if (current.ammoType == ammo.ammoType || ammo.ammoType == -1) 
					{
					
						if(ammo.ammoAmount>0 && !ammo.unlimitedAmmo)
						{

							if(ammo.ammoAmount >= current.maxExtraAmmo - current.currentExtraAmmo)
							{
								ammo.ammoAmount -= current.maxExtraAmmo - current.currentExtraAmmo;
								current.currentExtraAmmo = current.maxExtraAmmo;

							}
							if(ammo.ammoAmount < current.maxExtraAmmo - current.currentExtraAmmo)
							{
								current.currentExtraAmmo += ammo.ammoAmount;
								ammo.ammoAmount = 0;


							}
							if (ammo.pickupSound)
								ammo.gameObject.GetComponent<AudioSource> ().Play ();


						}
						if(ammo.unlimitedAmmo)
						{
							current.currentExtraAmmo = current.maxExtraAmmo;
							if (ammo.pickupSound)
								ammo.gameObject.GetComponent<AudioSource> ().Play ();
						}

					}

				}




			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {

  
    public float fireSpeed=15;
	public float waitTillNextFire=0;
	public GameObject bullet;
	public GameObject bulletSpawn;


	public GameObject bulletSound;
	public GameObject holdSound;

	public GameObject MuzzleFlash;
	public GameObject holdMuzzleFlash;


	public bool reloading = false;
	public Animation reloadAnimation;
	public AudioSource ReoloadSound;
	public string reloadAnimationString;


	public int clipSize = 25;
	public int currentClip =25;
	public int maxExtraAmmo = 100;
	public int currentExtraAmmo= 100;


	public int ammoType=0;




	public Texture bulletHudTexture;
	public Rect ammoCountRect = new Rect (25, 25, 50, 25);



	public int ammoStartX = 100;
	public int ammoY = 25;
	public Vector2 ammoSize = new Vector2 (10, 25);
	public int ammoSpacing = 4;

	//adding some decoration around the ammo HUD
	/*public Rect ammoDecorationHudRect = new Rect(25,25,50,25);
	public Texture ammoDecorationTexture;
	*/

	// Use this for initialization
	void Start () {
	
	}

 

   
    // Update is called once per frame
    void Update () {
       

		if (currentClip > clipSize)
			currentClip = clipSize;
		if (currentExtraAmmo > maxExtraAmmo)
			currentExtraAmmo = maxExtraAmmo;
		if (currentClip < 0)
			currentClip = 0;
		if (currentExtraAmmo < 0)
			currentExtraAmmo = 0;



        if (!reloading && (Input.GetButtonDown("Reload") || ViveControllerShooting.isReloading == true) && currentClip < clipSize && currentExtraAmmo > 0)
        {

            reloading = true;
            reloadAnimation.Play(reloadAnimationString);
            ReoloadSound.Play();
        }

        if ((Input.GetButton("Fire1") || ViveControllerShooting.isFiring==true) && currentClip > 0 && !reloading)
        {

            if (waitTillNextFire <= 0)
            {
                currentClip -= 1;
                if (bullet)
                    Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);

                if (bulletSound)
                    holdSound = (GameObject)Instantiate(bulletSound, bulletSpawn.transform.position, bulletSpawn.transform.rotation);


                if (MuzzleFlash)
                    holdMuzzleFlash = (GameObject)Instantiate(MuzzleFlash, bulletSpawn.transform.position, bulletSpawn.transform.rotation);



                waitTillNextFire = 1;

            }



        }
        /*if(!reloading && Input.GetButtonDown("Fire1") && currentClip==0 && currentExtraAmmo>0){

			reloading = true;
			reloadAnimation.Play(reloadAnimationString);
			ReoloadSound.Play();
		}
		*/

        if (reloading && !reloadAnimation.IsPlaying(reloadAnimationString)){

			if (currentExtraAmmo >= clipSize - currentClip) 
			{
				currentExtraAmmo -= clipSize - currentClip;
				currentClip = clipSize;
			
			}
			if (currentExtraAmmo < clipSize - currentClip) 
			{
				currentClip += currentExtraAmmo ;
				currentExtraAmmo = 0;

			}
			reloading = false;


		}

		
		waitTillNextFire -= Time.deltaTime * fireSpeed;
		if (holdSound)
			holdSound.transform.parent = transform;

		if (holdMuzzleFlash)
			holdMuzzleFlash.transform.parent = transform;
	}




	public void OnGUI(){

		for(int i=1;i<=currentClip;i++){
			GUI.DrawTexture (new Rect (ammoStartX + ((i - 1) * (ammoSize.x + ammoSpacing)), ammoY, ammoSize.x, ammoSize.y), bulletHudTexture);

		}
		GUI.Label (ammoCountRect, currentExtraAmmo.ToString ());

		//if u want to add some decoration around the ammo HUD enable next line and corresponding variables
		//GUI.DrawTexture (ammoDecorationHudRect, ammoDecorationTexture);

	}

}

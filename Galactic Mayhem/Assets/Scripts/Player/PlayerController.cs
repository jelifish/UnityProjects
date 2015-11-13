﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public class Load
{
	public Vector3 offset = new Vector3(0,0,0);
	public Quaternion rotation;
	//GameObject projectile = Instantiate (loader, shotSpawn.position, shotSpawn.rotation) as GameObject;
	public GameObject projectile;
	public GameObject sound = GameObject.Find("BoltSound");

	public Load(GameObject projectile,Quaternion rotation)
	{
		this.projectile = projectile;
		this.rotation = rotation;
	}

	public Load(GameObject projectile,Vector3 offset,Quaternion rotation)
	{
		this.offset = offset;
		this.projectile = projectile;
		this.rotation = rotation;
	}
//	public void setSound(GameObject soundObject){
//		sound = soundObject;
//	}
}

public class PlayerController : CollisionObject
{
	public override void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") {

			
		} else if(other.gameObject.tag == "EnemyBullet"){
			takeDamage (other.gameObject.GetComponent<Rigidbody> ().velocity.magnitude);
			Destroy(other.gameObject);
		}else if(other.gameObject.tag == "Player"){
//			other.GetComponent<PlayerController>().takeDamage(getShield()+getHull());
//			takeDamage (other.GetComponent<PlayerController>().getHull() + other.GetComponent<PlayerController>().getShield());
		}else if(other.gameObject.tag == "Bullet"||other.gameObject.tag == "TriggeredBullet"){

		}
	}





	public GameObject weaponSlot;
	private List<GameObject> weaponSlots = new List<GameObject>();
	public int numOfWeaponSlots;


	private GameObject GameController;

	public float chargeShotDelay;
	public float fireStormDelay;
	public int fireStormDuration;
	public float rotationSpeed;
	public Load load;
//	private bool loaded = false;

	public GameObject fireball1;
	public Vector3 attack1DefaultSize = new Vector3(1F,1F,1F);
	public float attack1DefaultDrag = .1f;
	public int chargeShotNum;
	//public GameObject fireball2;

	public List<Load> loader = new List<Load>();

	//public Transform shotSpawn;
	
//	public float fireRate = 0.5F;
//	private float nextFire = 0.0F;
//	private bool channeling;

	//private Animator anim;

//	public void shoot(Load load) 
//	{
//		Instantiate (load.projectile, shotSpawn.position + load.offset, shotSpawn.rotation * load.rotation);
//		//Instantiate (load.projectile, shotSpawn.position, shotSpawn.rotation);
//		//Debug.Log (shotSpawn.rotation);
//		//Instantiate(load.projectile, new Vector3(3,4,0), shotSpawn.rotation);
//		//fireballSound.GetComponent<AudioSource> ().Play ();
//		//anim.SetBool (0, true);
//		//return load;
//	}

	void Awake(){
	//	anim = GetComponent<Animator> ();
	}
	public void setBoundary(){
		float sectorSize = GameController.GetComponent<GameController> ().sectorSize;
		boundary.xMin = - (sectorSize / 2);
		boundary.xMax = (sectorSize / 2);
		boundary.yMin = - (sectorSize / 2);
		boundary.yMax = (sectorSize / 2);
		GameController.GetComponentInChildren<BoxColSetSectorSize> ().setBounds (sectorSize);
	}
	void Start(){

	}
	public void init(){
		
		
		GameController = GameObject.Find ("GameController");
		maxHull = hull;
		maxShield = shield;
		
		
		
		
		//	fireball1.transform.localScale = attack1DefaultSize;
		//	fireball1.GetComponent<Rigidbody>().drag = attack1DefaultDrag;
		//	ready = true;
		//channeling = false;
		
		
		setBoundary (); /////////////////sets bounds for player movement.
		sectorClear = false;
		
		for (int i=0; i<numOfWeaponSlots; i++) {
			GameObject tempSlot = (GameObject)Instantiate (weaponSlot, this.GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation);
			tempSlot.GetComponent<WeaponSystem>().setSlotPosition(i);
			tempSlot.transform.parent = this.transform;
			weaponSlots.Add(tempSlot);
			if(i==0){
				tempSlot.GetComponent<WeaponSystem>().initWeapon();
			}
			if(i==1){
				tempSlot.GetComponent<WeaponSystem>().initWeapon();
			}
			if(i==2){
				tempSlot.GetComponent<WeaponSystem>().initWeapon();
			}
		}
		//shotSpawn = weaponSlots [0].transform;  
		

	}
//
//	IEnumerator fireStorm()
//	{
//		fireball1.transform.localScale = new Vector3(0.5F,0.5F,0.5F);
//		//channeling = true;
//		//ready = false;
//		while (true) {
//			for(int i=0;i<fireStormDuration;i++){
//				fireball1.GetComponent<Rigidbody>().drag = 3.0f;
//				
//				loader.Add (new Load (fireball1, Quaternion.identity * Quaternion.Euler(0f, 0.0f, Random.Range(-20.0f, 20.0f)) ));
//				//foreach (Load load in loader) {
//					//shoot (load); //shoots and removes the loaded object
//					
//				//}
//				yield return new WaitForSeconds (.01f);
//			}
//			break;
//		}
//		fireball1.transform.localScale = attack1DefaultSize;
//		fireball1.GetComponent<Rigidbody>().drag = attack1DefaultDrag;
//		//channeling = false;
//		fireball1.transform.localScale = new Vector3(1F,1F,1F);
//		yield return new WaitForSeconds (fireStormDelay);//cooldown before cast again
//		//ready = true;
//
//
//	}

//	private bool ready;
	//private bool freezeChara;

	void Update()
	{
//		if (ready) {
//			if (Input.GetButtonDown ("Fire3")) {
//				StartCoroutine (fireStorm());
//				ready = false;
//				
//				nextFire = Time.time;
//				
//			}
//		}
//		if (!Input.GetButton ("Fire1") && Time.time > nextFire) {
//			if (loaded == false) {
//				
//				fireball1.GetComponent<Rigidbody>().drag = attack1DefaultDrag;
//				
//				loader.Add (new Load (fireball1, Quaternion.identity * Quaternion.Euler(0f, 0.0f, Random.Range(-20.0f, 20.0f)) ));
//				
//			}
//			
////			foreach (Load load in loader) {
////				shoot (load); //shoots and removes the loaded object
////				
////			}
//			loader.Clear ();
//			loaded = false;//empty magazine
//			
//			nextFire = Time.time + fireRate;
//		} else if (Input.GetButton ("Fire1") && Time.time > nextFire + chargeShotDelay && !loaded) {
//			nextFire = Time.time;
//			loaded = true;  //locked and loaded
//			//				loader.Add (new Load (fireball1, Quaternion.identity * new Quaternion (0f, 0.01f, 0f, 0.1f))); angular change left
//			//				loader.Add (new Load (fireball1, Quaternion.identity * new Quaternion (0f, -0.01f, 0f, 0.1f))); angular change right
//			for(int i=0;i<chargeShotNum;i++){
//				loader.Add (new Load (fireball1, Quaternion.identity));
//			}
//			
//		} else if (Input.GetButton ("Fire1") && Time.time > nextFire && loaded) {
//			nextFire = Time.time + fireRate;
//			//shoot (new Load (fireball1, Quaternion.identity));
//		}
//		
//		
//		if ((Input.GetButtonUp ("Fire1") && loaded == true) || Input.GetButtonDown ("Fire3")) { 
//			foreach (Load load in loader) {
//			//	shoot (load); //shoots and removes the loaded object
//			}
//			loader.Clear ();
//			loaded = false;//empty magazine
//		}

	}


	public float speed;
	
	public Boundary boundary;
	public bool sectorClear = false;
	public void setMoveDirection(Vector3 move){
		this.GetComponent<Rigidbody>().velocity += move * speed*5;
		this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity.normalized * speed;
	}
	void FixedUpdate ()
	{
		//if (!freezeChara) {

//			float moveHorizontal = Input.GetAxis ("HorizontalPlayer");
//			float moveVertical = Input.GetAxis ("VerticalPlayer");
//			Vector3 movement = new Vector3 (moveHorizontal,moveVertical, 0.0f);
//		setMoveDirection (movement);	



			//this.GetComponent<Rigidbody>().velocity += movement * speed;
		//Debug.Log (this.GetComponent<Rigidbody> ().velocity.magnitude);
		//if (this.GetComponent<Rigidbody> ().velocity.magnitude > 20) {
		//	this.GetComponent<Rigidbody> ().velocity = 20;
		//}
			
		if (!sectorClear) {
			this.GetComponent<Rigidbody> ().position = new Vector3 
				(
					Mathf.Clamp (this.GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax), 
				    Mathf.Clamp (this.GetComponent<Rigidbody> ().position.y, boundary.yMin, boundary.yMax), 
					0.0f//Mathf.Clamp (this.GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			);
		}


		//this.GetComponent<Rigidbody>().position = new Vector3 (this.GetComponent<Rigidbody>().position.x, this.GetComponent<Rigidbody>().position.y,0.0f);

			//GetComponent<Rigidbody> ().position = GetComponent<Rigidbody> ().rotation * Quaternion.Euler (0.0f, 0f, moveHorizontal * rotationSpeed);
		}
	//}

	void LateUpdate(){



	}


}
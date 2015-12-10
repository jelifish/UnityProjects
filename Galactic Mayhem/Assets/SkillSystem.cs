﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//public enum Activation { Button, Action, Automatic };
public enum SkillType { MaterialType, ControlType, GuardType, AssaultType, AuraType };
//public enum SkillLevel { Lv1, Lv2, Lv3};

//=== 001 Compressed Bolts =============================
public class Skill001 : Skill {
	public override void init(){
		skillName = "Compressed Bolts";
		skillType = SkillType.MaterialType;
	}
	public override void attachAttributes(){
		spawn.AddComponent<Skill001Attr> ();
		spawn.GetComponent<Skill001Attr> ().projectile = this.projectile;
	}
	public override void attachSpecialAttributes(){
		spawn.AddComponent<Skill011Attr> ();
		spawn.GetComponent<Skill011Attr> ().projectile = this.projectile;
	}
}
public class Skill001Attr : Interactable{
	public override void mouseUpFire(){
		if (isTimeSlowed) { //slows time for the duration of the skill
			Time.timeScale += 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = false; 
		}
	}
	public override void mouseDownFire(){
		if (!isTimeSlowed) {	
			Time.timeScale -= 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = true;
		}
		stopDestroy ();
		StartCoroutine (fire ());
	}
	
	public void stopDestroy(){
		GetComponent<SpawnedWeapon> ().destroyThis = false;
	}
	
	void Start(){
		gameObject.GetComponent<Renderer> ().material.SetColor ("_TintColor", new Color(152/255.0F,203/255.0F,74/255.0F,255f));
	}
	void OnDestroy() {
		if (isTimeSlowed) {
			Time.timeScale += 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = false;
		}
	}
	IEnumerator fire()
	{
		initialSpeed = 5;
		while (true) {
			for(int i=0;i<50;i++){
				GameObject temp = (GameObject)Instantiate (projectile, this.transform.position, this.transform.rotation * Quaternion.Euler(0f, 0.0f, Random.Range(-10.0f, 10.0f)));
				temp.GetComponent<Mover>().speed = Random.Range(initialSpeed*.9f, initialSpeed*1.1f);
				yield return new WaitForSeconds (.01f);
			}
			break;
		}
		if (isTimeSlowed) {
			Time.timeScale += 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = false;
		}
		this.GetComponent<MeshRenderer> ().enabled = false;
		yield return new WaitForSeconds (5f);
		Destroy (this.gameObject);

	}
}

//=== 002 Cone Bolts =============================
public class Skill002 : Skill {
	public override void init(){
		skillName = "Cone Bolts";
		skillType = SkillType.MaterialType;
	}
	public override void attachAttributes(){
		spawn.AddComponent<Skill002Attr> ();
		spawn.GetComponent<Skill002Attr> ().projectile = this.projectile;
	}
	public override void attachSpecialAttributes(){
		spawn.AddComponent<Skill011Attr> ();
		spawn.GetComponent<Skill011Attr> ().projectile = this.projectile;
	}
}
public class Skill002Attr : Interactable{
	public override void mouseUpFire(){
		if (isTimeSlowed) {
			Time.timeScale += 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = false;
		}
	}
	public override void mouseDownFire(){
		if (!isTimeSlowed) {	
			Time.timeScale -= 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = true;
		}
		stopDestroy ();
		StartCoroutine (fire ());
	}
	
	public void stopDestroy(){
		GetComponent<SpawnedWeapon> ().destroyThis = false;
	}
	
	void Start(){
		gameObject.GetComponent<Renderer> ().material.SetColor ("_TintColor", new Color(152/255.0F,203/255.0F,74/255.0F,255f));
	}
	void OnDestroy() {
		if (isTimeSlowed) {
			Time.timeScale += 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = false; 
		}
	}
	IEnumerator fire()
	{
		initialSpeed = 15;
		while (true) {
			for(int i=0;i<50;i++){
				GameObject temp = (GameObject)Instantiate (projectile, this.transform.position, this.transform.rotation * Quaternion.Euler(0f, 0.0f, Random.Range(-10.0f, 10.0f)));
				temp.GetComponent<Mover>().speed = Random.Range(initialSpeed*.9f, initialSpeed*1.1f);
					yield return new WaitForSeconds (.03f);
			}
			break;
		}
		if (isTimeSlowed) {
			Time.timeScale += 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = false;
		}
		this.GetComponent<MeshRenderer> ().enabled = false;
		yield return new WaitForSeconds (5f);
		Destroy (this.gameObject);
	}
}

//=== 003 Machine Gun =============================
public class Skill003 : Skill {
	public override void init(){
		skillName = "Machine Gun";
		skillType = SkillType.MaterialType;
	}
	public override void attachAttributes(){
		spawn.AddComponent<Skill003Attr> ();
		spawn.GetComponent<Skill003Attr> ().projectile = this.projectile;
	}
	public override void attachSpecialAttributes(){
		spawn.AddComponent<Skill011Attr> ();
		spawn.GetComponent<Skill011Attr> ().projectile = this.projectile;
	}
}
public class Skill003Attr : Interactable{
	public override void mouseUpFire(){
		if (isTimeSlowed) {
			Time.timeScale += 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = false;
		}
	}
	public override void mouseDownFire(){
		if (!isTimeSlowed) {	
			Time.timeScale -= 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = true;
		}
		stopDestroy ();
		StartCoroutine (fire ());
	}
	
	public void stopDestroy(){
		GetComponent<SpawnedWeapon> ().destroyThis = false;
	}
	
	void Start(){
		gameObject.GetComponent<Renderer> ().material.SetColor ("_TintColor", new Color(152/255.0F,203/255.0F,74/255.0F,255f));
	}
	void OnDestroy() {
		if (isTimeSlowed) {
			Time.timeScale += 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = false; 
		}
	}
	IEnumerator fire()
	{
		initialSpeed = 25;
		while (true) {
			for(int i=0;i<25;i++){
				GameObject temp = (GameObject)Instantiate (projectile, this.transform.position, this.transform.rotation * Quaternion.Euler(0f, 0.0f, Random.Range(-10.0f, 10.0f)));
				temp.GetComponent<Mover>().speed = Random.Range(initialSpeed*.9f, initialSpeed*1.1f);
				if(GetComponent<SpawnedWeapon>().towardsObject!=null){
					Vector3 targetVector = (GetComponent<SpawnedWeapon>().towardsObject.transform.position - temp.transform.position).normalized;
					temp.GetComponent<Rigidbody>().AddForce(targetVector * 200);
				}
				yield return new WaitForSeconds (.1f);
			}
			break;
		}
		if (isTimeSlowed) {
			Time.timeScale += 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = false;
		}
		this.GetComponent<MeshRenderer> ().enabled = false;
		yield return new WaitForSeconds (5f);
		Destroy (this.gameObject);
	}
}

//=== 011 Accelerator =============================
public class Skill011 : Skill {
	public override void init(){
		skillName = "Accelerator";
		skillType = SkillType.ControlType;

	}
	public override void attachAttributes(){
		spawn.AddComponent<Skill011Attr> ();
		spawn.GetComponent<Skill011Attr> ().projectile = this.projectile;
	}
	public override void attachSpecialAttributes(){
		spawn.AddComponent<AcceleratorInteractable> ();
		spawn.GetComponent<AcceleratorInteractable> ().projectile = this.projectile;
	}
}
public class Skill011Attr : Interactable{

	public List<GameObject> bullets = new List<GameObject>();

	
	public override void mouseUpFire(){
		Time.timeScale += 0.5F;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
		StartCoroutine (Blast ());
		
	}
	public override void mouseDownFire(){
		
		Time.timeScale -= 0.5F;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
		stopDestroy ();

		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5);
		//int i = 0;
		foreach (Collider col in hitColliders) {
			if(col.tag == "Bullet"&&col.GetComponent<FindTowardsVector>()!=null){
				col.GetComponent<FindTowardsVector>().towardsObject = GetComponent<SpawnedWeapon>().towardsObject;
				bullets.Add(col.gameObject);
			}
		}




//		foreach(GameObject bolt in GameObject.FindGameObjectsWithTag("Bullet") ){
//			//Debug.Log("found");]
//			if(Vector3.Distance(bolt.transform.position, this.transform.position) < 3){
//			bullets.Add(bolt);
//			
//			}
//			
//			//bolt.GetComponent<Rigidbody>().AddForce(bolt.transform.right * 50);
//			
//		}
	}
	
	public void stopDestroy(){
		GetComponent<SpawnedWeapon> ().destroyThis = false;
	}
	
	void Start(){
		gameObject.GetComponent<Renderer> ().material.SetColor ("_TintColor", new Color(247/255.0F,216/255.0F,66/255.0F,255f));
	}
	
	IEnumerator Blast()
	{
		yield return new WaitForSeconds (0.1f);
		foreach(GameObject bolt in bullets){
			if(bolt !=null){
				bolt.GetComponent<Rigidbody>().AddForce(bolt.GetComponent<FindTowardsVector>().targetVector * 25);
				//bolt.GetComponent<Rigidbody>().AddForce(bolt.transform.right * 100);
				//Debug.Log(bolt.GetComponentInChildren<RotateTowards>().angle);
			}
		}
		yield return new WaitForSeconds (0.1f);
		foreach(GameObject bolt in bullets){
			if(bolt !=null){
				bolt.GetComponent<Rigidbody>().AddForce(bolt.GetComponent<FindTowardsVector>().targetVector * 50);
			}
		}
		yield return new WaitForSeconds (0.1f);
		foreach(GameObject bolt in bullets){
			if(bolt !=null){
				bolt.GetComponent<Rigidbody>().AddForce(bolt.GetComponent<FindTowardsVector>().targetVector * 75);
			}
		}
		yield return new WaitForSeconds (0.1f);
		foreach(GameObject bolt in bullets){
			if(bolt !=null){
				bolt.GetComponent<Rigidbody>().AddForce(bolt.GetComponent<FindTowardsVector>().targetVector * 100);
			}
		}
		Destroy (this.gameObject);
		yield return new WaitForSeconds (0.1f);
		
	}
}
//=== 012 Instant Imploder =============================
public class Skill012 : Skill {
	public override void init(){
		skillName = "Instant Imploder";
		skillType = SkillType.ControlType;
		
	}
	public override void attachAttributes(){
		spawn.AddComponent<Skill012Attr> ();
		spawn.GetComponent<Skill012Attr> ().projectile = this.projectile;
	}
	public override void attachSpecialAttributes(){
		spawn.AddComponent<AcceleratorInteractable> ();
		spawn.GetComponent<AcceleratorInteractable> ().projectile = this.projectile;
	}
}
public class Skill012Attr : Interactable{
	
	public List<GameObject> bullets = new List<GameObject>();
	
	public override void mouseUpFire(){
	}
	public override void mouseDownFire(){
		stopDestroy ();
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5);
		foreach (Collider col in hitColliders) {
			if(col.tag == "Bullet"){
				col.GetComponentInChildren<RotateTowards>().towardsObject = this.gameObject;
				bullets.Add(col.gameObject);
			}
		}

		StartCoroutine (Blast ());
	}
	
	public void stopDestroy(){
		GetComponent<SpawnedWeapon> ().destroyThis = false;
	}
	
	void Start(){
		gameObject.GetComponent<Renderer> ().material.SetColor ("_TintColor", new Color(247/255.0F,216/255.0F,66/255.0F,255f));
	}
	
	IEnumerator Blast()
	{
		yield return new WaitForSeconds (0.1f);
		foreach(GameObject bolt in bullets){
			if(bolt !=null&&Vector3.Distance(bolt.transform.position, this.transform.position) < 10){
				bolt.GetComponent<Rigidbody>().AddForce(bolt.GetComponentInChildren<RotateTowards>().targetVector.normalized * 25);
				//bolt.GetComponent<Rigidbody>().AddForce(bolt.transform.right * 100);
				//Debug.Log(bolt.GetComponentInChildren<RotateTowards>().angle);
			}
		}
		yield return new WaitForSeconds (0.1f);
		foreach(GameObject bolt in bullets){
			if(bolt !=null&&Vector3.Distance(bolt.transform.position, this.transform.position) < 10){
				bolt.GetComponent<Rigidbody>().AddForce(bolt.GetComponentInChildren<RotateTowards>().targetVector.normalized * 50);
			}
		}
		yield return new WaitForSeconds (0.1f);
		foreach(GameObject bolt in bullets){
			if(bolt !=null&&Vector3.Distance(bolt.transform.position, this.transform.position) < 10){
				bolt.GetComponent<Rigidbody>().AddForce(bolt.GetComponentInChildren<RotateTowards>().targetVector.normalized * 75);
			}
		}
		yield return new WaitForSeconds (0.1f);
		foreach(GameObject bolt in bullets){
			if(bolt !=null&&Vector3.Distance(bolt.transform.position, this.transform.position) < 10){
				bolt.GetComponent<Rigidbody>().AddForce(bolt.GetComponentInChildren<RotateTowards>().targetVector.normalized * 100);
			}
		}
		Destroy (this.gameObject);
		yield return new WaitForSeconds (0.1f);
		
	}
}

//=== 031 Mini Missile =============================
public class Skill031 : Skill {
	public override void init(){
		skillName = "Mini Missile";
		skillType = SkillType.AssaultType;
	}
	public override void attachAttributes(){
		spawn.AddComponent<Skill031Attr> ();
		spawn.GetComponent<Skill031Attr> ().projectile = Resources.Load ("Projectiles/Missile")as GameObject;
	}
	public override void attachSpecialAttributes(){
		spawn.AddComponent<Skill011Attr> ();
		spawn.GetComponent<Skill011Attr> ().projectile = this.projectile;
	}
}
public class Skill031Attr : Interactable{
	public List<GameObject> bullets = new List<GameObject>();
	public GameObject bolt = Resources.Load ("Projectiles/Bolt")as GameObject;

	public override void mouseUpFire(){
		if (isTimeSlowed) { //slows time for the duration of the skill
			Time.timeScale += 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = false; 
		}
	}
	public override void mouseDownFire(){
		if (!isTimeSlowed) {	
			Time.timeScale -= 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = true;
		}
		stopDestroy ();
		StartCoroutine (fire ());
	}
	
	public void stopDestroy(){
		GetComponent<SpawnedWeapon> ().destroyThis = false;
	}
	
	void Start(){
		gameObject.GetComponent<Renderer> ().material.SetColor ("_TintColor", new Color(250/255.0F,130/255.0F,40/255.0F,255f));
	}
	void OnDestroy() {
		if (isTimeSlowed) {
			Time.timeScale += 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = false;
		}
	}
	IEnumerator Blast()
	{
		yield return new WaitForSeconds (0.1f);
		foreach(GameObject bolt in bullets){
			if(bolt !=null){
				Vector3 targetVector = (bolt.transform.position - temp.transform.position).normalized;
				bolt.GetComponent<Rigidbody>().AddForce(targetVector * 50);
				//bolt.GetComponent<Rigidbody>().AddForce(100);
				//bolt.GetComponent<Rigidbody>().AddForce(bolt.transform.right * 100);
				//Debug.Log(bolt.GetComponentInChildren<RotateTowards>().angle);
			}
		}
		yield return new WaitForSeconds (1f);
		foreach(GameObject bolt in bullets){
			if(bolt !=null){
				Vector3 targetVector = (bolt.transform.position - temp.transform.position).normalized;
				bolt.GetComponent<Rigidbody>().AddForce(targetVector * 75);
				//bolt.GetComponent<Rigidbody>().AddForce(100);
				//bolt.GetComponent<Rigidbody>().AddForce(bolt.transform.right * 100);
				//Debug.Log(bolt.GetComponentInChildren<RotateTowards>().angle);
			}
		}
		yield return new WaitForSeconds (.01f);

		foreach(GameObject bolt in bullets){
			if(bolt !=null){
				Vector3 targetVector = (bolt.transform.position - temp.transform.position).normalized;
				bolt.GetComponent<Rigidbody>().AddForce(targetVector * 100);
				//bolt.GetComponent<Rigidbody>().AddForce(100);
				//bolt.GetComponent<Rigidbody>().AddForce(bolt.transform.right * 100);
				//Debug.Log(bolt.GetComponentInChildren<RotateTowards>().angle);
			}
		}
		yield return new WaitForSeconds (.1f);
		foreach(GameObject bolt in bullets){
			if(bolt !=null){
				Vector3 targetVector = (bolt.transform.position - temp.transform.position).normalized;
				bolt.GetComponent<Rigidbody>().AddForce(targetVector * 100);
				//bolt.GetComponent<Rigidbody>().AddForce(100);
				//bolt.GetComponent<Rigidbody>().AddForce(bolt.transform.right * 100);
				//Debug.Log(bolt.GetComponentInChildren<RotateTowards>().angle);
			}
		}
		yield return new WaitForSeconds (0.1f);
		foreach(GameObject bolt in bullets){
			if(bolt !=null){
				Vector3 targetVector = (bolt.transform.position - temp.transform.position).normalized;
				bolt.GetComponent<Rigidbody>().AddForce(targetVector * 100);
				//bolt.GetComponent<Rigidbody>().AddForce(100);
				//bolt.GetComponent<Rigidbody>().AddForce(bolt.transform.right * 100);
				//Debug.Log(bolt.GetComponentInChildren<RotateTowards>().angle);
			}
		}
		yield return new WaitForSeconds (0.1f);
//		foreach(GameObject bolt in bullets){
//			if(bolt !=null&&Vector3.Distance(bolt.transform.position, this.transform.position) < 10){
//				bolt.GetComponent<Rigidbody>().AddForce(bolt.GetComponentInChildren<RotateTowards>().targetVector.normalized * 50);
//			}
//		}
//		yield return new WaitForSeconds (0.1f);
//		foreach(GameObject bolt in bullets){
//			if(bolt !=null&&Vector3.Distance(bolt.transform.position, this.transform.position) < 10){
//				bolt.GetComponent<Rigidbody>().AddForce(bolt.GetComponentInChildren<RotateTowards>().targetVector.normalized * 75);
//			}
//		}
//		yield return new WaitForSeconds (0.1f);
//		foreach(GameObject bolt in bullets){
//			if(bolt !=null&&Vector3.Distance(bolt.transform.position, this.transform.position) < 10){
//				bolt.GetComponent<Rigidbody>().AddForce(bolt.GetComponentInChildren<RotateTowards>().targetVector.normalized * 100);
//			}
//		}
		Destroy (temp);
		Destroy (this.gameObject);
		yield return new WaitForSeconds (0.1f);
		
	}
	GameObject temp;
	IEnumerator fire()
	{
		initialSpeed = 5;
		//while (true) {
			//for(int i=0;i<50;i++){
		temp = (GameObject)Instantiate (projectile, this.transform.position, this.transform.rotation * Quaternion.Euler(0f, 0.0f, Random.Range(0, 360)));
		temp.GetComponent<Mover>().speed = Random.Range(initialSpeed*.9f, initialSpeed*1.7f);
		//bullets.Add(temp.gameObject);
				
		while(GetComponent<SpawnedWeapon>().towardsObject!=null){

				Vector3 targetVector = (GetComponent<SpawnedWeapon>().towardsObject.transform.position - temp.transform.position).normalized;
				temp.GetComponent<Rigidbody>().AddForce(targetVector * 25);
			yield return new WaitForSeconds (.01f);
		}
		yield return new WaitForSeconds (.01f);

		temp.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		while (true) {
			for(int i=0;i<150;i++){
				GameObject bolty= (GameObject)Instantiate (bolt, temp.transform.position, this.transform.rotation * Quaternion.Euler(0f, 0.0f, Random.Range(0, 360)));
				bolty.GetComponent<Mover>().speed = Random.Range(initialSpeed*.9f, initialSpeed*1.1f);
				yield return new WaitForSeconds (.01f);
			}
			break;
		}
		yield return new WaitForSeconds (.01f);
		Collider[] hitColliders = Physics.OverlapSphere(temp.transform.position, 10);
		foreach (Collider col in hitColliders) {
			if(col.tag == "Bullet"){
				
				col.GetComponentInChildren<RotateTowards>().towardsObject = this.gameObject;
				bullets.Add(col.gameObject);
			}
		}
		yield return new WaitForSeconds (.01f);
		StartCoroutine (Blast ());

			//}
			//Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5);
//			foreach (Collider col in hitColliders) {
//				if(col.tag == "Bullet"){
//					col.GetComponentInChildren<RotateTowards>().towardsObject = this.gameObject;
//					bullets.Add(col.gameObject);
//				}
//			}
		//	break;
		//}
		yield return new WaitForSeconds (1f);

//		foreach(GameObject bolt in bullets){
//			if(bolt !=null){
//				bolt.GetComponent<Rigidbody>().AddForce(bolt.GetComponentInChildren<RotateTowards>().targetVector.normalized * 100);
//			}
//		}

		if (isTimeSlowed) {
			Time.timeScale += 0.5F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			isTimeSlowed = false;
		}
		this.GetComponent<MeshRenderer> ().enabled = false;
		yield return new WaitForSeconds (5f);
		Destroy (this.gameObject);
		
	}
}



//=== Skill Base Class ===============================
public class Skill : MonoBehaviour{
	public SkillType skillType = SkillType.MaterialType; // this is the type of skill
	public GameObject projectile = null; //this is the projectile that the skill fires
	public PlayerController player; // this is the player object
	public float coolDown; // this is the cooldown of the skill
	public float minCD = 5f, maxCD = 7f; // min and max CD, randomly generated
	public GameObject interactable; //this is the spawned weapon
	
	public string skillName = "Nul"; //skillname is set in the child

	public virtual void init(){// called before initialization of spawner
	}
	public virtual void attachAttributes(){ //done in child, assigns to the spawner script a script that determines what the skill will do when clicked
	}
	public virtual void attachSpecialAttributes(){
	}
	IEnumerator interactableCreator() //creates a spawn
	{
		yield return new WaitForSeconds (Random.Range(0f,2f));
		while(true){
			yield return new WaitForSeconds (coolDown);
			spawnInteractable();
			
		}
	}
	
	protected GameObject spawn;//do not mess with this
	public bool isSpecialOn = false;
	
	public void spawnInteractable(){ //spawner instatiation at the correct random coords
		genXY ();
		spawn = (GameObject)Instantiate (interactable, new Vector3 (x, y, 0f), Quaternion.identity);
		if (isSpecialOn) {
			attachSpecialAttributes ();
			isSpecialOn = false;
		} else {
			attachAttributes ();
		}
	}

	private float x,y;
	private void genXY(){
		float playerX = player.transform.position.x;
		float playerY = player.transform.position.y;
		x = Random.Range (playerX - 10, playerX + 10);
		y = Random.Range (playerY - 10, playerY + 10);
		if (x < playerX + 3 && x > playerX - 3 && y < playerY + 3 && y > playerY - 3) {
			genXY ();
		}
	}

	void Awake () {
		coolDown = Random.Range (minCD, maxCD);
		if (GameObject.FindWithTag ("Player") != null) {
			player = GameObject.FindWithTag ("Player").GetComponent<PlayerController> ();
		} else {
			Debug.LogWarning ("Cannot Find Player");
		}
		
		interactable = Resources.Load ("SpawnedWeapon")as GameObject;
		projectile = Resources.Load ("Projectiles/Bolt")as GameObject;
		
		init ();//anything else we need to do before creating spawns 
		StartCoroutine (interactableCreator ());//creates spawns at intervals
	}
}
//=== Skill Database =============================

public class SkillSystem: MonoBehaviour {



	public GameObject[] activeSkills;

//	public void UpdateSkillSystem(MonoBehaviour parentMonoBehaviour) {
////		skills.ForEach(skill => skill.Update(parentMonoBehaviour));
//	}

	public bool equipSkill(GameObject obj){
		if (obj.GetComponent<Skill>().skillType == SkillType.MaterialType) {
			if(transform.FindChild("Material").childCount >=1){
				Transform[] ts = transform.FindChild("Material").GetComponentsInChildren<Transform>();
				foreach(Transform t in ts)
				{
					if(t.GetComponent<Skill>() != null)
					{
						t.parent = transform.FindChild("Inactive");
					}
				}

			}
			obj.transform.parent = transform.FindChild("Material");
			return true;
		}
		if (obj.GetComponent<Skill>().skillType == SkillType.ControlType) {
			if(transform.FindChild("Control").childCount >=1){
				Transform[] ts = transform.FindChild("Control").GetComponentsInChildren<Transform>();
				foreach(Transform t in ts)
				{
					if(t.GetComponent<Skill>() != null)
					{
						t.parent = transform.FindChild("Inactive");
					}
				}
				
			}
			obj.transform.parent = transform.FindChild("Control");
			return true;
		}
		if (obj.GetComponent<Skill>().skillType == SkillType.GuardType) {
			if(transform.FindChild("Guard").childCount >=1){
				Transform[] ts = transform.FindChild("Guard").GetComponentsInChildren<Transform>();
				foreach(Transform t in ts)
				{
					if(t.GetComponent<Skill>() != null)
					{
						t.parent = transform.FindChild("Inactive");
					}
				}
				
			}
			obj.transform.parent = transform.FindChild("Guard");
			return true;
		}
		if (obj.GetComponent<Skill>().skillType == SkillType.AssaultType) {
			if(transform.FindChild("Assault").childCount >=1){
				Transform[] ts = transform.FindChild("Assault").GetComponentsInChildren<Transform>();
				foreach(Transform t in ts)
				{
					if(t.GetComponent<Skill>() != null)
					{
						t.parent = transform.FindChild("Inactive");
					}
				}
				
			}
			obj.transform.parent = transform.FindChild("Assault");
			return true;
		}
		if (obj.GetComponent<Skill>().skillType == SkillType.AuraType) {
			if(transform.FindChild("Aura").childCount >=1){
				Transform[] ts = transform.FindChild("Aura").GetComponentsInChildren<Transform>();
				foreach(Transform t in ts)
				{
					if(t.GetComponent<Skill>() != null)
					{
						t.parent = transform.FindChild("Inactive");
					}
				}
				
			}
			obj.transform.parent = transform.FindChild("Aura");
			return true;
		}
		return false;
	}

	GameObject material, control, guard, assault, aura, inactive;
	public void init(){
		Debug.Log ("hit");
		activeSkills = new GameObject[6];
		material = new GameObject ("Material");
		control = new GameObject("Control");
		guard = new GameObject ("Guard");
		assault = new GameObject("Assault");
		aura = new GameObject("Aura");
		inactive = new GameObject("Inactive");

		material.transform.parent = this.transform;
		activeSkills[0] = material;
		control.transform.parent = this.transform;
		activeSkills[1] = control;
		guard.transform.parent = this.transform;
		activeSkills[2] = guard;
		assault.transform.parent = this.transform;
		activeSkills[3] = assault;
		aura.transform.parent = this.transform;
		activeSkills[4] = aura;
		inactive.transform.parent = this.transform;
		inactive.SetActive (false);
		activeSkills[5] = inactive;

//		GameObject blasterSkill = new GameObject ("MaterialSkill");
//		blasterSkill.AddComponent<Skill001> ();
//
//		Debug.Log (equipSkill (blasterSkill));

		GameObject blasterSkill = new GameObject ("BlasterCone");
		blasterSkill.AddComponent<Skill002> ();
		blasterSkill.AddComponent<Skill002> ();
		blasterSkill.AddComponent<Skill002> ();
		//material.GetComponentInChildren<Skill> ().isSpecialOn = true;

		Debug.Log (equipSkill (blasterSkill));

		GameObject controlSkill = new GameObject ("Accelerator");
		controlSkill.AddComponent<Skill011> ();
		equipSkill (controlSkill);

		GameObject assaultSkill = new GameObject ("Missile");
		assaultSkill.AddComponent<Skill031> ();
		equipSkill (assaultSkill);



		//blasterSkill.transform.parent = material.transform.parent;

//		GameObject blasterSkill2 = Instantiate(new GameObject ("MaterialSkill"));;
//		blasterSkill.AddComponent<Skill001> ();
		//blasterSkill.transform.parent = material.transform.parent;

//		equipSkill ((GameObject)Instantiate(blasterSkill2)); 



		Debug.Log (activeSkills [0].GetComponentInChildren<Skill>().skillName);
		//activeSkills [0].AddComponent<Skill001> ();

		//skills.Add (new Skill001 ().init ());
		//		Debug.Log (skills [0].skillName); 
	}
}

﻿using UnityEngine;
using System.Collections;

public class Reflect : MonoBehaviour {
	public int mirrorRate = 0;
	private Transform originalObject;
	public float totalSectorSize;
	public float age;


	void Start()
	{
		originalObject = GetComponent<Rigidbody> ().transform;
		Destroy (gameObject, age);
		
		totalSectorSize = GameObject.Find ("GameController").GetComponentInChildren<BoxColSetSectorSize> ().getTotalSectorSize (); //expensive call
	}
	void Update()
	{
		  

		//remove glitched objects
//		if (mirrorRate >= 5) {
//			Destroy (gameObject);
//		}
		
		//port object into other side of screen (horizontal)
		if (Mathf.Abs (GetComponent<Rigidbody> ().position.x) >= totalSectorSize/1.2) 
		{
			//mirrorRate+=1;
			GetComponent<Rigidbody>().position =  Vector3.Reflect(originalObject.position, Vector3.right);
			originalObject =GetComponent<Rigidbody>().transform;
		}
		//port object into other side of screen (vertical)
		if (Mathf.Abs (GetComponent<Rigidbody> ().position.z) >= totalSectorSize/1.2) 
		{
			//mirrorRate+=1;
			GetComponent<Rigidbody>().position =  Vector3.Reflect(originalObject.position, Vector3.forward);
			originalObject =GetComponent<Rigidbody>().transform;
		}
		
		//code to reflect off sides
		//		if (Mathf.Abs (GetComponent<Rigidbody> ().position.x) >= 10)        
		//		{
		//			mirrorRate+=1;
		//			if(GetComponent<Rigidbody> ().position.x >=5){
		//				GetComponent<Rigidbody>().position =  originalObject.position- (Vector3.right* .1f);
		//			}
		//			if(GetComponent<Rigidbody> ().position.x <=5){
		//				GetComponent<Rigidbody>().position =  originalObject.position- (Vector3.left* .1f);
		//			}
		//			GetComponent<Rigidbody>().velocity =  Vector3.Reflect(originalObject.GetComponent<Rigidbody>().velocity, Vector3.right);
		//			originalObject =GetComponent<Rigidbody>().transform;
		//		}
		

	}
}

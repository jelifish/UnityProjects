﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//=== Skill Functions Class ===============================

public class Skillf : MonoBehaviour{
	public static Skillf f = null;
	public static float globalForce = 500;
	public static float lowForce = globalForce * 0.2f;
	public static float medForce = globalForce * 0.5f;
	public static float highForce = globalForce * 1.0f;
	public static float superForce = globalForce * 2.0f;
	void Awake ()
	{
		f = this;
	}
	public void AddForce (GameObject obj, float force = 250){
		obj.GetComponent<Rigidbody>().AddForce((obj.transform.right * force));
	}

	public void ExplosiveForce (List<GameObject> objs,Vector3 pos,float force = 250,float radius = 0)
	{
		foreach(GameObject obj in objs){
			if(obj !=null){
				obj.GetComponent<Rigidbody>().AddExplosionForce(force, pos, radius);
			}
		}
	}
	public void ExplosiveForceRandom50 (List<GameObject> objs,Vector3 pos,float force = 250,float radius = 0)
	{
		foreach(GameObject obj in objs){
			if(obj !=null){
				obj.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(force*.5f, force), pos, radius);
			}
		}
	}
	public void ExplosiveForce (GameObject obj,Vector3 pos,float force = 250,float radius = 0)
	{
			if(obj !=null){
				obj.GetComponent<Rigidbody>().AddExplosionForce(force, pos, radius);
			}

	}
	public void Freeze (List<GameObject> objs){
		foreach(GameObject obj in objs){
			if(obj !=null){
				obj.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
			}

		}
	}




	public void ForceTowardsDirection(List<GameObject> objs,Vector3 from, Vector3 towards,float force = 250){
		Vector3 towardsVector = towards - from;

		foreach(GameObject obj in objs){
			if(obj !=null){

				Vector3 bulletV = from - obj.transform.position;
				//Vector3 targetVector = (towardsVector - obj.transform.position).normalized;
				Vector3 targetVector = (towardsVector - bulletV).normalized;
				obj.GetComponent<Rigidbody>().AddForce(targetVector * force * (1 / Time.timeScale));
			}
		}
	}

	public void ForceTowardsDirection(GameObject obj,Vector3 from, Vector3 towards,float force = 250){
		Vector3 towardsVector = towards - from;

			if(obj !=null){
				
				Vector3 bulletV = from - obj.transform.position;
				//Vector3 targetVector = (towardsVector - obj.transform.position).normalized;
				Vector3 targetVector = (towardsVector - bulletV).normalized;
				obj.GetComponent<Rigidbody>().AddForce(targetVector * force * (1 / Time.timeScale));
			}

	}




	public void ForceTowardsPoint (List<GameObject> objs,Vector3 towards,float force = 250)
	{
		foreach(GameObject obj in objs){
			if(obj !=null){
				Vector3 targetVector = (towards - obj.transform.position).normalized;
				obj.GetComponent<Rigidbody>().AddForce(targetVector * force * (1 / Time.timeScale));
			}
		}
	}
	public void ForceTowardsPoint (GameObject obj,Vector3 towards,float force = 250)
	{
			if(obj !=null){
				Vector3 targetVector = (towards - obj.transform.position).normalized;
				obj.GetComponent<Rigidbody>().AddForce(targetVector * force * (1 / Time.timeScale));
			}

	}
	
}
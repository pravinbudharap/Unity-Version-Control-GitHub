using UnityEngine;
using System.Collections;

public class Done_WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
//	public Transform shotSpawn2, shotSpawn3, shotSpawn4;
//	public float fireRate;
//	public float delay;
	[HideInInspector]
	public bool enemybulletbool= true, canshoot = true;


//	void Start ()
//	{
//		if (enemybulletbool) {
//			InvokeRepeating ("Fire", delay, fireRate);
//		}
//	}
//
//	void Fire ()
//	{
//		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
//		Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
//		Instantiate(shot, shotSpawn3.position, shotSpawn3.rotation);
//		Instantiate(shot, shotSpawn4.position, shotSpawn4.rotation);
//		GetComponent<AudioSource>().Play();
//	}

	public void Update ()
	{
		if(enemybulletbool == true)
		{
			if (canshoot == true) {
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource> ().Play ();
				canshoot = false;
				StartCoroutine(Reload());
			}
		}
	}
	IEnumerator Reload()
	{
		yield return new WaitForSeconds(1.0f);
		canshoot = true;
	}
}

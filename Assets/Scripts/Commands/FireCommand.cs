using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCommand : Command{

	private GameObject bullet;
	private Rigidbody bulletRigidBody;
	private float BULLET_FORCE = 1000;
	private float distance;
	private Vector3 actorPosition, direction, shootVector;
	public static Vector3 targetPosition;

	public void execute(GameObject actor){
		actorPosition = actor.transform.position;
		shootVector = targetPosition - actorPosition;
		shootVector.Normalize ();
		createBullet ();
		bulletRigidBody.AddForce (shootVector * BULLET_FORCE );
		Debug.DrawLine(targetPosition, actorPosition, Color.green, 2, false);
	}

	private void createBullet(){
		bullet = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		bullet.gameObject.transform.localScale = new Vector3 (0.5f,0.5f,0.5f);
		bullet.gameObject.transform.position = actorPosition + Vector3.up;
		bulletRigidBody = bullet.AddComponent<Rigidbody> ();
		bulletRigidBody.mass = 0.5f;
		RegistryCommandPattern.CUBEMONOBEHAVIOUR.StartCoroutine (destroyBullet(bullet));
	}


	IEnumerator destroyBullet(GameObject bullet){
		yield return new WaitForSeconds(2);    //Wait one frame
		Object.Destroy(bullet);
	}
}

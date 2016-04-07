using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float lifeTime;

	// Use this for initializati
	void Start () {
		Destroy (gameObject, lifeTime);
	}

     

}
   
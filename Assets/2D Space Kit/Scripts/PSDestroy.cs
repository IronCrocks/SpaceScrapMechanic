﻿using UnityEngine;

public class PSDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, GetComponent<ParticleSystem>().duration);
	}
}

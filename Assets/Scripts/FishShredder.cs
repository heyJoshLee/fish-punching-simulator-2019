﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishShredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll) {
        Destroy(coll.gameObject);
    }
}

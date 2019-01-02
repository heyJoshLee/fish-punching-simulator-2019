using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    public void WasHit() {
        Destroy(this.gameObject, 1f);
    }
}

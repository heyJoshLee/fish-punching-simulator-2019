using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Glove : MonoBehaviour {
    Rigidbody rb;

    [SerializeField]
    float punchForce;

    bool wasPunchingPreviousFrame = false;

    bool isPunching = false;
    bool isReturning = false;

    Vector3 startingPosition;

    [SerializeField]
    GameObject scoreText;

    public int score = 0;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        startingPosition = transform.position;
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetAxis("Fire1") > 0 && !isPunching) {
            Punch();
            wasPunchingPreviousFrame = true;
        }

        if (transform.position.z <= 0f && isReturning) {
            rb.velocity = Vector3.zero;
            isReturning = false;
            isPunching = false;
        }

        if (transform.position.z < 0) {
            transform.position = new Vector3(transform.position.x, transform.position.y, startingPosition.z);
        }

        print(isReturning);

        wasPunchingPreviousFrame = false;
	}

    void Punch() {
        isPunching = true;
        rb.AddForce(Vector3.forward * punchForce);
        transform.position = new Vector3(transform.position.x, transform.position.y, startingPosition.z);
    }

    void OnTriggerEnter(Collider coll) {
        isReturning = true;
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.back * punchForce);
    }

    void OnCollisionEnter(Collision coll) {
        if (isPunching && !isReturning) {
            coll.gameObject.GetComponent<Fish>().WasHit();
            GetComponent<AudioSource>().Play();
            score++;
            scoreText.GetComponent<TextMeshProUGUI>().text = "Fish punched: " + score.ToString();
        }
    }
}

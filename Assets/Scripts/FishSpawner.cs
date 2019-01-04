using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] fishPrefabs;

    [SerializeField]
    float minLaunchPower;

    [SerializeField]
    float maxLanuchPower;

    [SerializeField]
    bool isLeftSpawner = true;

    [SerializeField]
    float maxSpeed;

    [SerializeField]
    float minSpeed;

	// Use this for initialization
	void Start () {
        StartCoroutine("KeepLaunchingFish");
	}

    IEnumerator KeepLaunchingFish() {
        while(true) {
            if (GameManager.instance.isPlayingAWave)
                LaunchFish();
            yield return new WaitForSeconds(1f);
        }
    }

    void LaunchFish() {
        float halfHeightOfSpawner = transform.localScale.y / 2;
        float randomSpawnPositionY = Random.Range(-halfHeightOfSpawner, halfHeightOfSpawner);
        // random position on y axis
        Vector3 spawnPosition = new Vector3(transform.position.x, randomSpawnPositionY, transform.position.z);
        GameObject prefabToSpawn = fishPrefabs[Random.Range(0, fishPrefabs.Length)];

        GameObject newFish = (GameObject)Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        newFish.transform.localRotation = transform.rotation;
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        
        Rigidbody rb = newFish.GetComponent<Rigidbody>();

        rb.AddRelativeForce(Vector3.right * randomSpeed );

        //if (isLeftSpawner) {
        //    rb.AddForce(Vector3.right * randomSpeed);
        //} else {
        //    rb.AddForce(Vector3.left * randomSpeed);
            // Flip fish to correct direction
            //newFish.transform.rotation = new Quaternion(180f, 0, 180, 0);
        //}
        // newFish.GetComponent<Rigidbody>().AddForce(Vector3.up * launchPower);
    }
}

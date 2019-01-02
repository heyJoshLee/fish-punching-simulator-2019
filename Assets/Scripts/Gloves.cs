using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gloves : MonoBehaviour {
    [SerializeField]
    float distanceFromCamera;
    
	// Update is called once per frame
	void Update () {
        GloveMovement();
	}

    void GloveMovement() {

        //Set bounds to keep glove in camera view
        Vector2 yBounds = new Vector2(-Camera.main.orthographicSize, Camera.main.orthographicSize);
        float cameraHeight = (Camera.main.orthographicSize * 2);
        float halfCameraWidth = cameraHeight * Camera.main.aspect / 2;
        Vector2 xBounds = new Vector2(-halfCameraWidth, halfCameraWidth);

        // Move to mouse position
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera));
        // keep in play area
        float clampX = Mathf.Clamp(transform.position.x, xBounds.x, xBounds.y);
        float clampY = Mathf.Clamp(transform.position.y, yBounds.x, yBounds.y);
        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }

}

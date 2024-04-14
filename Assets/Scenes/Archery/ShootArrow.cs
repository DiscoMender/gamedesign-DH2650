using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{

    [SerializeField] private GameObject playerModel;
    [SerializeField] private GameObject aimingIndicator;

    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;
    [SerializeField] private float rotationSpeed;
    

    private Vector3 rotationAxis = new(0, 0, 1); // Defines the rotation axis (z-axis due to 2D)

    private bool RotateClockwise = false;

    // Start is called before the first frame update
    void Start()
    {
        // Make sure the angles are within the 0-360 range
        minAngle %= 360;
        if (minAngle < 0) minAngle += 360;
        maxAngle %= 360;
        if (maxAngle < 0) maxAngle += 360;
                
    }

    // Update is called once per frame
    void Update()
    {
        RotateIndicator(GetRotationAngle());


        if (Input.GetMouseButton(0))
        {

        }
    }

    private void RotateIndicator(float degrees) {
        
        Vector3 playerPos = playerModel.transform.position; // Get the player's position

        aimingIndicator.transform.RotateAround(playerPos, rotationAxis, degrees); // Rotate the aimingIndicator around the player

        CheckRotationDirection();
    }

    private void CheckRotationDirection() {
        float currentAngle = aimingIndicator.transform.rotation.eulerAngles.z % 360;
        if (currentAngle < 0) currentAngle += 360;

        if ((maxAngle > minAngle) && (currentAngle < minAngle) ^ (currentAngle > maxAngle)) { // XOR if max > min
            RotateClockwise = !RotateClockwise;
        }
        else if (currentAngle < minAngle && currentAngle > maxAngle) {
            RotateClockwise = !RotateClockwise;
        }
    
    }

    private float GetRotationAngle() {
        if (RotateClockwise) {
            return -rotationSpeed * Time.deltaTime;
        }
        return rotationSpeed * Time.deltaTime;
    }
}

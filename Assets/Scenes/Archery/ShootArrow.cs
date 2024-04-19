using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{

    [SerializeField] private GameObject playerModel;
    [SerializeField] private GameObject aimingIndicator;
    [SerializeField] private GameObject arrowPrefab;

    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;
    [SerializeField] private float rotationSpeed;

    
    [SerializeField] private float shootCooldown;
    private float shootCooldownTimer;

    [SerializeField] private float arrowSpeed;

    private List<GameObject> arrows = new();

    private List<GameObject> targets = new();
    

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

        // shootCooldownTimer = shootCooldown;

        // Add all the targets to the list
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Goal");
        foreach (GameObject target in targetObjects) {
            targets.Add(target);
        }
                
    }

    // Update is called once per frame
    void Update()
    {
        RotateIndicator(GetRotationAngle());

        MoveArrows();

        if (shootCooldownTimer > 0) {
            shootCooldownTimer -= Time.deltaTime;
        }

        if (shootCooldownTimer <= 0) {
            shootCooldownTimer = 0;
            SetArrowColor(Color.green);
        }
        else {
            SetArrowColor(Color.red);
        }

        if (Input.GetMouseButton(0))
        {
            Clicked();
        }
    }

    private void Clicked() {
        if (shootCooldownTimer <= 0) {
            // Shoot();
            shootCooldownTimer = shootCooldown;
            Shoot();
        }
    }

    private void Shoot() {
        GameObject arrow = Instantiate(arrowPrefab, playerModel.transform.position, aimingIndicator.transform.rotation);
        arrows.Add(arrow);
    }

    private void MoveArrows() {
        if (arrows.Count == 0) return;

        List<GameObject> arrowCopies = new(arrows); // Create a copy of the list to avoid concurrent modification
        
        foreach (GameObject arrow in arrowCopies) {
            arrow.transform.position += arrowSpeed * Time.deltaTime * arrow.transform.right;
            
            // Check if the arrow hits the target
            List<GameObject> targetCopies = new(targets); // Create a copy of the list to avoid concurrent modification

            foreach (GameObject target in targetCopies) {
                if (arrow.GetComponent<Collider2D>().IsTouching(target.GetComponent<Collider2D>())) {
                    arrows.Remove(arrow);
                    Destroy(arrow);
                    targets.Remove(target);
                    Destroy(target);
                    break;
                }
            }

            // Destroy the arrow if it goes too far off screen
            if (arrow.transform.position.x > 20) {
                Destroy(arrow);
                arrows.Remove(arrow);
                break;
            }
        }
    }

    private void SetArrowColor(Color color) {
        aimingIndicator.GetComponent<SpriteRenderer>().color = color;
    }

    private void RotateIndicator(float degrees) {
        
        Vector3 playerPos = playerModel.transform.position; // Get the player's position

        aimingIndicator.transform.RotateAround(playerPos, rotationAxis, degrees); // Rotate the aimingIndicator around the player

        CheckRotationDirection();
    }

    private void CheckRotationDirection() {
        float currentAngle = aimingIndicator.transform.rotation.eulerAngles.z % 360;
        if (currentAngle < 0) currentAngle += 360;

        if ((maxAngle > minAngle) && ((currentAngle < minAngle) ^ (currentAngle > maxAngle))) { // XOR if max > min
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

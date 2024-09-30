using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2Controller : MonoBehaviour
{
    public float smooth = 2f;
    private Vector3 newPosition;
    private Vector3 newScale;
    private float roomWidth = 4.75f;
    private float roomHeight = 4.75f;
    public float squashFactor = 0.5f;
    void Start()
    {
        newPosition = transform.position;
    }

    void Update()
    {
        // Get mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward , Vector3.zero);
        if (plane.Raycast(ray, out float distance))
        {
            newPosition = ray.GetPoint(distance);
        }

        // Clamp ball inside room
        newPosition.x = Mathf.Clamp(newPosition.x, -roomWidth, roomWidth);
        newPosition.z = Mathf.Clamp(newPosition.z, -roomWidth, roomWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, 0.2f, roomHeight);

        // Move ball towards mouse position
        transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);

        bool touchingFloor = Math.Abs(transform.position.y) < 0.5f;
        bool touchingCeiling = Math.Abs(transform.position.y - roomHeight) < 0.5f;
        bool touchingWall = Math.Abs(transform.position.x) > roomWidth - 0.5f || Math.Abs(transform.position.x) < -roomWidth + 0.5f;

        // Squash ball when touching wall, floor, or ceiling
        if (touchingFloor || touchingCeiling) {
            newScale = new Vector3(1, squashFactor, 1);
        } else if (touchingWall) {
            newScale = new Vector3(squashFactor, 1, 1);
        } else {
            newScale = new Vector3(1, 1, 1);
        }

        // Smoothly scale ball
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, smooth * Time.deltaTime);

        // Return to main menu when user left-clicks
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

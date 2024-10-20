using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    public GameObject gunImage;
    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the object to the mouse
        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        // Calculate the angle between the object's forward direction and the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the object, facing the mouse
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        if(mousePosition.x < transform.position.x)
        {
            gunImage.transform.localScale = new Vector3(1, -1, 1);
        }
        if (mousePosition.x > transform.position.x)
        {
            gunImage.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}

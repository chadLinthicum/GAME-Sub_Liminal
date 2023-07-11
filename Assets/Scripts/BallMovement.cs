using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speedX = 1f; // The speed at which to move the object
    public float speedY = 1f; // The speed at which to move the object
    public string direction = "upRight";

    void Update() {
         //Locks z-axis
        Vector3 newPos = transform.position;
        newPos.z = 2;
        transform.position = newPos;

        // Get the current position of the object
        Vector3 pos = transform.position;

        // Increase the x and y position by 1 each frame
        pos.x += speedX * Time.deltaTime;
        pos.y += speedY * Time.deltaTime;

        // Set the object's new position
        transform.position = pos;
}

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Wall-R") && direction == "upRight")
    {
        speedX = -speedX;
        direction = "upLeft";
    }
    if (collision.gameObject.CompareTag("Wall-T") && direction == "upRight")
    {
        speedY = -speedY;
        direction = "downRight";
    }

    if (collision.gameObject.CompareTag("Wall-R") && direction == "downRight")
    {
        speedX = -speedX;
        direction = "downLeft";
    }
    if (collision.gameObject.CompareTag("Wall-B") && direction == "downRight")
    {
        speedY = -speedY;
        direction = "upRight";
    }

    if (collision.gameObject.CompareTag("Wall-L") && direction == "upLeft")
    {
        speedX = -speedX;
        direction = "upRight";
    }
    if (collision.gameObject.CompareTag("Wall-T") && direction == "upLeft")
    {
        speedY = -speedY;
        direction = "downLeft";
    }

    if (collision.gameObject.CompareTag("Wall-L") && direction == "downLeft")
    {
        speedX = -speedX;
        direction = "downRight";
    }
    if (collision.gameObject.CompareTag("Wall-B") && direction == "downLeft")
    {
        speedY = -speedY;
        direction = "upLeft";
    }

}
}

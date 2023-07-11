using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speedX = .5f; // The speed at which to move the object
    public float speedY = .5f; // The speed at which to move the object
    public string direction = "upRight";
    

    void Update() {

        Debug.Log(Mathf.RoundToInt(Time.time));
    
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

        int timer = Mathf.RoundToInt(Time.time);

    float scaleValue = 0f;
    float speedValue = 0f;
    switch (timer)
    {
        case 7:
            scaleValue = 0.15f;
            speedValue = 1f;
            break;
        case 14:
            scaleValue = 0.2f;
            speedValue = 1.5f;
            break;
        case 21:
            scaleValue = 0.25f;
            speedValue = 2f;
            break;
        case 28:
            scaleValue = 0.3f;
            speedValue = 2.5f;
            break;
            case 35:
            scaleValue = 0.35f;
            speedValue = 3f;
            break;
            case 42:
            scaleValue = 0.4f;
            speedValue = 3.5f;
            break;
            case 49:
            scaleValue = 0.45f;
            speedValue = 4f;
            break;
        default:
            return;
    }

    Transform objectTransform = transform;
    objectTransform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);

    speedX = speedValue * Mathf.Sign(speedX);
    speedY = speedValue * Mathf.Sign(speedY);
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

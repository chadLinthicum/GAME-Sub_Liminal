using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    private float elapsedTime = 0f;

    public float speedX = .5f; // The speed at which to move the object
    public float speedY = .5f; // The speed at which to move the object
    public string direction = "upRight";

    public AudioSource audioSource;
    public AudioClip bubbleGrow;

    public float scaleValue = 0f;
    public float speedValue = 0f;


    void Update()
    {
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

        int timer = Mathf.RoundToInt(Time.timeSinceLevelLoad);


        switch (timer)
        {
            case 7:
                scaleValue = 0.15f;
                speedValue = 1f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 14:
                scaleValue = 0.2f;
                speedValue = 1.1f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 21:
                scaleValue = 0.25f;
                speedValue = 1.2f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 28:
                scaleValue = 0.3f;
                speedValue = 1.2f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 35:
                scaleValue = 0.35f;
                speedValue = 1.4f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 42:
                scaleValue = 0.4f;
                speedValue = 1.5f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 49:
                scaleValue = 0.45f;
                speedValue = 1.6f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 56:
                scaleValue = 0.5f;
                speedValue = 1.7f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 63:
                scaleValue = 0.55f;
                speedValue = 1.8f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 70:
                scaleValue = 0.6f;
                speedValue = 1.9f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 77:
                scaleValue = 0.65f;
                speedValue = 2f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 84:
                scaleValue = 0.7f;
                speedValue = 2f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 91:
                scaleValue = 0.75f;
                speedValue = 2f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 98:
                scaleValue = 0.8f;
                speedValue = 2f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 105:
                scaleValue = 0.85f;
                speedValue = 2f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 112:
                scaleValue = 0.9f;
                speedValue = 2f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 119:
                scaleValue = 0.95f;
                speedValue = 2f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            case 126:
                scaleValue = 1f;
                speedValue = 2f;
                audioSource.clip = bubbleGrow;
                audioSource.Play();
                break;
            default:
                return;
        }

        Transform objectTransform = transform;
        objectTransform.localScale = new Vector3(scaleValue, scaleValue, 0.01f);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 180f;
    public bool canMove = true;

    public AudioSource audioSource;

    public AudioClip gameOver;
    public AudioClip backgroundMusic;

    public Text uiScoreTime;

    public bool scoreChanged = false;

    private void Start()
    {
        uiScoreTime.enabled = false;
    }

    void Update()
    {
        if (canMove)
        {
            //Locks z-axis
            Vector3 newPos = transform.position;
            newPos.z = 2;
            transform.position = newPos;

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;

            // Rotate the player object on its Y-axis when moving left or right
            if (horizontalInput < 0f)
            {
                RotatePlayer(270f);
            }
            else if (horizontalInput > 0f)
            {
                RotatePlayer(90f);
            }
        }
    }

    // Rotate the player object towards the specified Y-axis rotation
    void RotatePlayer(float targetRotationY)
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, targetRotationY, 0f);
            playerObject.transform.rotation = Quaternion.RotateTowards(playerObject.transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioSource.clip = gameOver;
            audioSource.Play();
            canMove = false;

            if (scoreChanged == false)
            {
                uiScoreTime.enabled = true;
                uiScoreTime.text = "You Stayed For " + Mathf.RoundToInt(Time.time) + " Liminal Seconds.";
                scoreChanged = true;
            }
        }
    }
}
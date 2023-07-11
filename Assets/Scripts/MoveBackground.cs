using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private Transform bgTransform;
    private float timeElapsed;

    void Start()
    {
        // Find the game object with the tag "Background-1"
        GameObject bgObject = GameObject.FindGameObjectWithTag("Background-1");
        if (bgObject != null)
        {
            bgTransform = bgObject.transform;
        }
    }

    void Update()
    {
        // Move the game object forward for the first 5 seconds
        if (timeElapsed < 5f && bgTransform != null)
        {
            bgTransform.Translate(Vector3.up * Time.deltaTime * .25f);
        }
        // Move the game object backward for the next 5 seconds
        else if (timeElapsed < 10f && bgTransform != null)
        {
            bgTransform.Translate(Vector3.down * Time.deltaTime * .25f);
        }
        else
        {
            timeElapsed = 0f;
        }
        timeElapsed += Time.deltaTime;
    }
}
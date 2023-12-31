using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField]private float speed = 30f;

    private float leftBound = -6f;

    private PlayerController playerControllerScript;

    private void Start()
    {

        playerControllerScript = FindObjectOfType<PlayerController>();

    }

    void Update()
    {

        if (!playerControllerScript.isGameOver)
        {

            transform.Translate(Vector3.left * speed * Time.deltaTime);

        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacles"))
        {
            Destroy(gameObject);
        }

    }
}

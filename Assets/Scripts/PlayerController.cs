using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;

    private float force = 8f;

    private bool isOnTheGround;

    public bool isGameOver;

    private void Awake()
    {

        playerRigidbody = GetComponent<Rigidbody>();

        isOnTheGround = true;
        isGameOver = false;

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !isGameOver)
        {

            playerRigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
            isOnTheGround = false;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }

        if (collision.gameObject.CompareTag("Obstacles"))
        {

            Debug.Log("GAME OVER!");
            isGameOver = true;
        }

    }

}

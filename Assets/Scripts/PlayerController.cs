using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;

    private float force = 8f;

    private bool isOnTheGround;

    private void Awake()
    {

        playerRigidbody = GetComponent<Rigidbody>();

        isOnTheGround = true;

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {

            playerRigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
            isOnTheGround = false;

        }

    }

    private void OnCollisionEnter(Collision coliision)
    {

        if (coliision.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }

    }

}

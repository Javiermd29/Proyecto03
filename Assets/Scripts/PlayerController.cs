using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private const string OBSTACLE_TAG = "Obstacles";
    private const string GROUND_TAG = "Ground";

    private const string JUMP_TRIG = "Jump_trig";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE_INT = "DeathType_int";

    private Rigidbody playerRigidbody;

    private float force = 8f;

    private bool isOnTheGround;
    public bool isGameOver;

    private Animator playerAnimator;
    private Animator playerDeath;

    [SerializeField] private ParticleSystem deathParticleSystem;
    [SerializeField] private ParticleSystem runningParticleSystem;

    private void Awake()
    {

        playerRigidbody = GetComponent<Rigidbody>();

        playerAnimator = GetComponent<Animator>();

        playerDeath = GetComponent<Animator>();

        isOnTheGround = true;
        isGameOver = false;

        if (isOnTheGround && !isGameOver)
        {

            runningParticleSystem.Play();

        }

    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !isGameOver)
        {

            
            Jump();

        }


    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isOnTheGround = true;
        }

        if (collision.gameObject.CompareTag(OBSTACLE_TAG))
        {

            Death();

        }

    }

    private void Jump()
    {

        playerRigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
        isOnTheGround = false;

        //Animación de salto
        playerAnimator.SetTrigger(JUMP_TRIG);

        runningParticleSystem.Stop();

    }

    private void Death()
    {

        int randomDeath = Random.Range(1, 3);

        playerDeath.SetBool(DEATH_B, true);
        playerDeath.SetInteger(DEATH_TYPE_INT, randomDeath);

        Debug.Log("GAME OVER!");
        isGameOver = true;

        Debug.Log(randomDeath);

        //Sistema de particulas
        deathParticleSystem.Play();
        runningParticleSystem.Stop();


    }

}

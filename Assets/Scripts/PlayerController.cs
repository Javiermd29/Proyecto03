using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //CONSTANTES
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

    private AudioSource playerAudioSource;
    [SerializeField]private AudioClip jumpClip;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioSource cameraAudioSource;

    private void Awake()
    {

        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerDeath = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();

        isOnTheGround = true;
        isGameOver = false;

    }


    private void Update()
    {

        //PERMITE SOLO SALTAR CUANDO HA TOCADO EL SUELO
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !isGameOver)
        {
            Jump();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {

        //SE REPRODUCEN LAS PARTICULAS DE TIERRA CUANDO ESTÁ TOCNANDO EL SUELO
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isOnTheGround = true;
            runningParticleSystem.Play();
        }

        //LLAMA A LA FUNCIÓN DE LA ANIMACIÓN DE MUERTE CUANDO EL PLAYER TOCA UN OBSTACULO
        if (collision.gameObject.CompareTag(OBSTACLE_TAG))
        {

            Death();

        }

    }

    //FUNCIÓN QUE DEFINE LA FUERZA DEL SALTO, QUE PAREN LAS PARTICULAS DE TIERRA
    private void Jump()
    {

        playerRigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
        isOnTheGround = false;

        //Animación de salto
        playerAnimator.SetTrigger(JUMP_TRIG);

        runningParticleSystem.Stop();

        playerAudioSource.PlayOneShot(jumpClip, 1);

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

        playerAudioSource.PlayOneShot(deathClip, 1);
        cameraAudioSource.volume = 0.05f;


    }

}

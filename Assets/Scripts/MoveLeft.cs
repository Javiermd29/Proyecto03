using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField]private float speed = 30f;

    void Update()
    {

        transform.Translate(Vector3.left * speed * Time.deltaTime);

    }
}

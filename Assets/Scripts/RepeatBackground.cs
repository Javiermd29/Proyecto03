using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    private float repeatWidth;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    private void Update()
    {

        if (transform.position.x < startPos.x - repeatWidth)
        {

            transform.position = startPos;

        }
        
    }

}

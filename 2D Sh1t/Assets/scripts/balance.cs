using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balance : MonoBehaviour
{
    public float targetRotation;
    public float force;

    public Rigidbody2D rb2D;

    void Start()
    {
     rb2D = gameObject.GetComponent<Rigidbody2D>();
        
    }


    void Update()
    {
        
        rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation, targetRotation, force* Time.deltaTime));

    }
}

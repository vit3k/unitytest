using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MaxSpeed = 2;
    public float Acceleration = 0.5f;
    public float Friction = 0.1f;
    Rigidbody2D rigidbody;
    Vector2 inputVector = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
        inputVector = inputVector.normalized;
        if (inputVector != Vector2.zero) 
        {
            velocity = Vector2.MoveTowards(velocity, inputVector * MaxSpeed, Acceleration * Time.deltaTime);
        }
        else
        {
            velocity = Vector2.MoveTowards(velocity, Vector2.zero, Friction * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
       
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }
}

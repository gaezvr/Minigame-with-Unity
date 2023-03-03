using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMvmt : MonoBehaviour
{
    public float WalkingSpeed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded;
    public Transform playerTransform;



    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        Debug.DrawRay(transform.position, Vector3.down * 5f, Color.red); //5f fuerza de gravedad
        if (Physics2D.Raycast(transform.position, Vector3.down, 5f))
        {
            if (playerTransform.position.x < -2.3 || playerTransform.position.x > 2.3)
            {
                if (playerTransform.position.y <= -1) { Grounded = true; }
            
            }
        }
        else { Grounded = false; }

        if(Input.GetKeyDown(KeyCode.Space)&& Grounded) 
        {
            Jump(); 
        }


   

    }
    private void Jump ()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * WalkingSpeed, Rigidbody2D.velocity.y);
    }


}

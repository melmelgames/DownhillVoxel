using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Rigidbody rb;
    //Vector3 velocity;
    //float xValue;
    float horizontalInput;
    //bool isJumping = false;
    public float speed;
    //public float xBound;
    //public float jumpForce;
 
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //velocity = Vector3.zero;
    }

    void Update()
    {
        // Get input
        /* // move
        horizontalInput = Input.GetAxisRaw("Horizontal");
        velocity.x = horizontalInput * speed;
        xValue = Mathf.Clamp(transform.position.x, -xBound, +xBound); */
        // jump
        /* if(!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        } */
        Move();
    }

    void FixedUpdate()
    {

/*         Move();
        
        if(isJumping)
        {
            Jump();
        } */
    }

    void Move()
    {
        /* rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        transform.position = new Vector3(xValue, transform.position.y, transform.position.z); */
        // move
        horizontalInput = Input.GetAxisRaw("Horizontal");
        //velocity.x = horizontalInput * speed;
        //xValue = Mathf.Clamp(transform.position.x, -xBound, +xBound);
        transform.Translate(Vector3.left * speed * horizontalInput * Time.deltaTime);
    }

    void Jump()
    {
        //rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
       // isJumping = false;
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "obstacle")
        {
            GameManager.instance.GameOver();
        }    
    }

}

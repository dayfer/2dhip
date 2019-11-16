using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb2D;
    private float thrust = 22.0f;
    private Vector3 vectorUp;
    private bool midAir = false;
    private float horizontalLevel;
    SpriteRenderer spriteRenderer;
    float distToGround;

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        vectorUp = new Vector3(0.0f, 1.0f, 0.0f);
        horizontalLevel = rb2D.position.y;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        print("Spawning Player");
        distToGround = GetComponent<SpriteRenderer>().bounds.extents.y;
        rb2D.freezeRotation = true;
    }

    public bool isGrounded()
    {
        //Objects which are considered ground must be labled "Ground" in the UI
        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D r = Physics2D.Raycast(transform.position, -Vector2.up, distToGround, mask);

        return (r.collider != null);
    }
    // Update is called once per frame
    void Update()
    {
        if(isGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                bool d = isGrounded();
                if (d) print("true"); else print("false");

 //               print("Mid Air true");
                rb2D.AddForce(vectorUp * thrust);
                midAir = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                spriteRenderer.flipX = false;
                rb2D.velocity = new Vector3(2, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                spriteRenderer.flipX = true;
                //rb2D.AddForce(vectorLeft * 10);
                rb2D.velocity = new Vector3(-2, 0, 0);
            }
        } //Else case for stuff in the air. E.g flying







    }
    private void FixedUpdate()
    {

    }
}

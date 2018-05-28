using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Animator anim;
    private SpriteRenderer mySpriteRenderer;
    public float jumpHeight;
    public bool flipX;
    public float speed = 1.5f;
    public bool inAir;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator> ();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update ()
    {
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (!inAir && (Input.GetKey (KeyCode.Space)))
        {
            inAir = true;
            anim.SetInteger("Movement", 3);
            rb.AddForce(new Vector2(rb.velocity.x, jumpHeight));
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            
            anim.SetInteger("Movement", 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            mySpriteRenderer.flipX = false;
            anim.SetInteger("Movement", 1);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            
            anim.SetInteger("Movement", 0);


        }
        if (Input.GetKey(KeyCode.A))
        {
            mySpriteRenderer.flipX = true;
            anim.SetInteger("Movement", 1);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {

            anim.SetInteger("Movement", 0);

        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetInteger("Movement", 2);
            transform.position += Vector3.right * speed * 2 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetInteger("Movement", 2);
            transform.position += Vector3.left * speed * 2 * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("Movement", 1);
            }
            else { anim.SetInteger("Movement", 0); }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        inAir = false;
    }
}

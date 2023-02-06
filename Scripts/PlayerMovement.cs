using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;

    private void Awake()
    {
        //Rigidbody ve Animator icin objeden referanslari alir.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        body.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }


        //animator parametrelerini set edeceğiz
        if (horizontalInput != 0)
        {
            anim.SetBool("Run", horizontalInput != 0);
        }
        else
        {
            anim.SetBool("Run", verticalInput != 0);

        }

    }

}

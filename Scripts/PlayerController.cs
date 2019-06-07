using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool isGrounded;
    public float moveSpeed;
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, 100, 0), ForceMode.Impulse);
            isGrounded = false;
            Debug.Log("space");
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
        }
    }

    void FixedUpdate()
    {


        //Ler o comando
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        //definindo a Câmera
        var camera = Camera.main;

        //os vetores frontais e da direita
        var forward = camera.transform.forward;
        var right = camera.transform.right;

        //projeta os vetores frontais e da direita no plano (y=0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        //A direção no mundo onde estamos indo
        var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;

        //aplicação do movimento
        transform.Translate(desiredMoveDirection * moveSpeed * Time.deltaTime);



    }
}


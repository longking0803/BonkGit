using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    //Vector2 current_move;
    Rigidbody2D body;

    public float run_speed = 10f;
    public float jump_speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        //current_move = transform.position;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            body.velocity = new Vector2(body.velocity.x, jump_speed);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            body.velocity = new Vector2(run_speed, body.velocity.y);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            body.velocity = new Vector2(-run_speed, body.velocity.y);
        }


        //update all change
        //transform.position = current_move;
    }
}

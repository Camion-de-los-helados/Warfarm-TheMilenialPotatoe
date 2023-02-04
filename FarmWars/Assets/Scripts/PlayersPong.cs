using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersPong : MonoBehaviour
{

    public float speed = 3;
    public Rigidbody2D rb;
    private float move;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(rb.velocity.x, move*speed);
    }
}

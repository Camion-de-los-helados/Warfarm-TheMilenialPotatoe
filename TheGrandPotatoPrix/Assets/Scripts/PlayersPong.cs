using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersPong : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rb2;

    private float move;
    private float move2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Vertical2");
        move2 = Input.GetAxisRaw("Vertical");
        rb.velocity =
            new Vector2(rb.velocity.x, move * Const.PONG_PLAYER_SPEED);
        rb2.velocity =
            new Vector2(rb2.velocity.x, move2 * Const.PONG_PLAYER_SPEED);
    }
}

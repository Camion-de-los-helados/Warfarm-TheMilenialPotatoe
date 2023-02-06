using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BallPong : MonoBehaviour
{
    public Rigidbody2D rb;

    private float _time;

    // Start is called before the first frame update
    void Start()
    {
        Launch();
    }

    // Update is called once per frame
    public void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity =
            new Vector2(Const.PONG_BALL_START_SPEED * x,
                Const.PONG_BALL_START_SPEED * y);
    }

    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= 1f)
        {
            rb.velocity *= 1 + Const.PONG_BALL_INCREMENT_SPEED;
            _time=0;
        }
    }
}

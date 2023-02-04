using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPong : MonoBehaviour
{


    public float speed = 7;
    public Rigidbody2D rb;

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

        rb.velocity = new Vector2(speed * x, speed * y);

    }
}

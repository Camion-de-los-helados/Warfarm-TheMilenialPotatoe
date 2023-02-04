using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroPatata : MonoBehaviour
{
    Collider2D collider;
    private bool isAlive = true;

    // Vector2 direction = new Vector2(0.5f,1);
    // float magnitude = 14f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        // if (gameObject.transform.position)
        
        
        collider = GetComponent<Collider2D>();
        //rb.AddRelativeForce(direction * magnitude, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // Add force
        
        //transform.position = transform.position + new Vector3(5f * Time.deltaTime, 0, 0);
    }

    public void addForce(Vector2 direction, float magnitude) 
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(direction * magnitude, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Colision");
        Destroy(gameObject);
    }

    public void Muerto() 
    {
        Debug.Log("Muerto");
    }
}

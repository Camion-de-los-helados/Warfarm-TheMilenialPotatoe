using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroPatata : MonoBehaviour
{
    Collider2D collider;
    private bool isAlive = true;
    Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;
    public Sprite destructionSprite;
    float timeToDie = 0.3f;
    void Start()
    {
        // if (gameObject.transform.position)
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        //rb.AddRelativeForce(direction * magnitude, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // Add force
        
        //transform.position = transform.position + new Vector3(5f * Time.deltaTime, 0, 0);
        if(!isAlive)
        {
            muerete();
        }
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

    public void muerto()
    {
        isAlive = false;
    }
    public void muerete() 
    {
        spriteRenderer.sprite = destructionSprite;
        Debug.Log(timeToDie);
        timeToDie -= Time.deltaTime;
        if(timeToDie <= 0)
        {
            Debug.Log("Destruidaaa");
            Destroy(gameObject);
        }
       
        
    }
}

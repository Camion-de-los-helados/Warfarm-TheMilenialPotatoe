using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalPong : MonoBehaviour
{
    UnityEvent LoseEvent;  
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            LoseEvent.Invoke();
        }


    }





}

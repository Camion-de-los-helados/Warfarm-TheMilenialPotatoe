using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionLine : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] GoalPongManager goalPongManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            goalPongManager.EndGame(id);
        }
    }
}

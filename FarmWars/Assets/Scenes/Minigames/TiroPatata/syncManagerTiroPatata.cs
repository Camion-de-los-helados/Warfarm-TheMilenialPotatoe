using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syncManagerTiroPatata : MonoBehaviour
{
    float score1;
    float score2;

    bool finishPlayer1 = false;
    bool finishPlayer2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(finishPlayer1 && finishPlayer2)
        {
            if(score1 > score2)
            {
                //GameManager.m_gameManager._lastWinner(player1);
            }
            else if (score2 < score1)
            {
                //GameManager.m_gameManager._lastWinner(player1);
            }
            else 
            {
                // random
            }
        }
    }

    public void finishPlayer(float score, int playerID)
    {
        if (playerID == 1)
        {
            score1 = score;
            finishPlayer1 = true;
        }
        else {
            score2 = score;
            finishPlayer2 = true;
        }
    }
}

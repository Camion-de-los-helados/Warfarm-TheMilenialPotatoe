using System.Collections;
using System.Collections.Generic;
using System.Security;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Canvas canvas;

    [SerializeField]
    TextMeshProUGUI tmp;

    [SerializeField]
    Image image;

    [SerializeField]
    Sprite p1Sprite;

    [SerializeField]
    Sprite p2Sprite;

    // Update is called once per frame
    public void FinishGame(int playerID)
    {
        tmp.text = "PLAYER " + (playerID + 1) + " WINS";
        if (playerID.Equals(0))
        {
            image.sprite = p1Sprite;
        }
        else
        {
            image.sprite = p2Sprite;
        }
        canvas.GetComponent<Canvas>().enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Threading;
using Unity.Mathematics;

public class ContClicks : MonoBehaviour
{
    
    int MaxClick = Const.MAX_CLICKS_POTATOPEELER;
    public int  ActualClick1 = 0;
    public int  ActualClick2 = 0;
    //[SerializeField] private Button btn;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] public Win win;
    [SerializeField] public List<Image> images;

    public Sprite p1;
    public Sprite p2;
    public Sprite p3;
    public Sprite p4;
    public Sprite p5;
    public Sprite p6;
    public Sprite ButtonView;
    public Sprite ButtonViewPressed;
    public Image imageChange;
    public Image imageChange2;
    public Button ButtonImage;

    [SerializeField] GameObject backgroundImage1;
    [SerializeField] GameObject backgroundImage2;
    [SerializeField] GameObject image1;
    [SerializeField] GameObject image2;
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;

    private bool finished = false;
    // Start is called before the first frame update


    [SerializeField] public GameObject canvasInitial;

    Array allKeyCodes;
    bool StartGame = false;
    void Awake()
    {
        allKeyCodes = System.Enum.GetValues(typeof(KeyCode));
    }



    private void Start() 
    {
        Debug.Log("START CONT CLICK");
        canvasInitial.SetActive(true);
        backgroundImage1.SetActive(false);
        backgroundImage2.SetActive(false);
        image1.SetActive(false);
        image2.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        //btn.OnKeyDown.AddListener(()=>Counter());
        //ButtonImage.image.sprite = ButtonView;
    }

    // Update is called once per frame
    

    public void ButtonPressed()
    {
        ButtonImage.image.sprite = ButtonViewPressed;
    }
    public void Counter1()
    {
        //ButtonImage.image.sprite = ButtonView;
        ActualClick1++;
        //text.text = ActualClick.ToString();
        float range= MaxClick/5;

        if (ActualClick1 == range)
        {
            imageChange.sprite = p2;
        }else if(ActualClick1 == range*2)
        {
            imageChange.sprite = p3;
        }
        else if(ActualClick1 == range*3)
        {
            imageChange.sprite = p4;
        }
        else if(ActualClick1 == range*4)
        {
            imageChange.sprite = p5;
        }
        else if(ActualClick1 == MaxClick)
        {
            imageChange.sprite = p6;
            EndGame(0);
        }
        
    }




    public void Counter2()
    {
        //ButtonImage.image.sprite = ButtonView;
        ActualClick2++;
        //text.text = ActualClick.ToString();
        float range = MaxClick / 5;

        if (ActualClick2 == range)
        {
            imageChange2.sprite = p2;
        }
        else if (ActualClick2 == range * 2)
        {
            imageChange2.sprite = p3;
        }
        else if (ActualClick2 == range * 3)
        {
            imageChange2.sprite = p4;
        }
        else if (ActualClick2 == range * 4)
        {
            imageChange2.sprite = p5;
        }
        else if (ActualClick2 == MaxClick)
        {
            imageChange2.sprite = p6;
            EndGame(1);
        }

    }
    

    

    public void EndGame(int winner)
    {
        foreach (Image i in images)
        {
            i.enabled = false;
        }
        win.FinishGame(winner);
        finished = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("UPDATE");
        if (StartGame == false)
        {
            Debug.Log("UPDATE START GAME FALSE");
            foreach (KeyCode tempKey in allKeyCodes)
            {
                //Send event to key down
                if (Input.GetKeyDown(tempKey))
                {
                    Debug.Log("UPDATE START GAME FALSE PRESS KEY");
                    canvasInitial.SetActive(false);
                    StartGame = true;
                    backgroundImage1.SetActive(true);
                    backgroundImage2.SetActive(true);
                    image1.SetActive(true);
                    image2.SetActive(true);
                    button1.SetActive(true);
                    button2.SetActive(true);
                }
            }
            
        }
        else
        {
            if (!finished)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    //   ButtonImage.image.sprite = ButtonViewPressed;
                    Counter1();
                }
                else if (Input.GetKeyDown(KeyCode.P))
                {
                    //    ButtonImage.image.sprite = ButtonViewPressed;
                    Counter2();
                }
            }
        }
    }

}
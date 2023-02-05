using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    private bool finished = false;
    // Start is called before the first frame update



    private void Start() 
    {
        
        
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

    void Update()
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
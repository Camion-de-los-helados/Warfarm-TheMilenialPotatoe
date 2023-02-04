using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContClicks : MonoBehaviour, IPointerDownHandler
{
    UnityEvent WinEvent; 
    int MaxClick = Const.MAX_CLICKS_POTATOPEELER;
    public int  ActualClick = 0;
    [SerializeField] private Button btn;
    [SerializeField] private TextMeshProUGUI text;
    public Sprite p1;
    public Sprite p2;
    public Sprite p3;
    public Sprite p4;
    public Sprite p5;
    public Sprite p6;
    public Sprite ButtonView;
    public Sprite ButtonViewPressed;
    public Image imageChange;
    public Button ButtonImage;
    // Start is called before the first frame update

    private void Start() 
    {
        btn.onClick.AddListener(()=>Counter());
        ButtonImage.image.sprite = ButtonView;
    }

    // Update is called once per frame
    

    public void ButtonPressed()
    {
        ButtonImage.image.sprite = ButtonViewPressed;
    }
    public void Counter()
    {
        ButtonImage.image.sprite = ButtonView;
        ActualClick++;
        //text.text = ActualClick.ToString();
        float range= MaxClick/5;

        if (ActualClick == range)
        {
            imageChange.sprite = p2;
        }else if(ActualClick == range*2)
        {
            imageChange.sprite = p3;
        }
        else if(ActualClick == range*3)
        {
            imageChange.sprite = p4;
        }
        else if(ActualClick == range*4)
        {
            imageChange.sprite = p5;
        }
        else if(ActualClick == MaxClick)
        {
            imageChange.sprite = p6;
            WinEvent.Invoke();
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonImage.image.sprite = ButtonViewPressed;
    }
    
}

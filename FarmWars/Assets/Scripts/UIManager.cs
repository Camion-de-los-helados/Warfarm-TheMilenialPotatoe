using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager Instance;

    [SerializeField] private View View;
    [SerializeField] private View[] Views;

    private View CurrentView;

    private readonly Stack<View> History = new Stack<View>();

    public static T GetView<T>() where T : View 
    {
        for(int i = 0; i <  Instance.Views.Length; i++) 
        {
            if (Instance.Views[i] is T tView) 
            { 
                return tView;
            }
        }
        return null;
    }

    public static void Show<T>(bool remember = true) where T : View
    {
        for (int i = 0; i < Instance.Views.Length; i++)
        {
            if (Instance.Views[i] is T)
            {
                if (Instance.CurrentView != null)
                {
                    if (remember)
                    {
                        Instance.History.Push(Instance.CurrentView);
                    }
                    Instance.CurrentView.Hide();
                }

                Instance.Views[i].Show();
                Instance.CurrentView = Instance.Views[i];
            }
        }
    }


    public static void Show(View view, bool remember = true)
    {
        if (Instance.CurrentView != null)
        {
            if (remember)
            {
                Instance.History.Push(Instance.CurrentView);
            }
            Instance.CurrentView.Hide();
        }

        if (view != null) 
        {
            view.Show();
            Instance.CurrentView = view;
        }
    }

    public static void ShowLast() 
    {
        if (Instance.History.Count != 0)
        {
            Show(Instance.History.Pop(), false);   
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < Views.Length; i++) 
        {
            Views[i].Initialize();
            Views[i].Hide();
        }

        if (View != null)
        {
            Show(View, true);
        }
    }
}

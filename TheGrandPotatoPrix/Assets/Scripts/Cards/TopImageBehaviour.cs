using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopImageBehaviour : MonoBehaviour
{
    public Card CardInTop;
    public GameObject GOCardInTop;
    private Image image;

    private Vector3 LastPosition;
    private Quaternion LastRotation;
    private Vector2 LastSizeDelta;
    private Transform LastParent;


    private void Awake()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }


    internal void ShowCard()
    {
        if (GOCardInTop != null)
        {
            Destroy(GOCardInTop);
        }
        GOCardInTop = Instantiate(CardInTop.gameObject);

        CopyObjectTransform(GOCardInTop.gameObject);

        GOCardInTop.transform.position = transform.position;
        GOCardInTop.transform.rotation = transform.rotation;

        GOCardInTop.GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().rect.width,
            GetComponent<RectTransform>().rect.height);

        GOCardInTop.transform.SetParent(transform.parent);

        GOCardInTop.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        GOCardInTop.name = "CardInTop " + CardInTop.name;

        GOCardInTop.GetComponent<Card>().IsInTop = true;

    }
    private void CopyObjectTransform(GameObject go)
    {
        LastPosition = go.transform.position;
        LastParent = go.transform.parent;
        LastRotation = go.transform.rotation;
        LastSizeDelta = go.GetComponent<RectTransform>().sizeDelta;
    }


    internal void HideCard()
    {
        if (GOCardInTop != null)
            Destroy(GOCardInTop);
    }
}

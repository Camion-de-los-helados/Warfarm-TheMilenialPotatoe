using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LeftTopImage : MonoBehaviour
{
    public GameObject GOCardInTopLeft;
    public Card CardInTopLeft;
    private Image image;
    private GameObject BackButton;

    private Vector3 LastPosition;
    private Quaternion LastRotation;
    private Vector2 LastSizeDelta;
    private Transform LastParent;

    public GameObject DownPanel;

    public GameObject TopImage { get; private set; }

    private void Awake()
    {
        image = GetComponent<Image>();
        image.enabled = false;
        BackButton = GetComponentInChildren<Button>().gameObject;
        BackButton.SetActive(false);
    }

    public void ShowCard()
    {
        DownPanel = GameObject.Find("DownPanel");
        DownPanel.SetActive(false);

        if (GOCardInTopLeft != null)
        {
            Destroy(GOCardInTopLeft);
        }

        GOCardInTopLeft = Instantiate(CardInTopLeft.gameObject);

        CopyObjectTransform(GOCardInTopLeft.gameObject);

        GOCardInTopLeft.transform.position = transform.position;
        GOCardInTopLeft.transform.rotation = transform.rotation;

        GOCardInTopLeft.GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().rect.width,
            GetComponent<RectTransform>().rect.height);

        GOCardInTopLeft.transform.SetParent(transform.parent);

        GOCardInTopLeft.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        GOCardInTopLeft.name = "CardInTop " + CardInTopLeft.name;
        GameObject.Find("TopImage").GetComponent<TopImageBehaviour>().HideCard();

        //deactivate cards
        if (GOCardInTopLeft.TryGetComponent<EventTrigger>(out var potatoEvents))
        {
            potatoEvents.enabled = false;
        }

        BackButton.SetActive(true);

        GridManager.Instance.ActivateTiles();

    }

    private void CopyObjectTransform(GameObject go)
    {
        LastPosition = go.transform.position;
        LastParent = go.transform.parent;
        LastRotation = go.transform.rotation;
        LastSizeDelta = go.GetComponent<RectTransform>().sizeDelta;
    }

    public void HideCard()
    {
        if (GOCardInTopLeft != null)
        {
            Destroy(GOCardInTopLeft);
        }
        DownPanel.SetActive(true);

        CardManager.Instance.DeactivateCards();

        GridManager.Instance.DeactivateTiles();
        BackButton.SetActive(false);
    }


}

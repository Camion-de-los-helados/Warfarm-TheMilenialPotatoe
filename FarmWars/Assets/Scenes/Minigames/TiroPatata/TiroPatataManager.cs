using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class TiroPatataManager : MonoBehaviour
{
    public GameObject potatoPrefab;
    public float speed;
    public int playerID;
    private SpriteRenderer sprite;
    private bool shoot = false;
    private Vector2 shootPos;


    float posX;
    float posY;

    [SerializeField] public float timeBetweenPotatos = 0.3f;
    float deltaTime;


    // GUI
    [SerializeField] public float MaxTimer = 50;
    private float timer = 50;
    private TextMeshProUGUI scoreTexto;
    private TextMeshProUGUI timerTexto;
    [SerializeField] private int puntuacionP0 = 0;
    [SerializeField] private int puntuacionP1 = 0;
    //[SerializeField] private TMP_Text scoreTexto;
    [SerializeField] private string texto;
    //int puntuacion = 0;


    [SerializeField] int currentPlayer = 0;
    [SerializeField] public Win win;

    [SerializeField] GameObject SpriteP0;
    [SerializeField] GameObject SpriteP1;
    [SerializeField] GameObject CanvasInitial;
    [SerializeField] TMP_Text textPressKey;

    Array allKeyCodes;
    private bool StartGame = false;
    private bool EndGame = false;
    void Awake()
    {
        allKeyCodes = System.Enum.GetValues(typeof(KeyCode));
    }

    // Start is called before the first frame update
    void Start()
    {
        deltaTime = timeBetweenPotatos;
        timer = MaxTimer;
        scoreTexto = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        timerTexto = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        scoreTexto.text = "";
        timerTexto.text = "";
        SpriteP0.SetActive(false);
        SpriteP1.SetActive(false);
        CanvasInitial.SetActive(true);
       


    }

    // Update is called once per frame
    void Update()
    {

        if (StartGame == false && EndGame == false)
        {
            foreach (KeyCode tempKey in allKeyCodes)
            {
                //Send event to key down
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartGame = true;
                    if (currentPlayer == 0)
                    {
                        CanvasInitial.SetActive(false);
                        SpriteP0.SetActive(true);
                    }
                    else if (currentPlayer == 1)
                    {
                        CanvasInitial.SetActive(false);
                        SpriteP1.SetActive(true);
                    }
                }
            }
        }
        else if (StartGame == true && EndGame == false)
        {
            timer -= Time.deltaTime;
            timerTexto.text = "Time: " +((int)timer).ToString();
            if (timer <= 0)
            {
                if (currentPlayer == 0)
                {
                    SpriteP0.SetActive(false);
                    SpriteP1.SetActive(false);
                    scoreTexto.text = "";
                    timerTexto.text = "";
                    currentPlayer = 1;
                    timer = MaxTimer;
                    StartGame = false;
                    CanvasInitial.SetActive(true);
                    textPressKey.text = "PLAYER 2 PRESS SPACE...";
                }
                else if (currentPlayer == 1)
                {
                    SpriteP0.SetActive(false);
                    SpriteP1.SetActive(false);
                    EndGame = true;
                    endGame();
                }
            }
            deltaTime -= Time.deltaTime;
            if (deltaTime <= 0)
            {
                createPotato();
                deltaTime = timeBetweenPotatos;
            }

            if(timer > 0){
                shootDetection();
            }
        }
    }

    private void createPotato()
    {
        float randomX = Random.Range(-10, 10);
        GameObject obj = (GameObject)Instantiate(potatoPrefab, new Vector3(randomX ,-5, 0), Quaternion.identity);
        if ( randomX >= 0)
        {
            obj.GetComponent<tiroPatata>().addForce(new Vector2(-0.5f,1), 14f);
        }
        else 
        {
            obj.GetComponent<tiroPatata>().addForce(new Vector2(0.5f,1), 14f);
        }
    }
    private void shootDetection()
    {
        shoot = Input.GetMouseButtonDown(0);

        if (shoot)
        {
            shootPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(shootPos, shootPos, 0f);

            if (hit)
            {
                tiroPatata tiroP = hit.collider.gameObject.GetComponent<tiroPatata>();
                tiroP.muerto();
                //Muerto(hit.collider.gameObject);
                if (currentPlayer == 0)
                {
                    puntuacionP0++;
                    scoreTexto.text = ("Score: " + puntuacionP0.ToString());
                }
                else if (currentPlayer == 1)
                {
                    puntuacionP1++;
                    scoreTexto.text = ("Score: " + puntuacionP1.ToString());
                }
                Debug.Log("Potato Hit");
            }
        }
    }
    private void endGame()
    {
        scoreTexto.text = "";
        timerTexto.text = "";
        if (puntuacionP0 > puntuacionP1)
        {
            win.FinishGame(0);
            Debug.Log("Player 0 WIN!!!!!!!");
        }
        else if (puntuacionP1 > puntuacionP0)
        {
            win.FinishGame(1);
            Debug.Log("Player 1 WIN!!!!!!!");
        }
        else 
        {
            int random = Random.Range(0, 1);
            win.FinishGame(random);
            Debug.Log("EMPATE!!!!!!!!!!!!!!!!!!!!");
        }
        //Enviar la puntuación al GameManager
    }
    public void Muerto(GameObject gameObject) 
    {
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TiroPatataManager : MonoBehaviour
{
    public GameObject potatoPrefab;
    public GameObject m_syncManager;
    private syncManagerTiroPatata m_syncM;
    public float speed;
    public int playerID;
    private SpriteRenderer sprite;
    private bool shoot = false;
    private Vector2 shootPos;


    float posX;
    float posY;

    float timeBetweenPotatos = 1.0f;
    float deltaTime;
    

    // GUI

    float timer = 50;
    private TextMeshProUGUI scoreTexto;
    private TextMeshProUGUI timerTexto;
    [SerializeField] private int puntuacion = 0;
    //[SerializeField] private TMP_Text scoreTexto;
    [SerializeField] private string texto;
    //int puntuacion = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        m_syncM = m_syncManager.GetComponent<syncManagerTiroPatata>();
        deltaTime = timeBetweenPotatos;
        
        scoreTexto = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        timerTexto = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        timerTexto.text =  ((int) timer).ToString();
        scoreTexto.text = "Score: " + puntuacion.ToString();
        Debug.Log(scoreTexto);
        // for (int i = 0; i < numPotato; i++)
        // {
        //     //float randomX = Random.Range(0,2)*2-1;
        //     //float randomY = Random.Range(0,2)*2-1; //-1 or 1

        //     float randomX = Random.Range(-10, 10);
        //     GameObject obj = (GameObject)Instantiate(potatoPrefab, new Vector3(randomX ,-5, 0), Quaternion.identity);
        //     if ( randomX >= 0)
        //     {
        //         obj.GetComponent<tiroPatata>().addForce(new Vector2(0.5f,1), 14f);
        //     }
        //     else 
        //     {
        //         obj.GetComponent<tiroPatata>().addForce(new Vector2(-0.5f,1), 14f);
        //     }
            
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerTexto.text = ((int) timer).ToString();
        if(timer <= 0)
        {
            endGame();
        }
        deltaTime -= Time.deltaTime;
        if (deltaTime <= 0)
        {
            createPotato();
            deltaTime = timeBetweenPotatos;
        }
        
        shootDetection();
        
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
                Muerto(hit.collider.gameObject);
                puntuacion++;
                scoreTexto.text = ("Score: " + puntuacion.ToString());
                Debug.Log(puntuacion);
                Debug.Log("Potato Hit");
            }
        }
    }
    private void endGame()
    {
        m_syncM.finishPlayer(puntuacion, playerID);
        //Enviar la puntuación al GameManager
    }
    public void Muerto(GameObject gameObject) 
    {
        Destroy(gameObject);
    }

}

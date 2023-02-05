using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncManager : MonoBehaviour
{
    public SyncManager m_syncManager { get; private set; }
    #region Play Time Properties
    private int currentPlayerID;
    private int lastWinner;
    private bool playTime = false;
    private bool firstCardTurnFinish = false;
    private bool secondCardTurnFinish = false;
    private bool movePotatoTurn = false;
    private bool finishPotatoTurn = false;
    private bool endPotato = false;
    #endregion
    #region Sync
    private Dictionary<CARD_TYPES, int> CardDeck = new Dictionary<CARD_TYPES, int>();
    private Stack<GameObject>[,] traps = new Stack<GameObject>[Const.MAP_SIZE_HORIZONTAL, Const.MAP_SIZE_VERTICAL];
    public Vector2Int currentPotatoPosition;
    #endregion
    #region Methods
    #region PostMiniGame
    public void StartPlayTime()
    {
        playTime = true;
        //WIP: Put the potato in the grid
    }
    public void SetLastWinner(int winner)
    {
        lastWinner = winner;
    }
    public int getFirstPlayer()
    {
        return lastWinner;
    }
    #endregion
    #region First Card Turn
    public void StartFirstCardTurn()
    {
        currentPlayerID = lastWinner;
    }
    public bool HasFirstCardTurnFinish()
    {
        return firstCardTurnFinish;
    }
    public void FinishFirstCardTurn()
    {
        if (currentPlayerID == 0)
        {
            currentPlayerID = 1;
        }
        {
            currentPlayerID = 0;
        }
        firstCardTurnFinish = true;
    }
    #endregion
    #region Second Card Turn
    public bool HasSecondCardTurnFinish()
    {
        return secondCardTurnFinish;
    }
    public void FinishSecondCardTurn()
    {
        if (currentPlayerID == 0)
        {
            currentPlayerID = 1;
        }
        {
            currentPlayerID = 0;
        }
        secondCardTurnFinish = true;
    }
    #endregion
    #region Move Potato Turn
    public bool IsMovePotatoTurn()
    {
        return finishPotatoTurn;
    }
    public void FinishPotatoTurn(Vector2Int newPosition)
    {
        currentPotatoPosition = newPosition;
        finishPotatoTurn = true;
    }
    public bool HasFinishMovingPotato()
    {
        return endPotato;
    }

    #endregion
    #region Traps
    private void CheckTrap()
    {
        GameObject trap;
        if (traps[currentPotatoPosition.x, currentPotatoPosition.y].TryPeek(out trap))
        {
            //WIP Trap Effect
        }
    }
    #endregion
    #region PostPlayTime
    private void ResetPlayTimeVariables()
    {
        playTime = false;
        firstCardTurnFinish = false;
        secondCardTurnFinish = false;
        movePotatoTurn = false;
        finishPotatoTurn = false;
        endPotato = false;
    }
    #endregion
    #endregion
    private void Awake()
    {
        if (m_syncManager != null && m_syncManager != this)
        {
            Destroy(this);
        }
        else
        {
            m_syncManager = this;
        }
    }
    void Start()
    {

    }

    void Update()
    {
        if (playTime)
        {
            if (firstCardTurnFinish && secondCardTurnFinish && !movePotatoTurn)
            {
                currentPlayerID = lastWinner;
                movePotatoTurn = true;
            }
            if (finishPotatoTurn)
            {
                CheckTrap();
                endPotato = true;
                ResetPlayTimeVariables();
                //WIP Load Random MiniGame Scene
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Card[] m_playerCards = new Card[Const.MAX_CARDS_PER_PLAYER];
    private int NumberOfCardsInHand = 0;
    private int ID;
    #region Methods

    void StartGame()
    {
        //m_playerCards.Add();
    }

    public void AddCardToPlayer(Card card)
    {
        m_playerCards[NumberOfCardsInHand] = card;
        NumberOfCardsInHand++;
    }
    public void RemoveCardFromPlayer(int cardPosition)
    {
        m_playerCards[cardPosition] = null;
        NumberOfCardsInHand--;
        ReorderCardsInHand();
    }

    private void ReorderCardsInHand()
    {
        for (int i = 0; i < Const.MAX_CARDS_PER_PLAYER; i++)
        {
            if (!m_playerCards[i])
            {
                for (int j = i + 1; j < Const.MAX_CARDS_PER_PLAYER; j++)
                {
                    if (m_playerCards[j] != null)
                    {
                        m_playerCards[i] = m_playerCards[j];
                        m_playerCards[j] = null;
                        break;
                    }

                }
            }

        }
    }



    public void ChangePlayerID(int ID)
    {
        this.ID = ID;
    }
    #endregion
}

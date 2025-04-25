using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{

    #region Instance variables

    /// <summary>
    /// Player id (usually username)
    /// </summary>
    private string playerId;

    /// <summary>
    /// Array storing cards held by the player
    /// </summary>
    private IPlayerCard[] playerHand;

    /// <summary>
    /// Tracks current state of the player
    /// Legend:
    /// 0 - ok
    /// 1 - afraid
    /// 2 - woken up
    /// 3 - called it a night
    /// </summary>
    private int currentState;

    /// <summary>
    /// Tracks player points
    /// </summary>
    private Dictionary<string, int> playerPoints;

    /// <summary>
    /// Initial state constant
    /// </summary>
    private int initialState = Constants.initialState;

    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHand = new IPlayerCard[Constants.playerHandSize];
        currentState = initialState;
        playerPoints = new Dictionary<string, int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Adds a card to the player's hand
    /// </summary>
    /// <param name="card">Card to add</param>
    public void AddPlayerCard(IPlayerCard card)
    {
        int i = 0;
        while(playerHand[i] != null){
            i++;
        }
        playerHand[i] = card;
    }

    /// <summary>
    /// Adds points of a specified kind to the player
    /// </summary>
    /// <param name="pointType">Kind of point to add</param>
    /// <param name="points">Amount of points to add</param>
    public void AddPlayerPoints(string pointType, int points)
    {
        int storedPoints = playerPoints.GetValueOrDefault(pointType, 0);
        playerPoints[pointType] = storedPoints + points;
    }

    /// <summary>
    /// Returns the current state
    /// </summary>
    /// <returns>int current state</returns>
    public int GetCurrentState()
    {
        return currentState;
    }

    /// <summary>
    /// Returns player hand as an array
    /// </summary>
    /// <returns>IPlayerCard[] player hand array</returns>
    public IPlayerCard[] GetPlayerHand()
    {
        return playerHand;
    }

    /// <summary>
    /// Returns player id
    /// </summary>
    /// <returns>string player id</returns>
    public string GetPlayerID()
    {
        return playerId;
    }

    /// <summary>
    /// Returns player points of a specified type
    /// OR 0 if specified point type does not exist
    /// </summary>
    /// <param name="pointType">Type of point to get</param>
    /// <returns>Amount of points</returns>
    public int GetPlayerPoints(string pointType)
    {
        return playerPoints.GetValueOrDefault(pointType, 0);
    }

    /// <summary>
    /// Increases the state of the player
    /// Legend:
    /// 0 - ok
    /// 1 - afraid
    /// 2 - woken up
    /// 3 - called it a night
    /// </summary>
    public void IncreaseScareFactor()
    {
        currentState += 1;
    }


    /// <summary>
    /// Removes a card at a specified index
    /// and returns in
    /// </summary>
    /// <param name="index">Card index to remove</param>
    /// <returns>Removed card</returns>
    public IPlayerCard RemovePlayerCard(int index)
    {
        IPlayerCard removedCard = playerHand[index];
        playerHand[index] = null;
        return removedCard;
    }

    /// <summary>
    /// Sets current state back to the initial state
    /// </summary>
    public void ResetCurrentState()
    {
        currentState = initialState;
    }

    /// <summary>
    /// Sets the current state to a specified value
    /// </summary>
    /// <param name="state">New current state</param>
    public void SetCurrentState(int state)
    {
        currentState = state;
    }


}

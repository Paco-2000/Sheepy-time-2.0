using UnityEngine;

public interface IPlayer
{
    public string GetPlayerID(); // Returns the ID of the player

    public int GetCurrentState(); // Returns the current state of the player

    public void ResetCurrentState(); // Resets the current state of the player

    public int GetPlayerPoints(string pointType);  // Returns the number of points the player has depending on the point type

    public void AddPlayerPoints(string pointType, int points); // Add points to the player 

    public void IncreaseScareFactor(); // Increases the scare factor of the player

    public void AddPlayerCard(IPlayerCard Card);  // Adds a card to the player's hand

    public IPlayerCard RemovePlayerCard(int index); // Removes a card from the player's hand
    
    public IPlayerCard[] GetPlayerHand(); // Returns the player's hand

    public void SetCurrentState(int state); // Sets the current state of the player
}

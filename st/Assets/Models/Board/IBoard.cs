using System;
using System.Collections.Generic;
using UnityEngine;

public interface IBoard
{
    public IDreamTile[] GetDreamTileArray(); // Returns the array of dream tiles
    
    public int GetEntityPosition(String name); // Returns the position of the entity

    public void IncreaseEntityPosition(String name, int amount); // Increases the position of the entity

    public int GetFenceCrossings(String name); // Returns the number of fence crossings

    public void IncreaseFenceCrossings(String name); // Increases the number of fence crossings

    public void ClearFenceCrossing(String name); // Clears the number of fence crossings of the entity

    public void ClearFenceCrossings(); // Clears the number of fence crossings

    public void ClearEntityPosition(String name); // Clears the position of the entity

    public IDreamTile GetDreamTile(String name); // Returns the DreamTile at the players position on the board

    public void AddDreamTile(IDreamTile dreamTile, int position); // Adds a DreamTile to the board

    public String GetNightmareId(); // Returns the ID of the nightmare

    public Dictionary<String, int> GetEntityPositions(); // Returns the map of entity positions

    public Dictionary<String, int> GetFenceCrossings(); // Returns the map of fence crossings

    public void ClearEntityPositions(); // Clears the entity positions

    public void ClearDreamTiles(); // Clears the DreamTiles

    public void SetDTArray(IDreamTile[] dtArray); // Sets the DreamTile Array

    public void ResetBoard(); // Resets the board

}

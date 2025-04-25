using System;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour, IBoard
{

    #region Serialized Private Fields

    /// <summary>
    /// Array storing positions of all DreamTiles
    /// </summary>
    [SerializeField] private IDreamTile[] board;

    /// <summary>
    /// Database of all entity positions.
    /// </summary>
    [SerializeField] private Dictionary<String, int> entityPositions;

    /// <summary>
    /// Database of all fence crossings by players.
    /// </summary>
    [SerializeField] private Dictionary<String, int> fenceCrossings;

    #endregion

    #region Constants

    private int boardSize;

    private string nightmareId;

    #endregion

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boardSize = Constants.boardSize;
        board = new IDreamTile[boardSize];

        entityPositions = new Dictionary<string, int>();
        fenceCrossings = new Dictionary<string, int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Adds a DreamTile to the board at a given position
    /// </summary>
    /// <param name="dreamTile">DreamTile to be added</param> 
    /// <param name="position">Position to add the DreamTile</param> 
    public void AddDreamTile(IDreamTile dreamTile, int position)
    {
        board[position] = dreamTile;
    }

    /// <summary>
    /// Removes all DreamTiles from the Board
    /// </summary>
    public void ClearDreamTiles()
    {
        board = new IDreamTile[boardSize];
    }

    /// <summary>
    /// Removes an entity from the board
    /// </summary>
    /// <param name="name">Entity's name to rmove</param>
    public void ClearEntityPosition(string name)
    {
        entityPositions.Remove(name);
    }

    /// <summary>
    /// Clears the board of all entities (nightmare + players)
    /// </summary>
    public void ClearEntityPositions()
    {
        entityPositions.Clear();
    }

    /// <summary>
    /// Clears fence crossings for a given name
    /// </summary>
    /// <param name="name">Name to clear fence crossings</param>
    public void ClearFenceCrossing(string name)
    {
        fenceCrossings.Remove(name);
    }

    /// <summary>
    /// Clears the board of all fence crossings
    /// </summary>
    public void ClearFenceCrossings()
    {
        fenceCrossings.Clear();
    }

    /// <summary>
    /// Get a DreamTile at an Entity's position
    /// </summary>
    /// <param name="name">Name of chosen Entity</param>
    /// <returns>IDreamTile or null</returns>
    public IDreamTile GetDreamTile(string name)
    {
        int position = GetEntityPosition(name);
        return board[position];
    }

    /// <summary>
    /// Returns array of all DreamTiles
    /// </summary>
    /// <returns>IDreamTile[]</returns>
    public IDreamTile[] GetDreamTileArray()
    {
        return board;
    }

    /// <summary>
    /// Returns the position of a given entity's name
    /// OR 0 if entity not found
    /// </summary>
    /// <param name="name">Name of chosen Entity</param>
    /// <returns>Position int</returns>
    public int GetEntityPosition(string name)
    {
        if(entityPositions.TryGetValue(name, out int position))
        {
            return position;
        }
        else{
            return 0;
        }
    }

    /// <summary>
    /// Returns dictionary of Entity positions
    /// </summary>
    /// <returns>Dictionnary of entity positions</returns>
    public Dictionary<string, int> GetEntityPositions()
    {
        return entityPositions;
    }

    /// <summary>
    /// Returns the number of a given entity's name
    /// OR 0 if entity not found
    /// </summary>
    /// <param name="name">Name of chosen Entity</param>
    /// <returns>Fence crossings int</returns>
    public int GetFenceCrossings(string name)
    {
        if(fenceCrossings.TryGetValue(name, out int crossings))
        {
            return crossings;
        }
        else{
            return 0;
        }
    }

    /// <summary>
    /// Returns dictionary of Fence Crossings
    /// </summary>
    /// <returns>Dictionnary of fence crossings</returns>
    public Dictionary<string, int> GetFenceCrossings()
    {
        return fenceCrossings;
    }

    /// <summary>
    /// Returns nightmare Id
    /// </summary>
    /// <returns>String nightmare id</returns>
    public string GetNightmareId()
    {
        return nightmareId;
    }

    /// <summary>
    /// Increases position of given entity by given amount
    /// </summary>
    /// <param name="name">Entity to increase position</param>
    /// <param name="amount">Amount to move it</param>
    public void IncreaseEntityPosition(string name, int amount)
    {
        if(entityPositions.TryGetValue(name, out int position))
        {
            entityPositions[name] = position + amount;
        }
        else
        {
             entityPositions[name] = amount;
        }
    }

    /// <summary>
    /// Increases the fence crossing amount of a given entity
    /// </summary>
    /// <param name="name">Entity to increase</param>
    public void IncreaseFenceCrossings(string name)
    {
        if(fenceCrossings.TryGetValue(name, out int crossings))
        {
            fenceCrossings[name] = crossings + 1;
        }
        else
        {
            fenceCrossings[name] = 1;
        }
    }

    /// <summary>
    /// Resets the board, entity positions and fence crossings
    /// </summary>
    public void ResetBoard()
    {
        ClearDreamTiles();
        ClearEntityPositions();
        ClearFenceCrossings();
    }

    /// <summary>
    /// Sets the DreamTile array to a given array
    /// </summary>
    /// <param name="dtArray">New DreamTile array</param>
    public void SetDTArray(IDreamTile[] dtArray)
    {
        board = dtArray;
    }

}

using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class NightmareCard : MonoBehaviour, IDrawCard
{
    #region Instance Variables

    /// <summary>
    /// Ability array
    /// </summary>
    private INightmareAbility[] abilities;

    /// <summary>
    /// Card id
    /// </summary>
    private int id;
    #endregion

    #region Constants
    private static int wokeUpState = Constants.wokeUpState;
    private static int scaredState = Constants.scaredState;
    private static int asleepState = Constants.asleepState;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Activates the ability of the nightmare
    /// card for a given player
    /// </summary>
    /// <param name="player">Player activating the card</param>
    public void ActivateAbilities(IPlayer player)
    {
        foreach (INightmareAbility ability in abilities)
        {
            ability.DoAbility(player);
        }
    }

    /// <summary>
    /// Adds a new ability to the card
    /// </summary>
    /// <param name="newAbility">New ability to be added</param>
    public void AddAbility(INightmareAbility newAbility)
    {
        INightmareAbility[] tempArray = new INightmareAbility[abilities.Length + 1];
        for(int i=0; i < tempArray.Length; i++)
        {
            tempArray[i] = abilities[i];
        }
        tempArray[tempArray.Length] = newAbility;
        abilities = tempArray;
    }

    /// <summary>
    /// Finalizes the nightmare's movement. If the nightmare is off the board
    /// and a given player is awake or scared, they will be woken up
    /// </summary>
    /// <param name="board">Game Board</param>
    /// <param name="player">Player being checked</param>
    public void FinalizeNightmare(IBoard board, IPlayer player) 
    {
        string nightmareId = board.GetNightmareId();

        bool isPlayerScared = player.GetCurrentState() == asleepState;
        bool isPlayerAwake = player.GetCurrentState() == wokeUpState;

        if(board.GetEntityPosition(nightmareId) >= Constants.boardSize && (isPlayerAwake || isPlayerScared)) 
        {
            player.SetCurrentState(wokeUpState);
        }
    }

    /// <summary>
    /// Returns the abilities of the nightmare card
    /// </summary>
    /// <returns>INightmareAbility[] ability array</returns>
    public INightmareAbility[] GetAbilities()
    {
        return abilities;
    }

    /// <summary>
    /// Returns an ability at a specified index
    /// </summary>
    /// <param name="index">Index of chosen ability</param>
    /// <returns>Ability at specified index</returns>
    public INightmareAbility GetAbility(int index)
    {
        return abilities[index];
    }

    /// <summary>
    /// Returns the card's id
    /// </summary>
    /// <returns>int card id</returns>
    public int GetCardID()
    {
        return id;
    }

    /// <summary>
    /// Method used to look at the card by the visitor
    /// </summary>
    /// <param name="visitor">Visitor object</param>
    public void Look(Visitor visitor)
    {
        visitor.Visit(this);
    }

    /// <summary>
    /// Removes a given ability from the card
    /// </summary>
    /// <param name="removedAbility">Ability to be removed</param>
    public void RemoveAbility(INightmareAbility removedAbility)
    {
        INightmareAbility[] tempArray = new INightmareAbility[abilities.Length - 1];
        for(int i = 0; i < tempArray.Length; i++)
        {
            if(abilities[i] != removedAbility)
            {
                tempArray[i] = abilities[i];
            }
        }
        abilities = tempArray;
    }

    /// <summary>
    /// Sets abilities to specified value
    /// </summary>
    /// <param name="newAbilities">New nightmare abilities</param>
    public void SetAbilities(INightmareAbility[] newAbilities)
    {
        abilities = newAbilities;
    }

    /// <summary>
    /// Sets the card's id to a new value
    /// </summary>
    /// <param name="newId">New card's id</param>
    public void SetCardId(int newId)
    {
        id = newId;
    }

}

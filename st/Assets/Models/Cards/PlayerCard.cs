using UnityEngine;

public class PlayerCard : MonoBehaviour, IPlayerCard
{

    #region Instance variables

    /// <summary>
    /// Array of card abilities
    /// </summary>
    [SerializeField] private IPlayerAbility[] abilities;

    /// <summary>
    /// Unique card Id
    /// </summary>
    private int id; 
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
    /// Get amount of abilities for this card
    /// </summary>
    /// <returns>int number of abiliites</returns>
    public int AbilityCount()
    {
        return abilities.Length;
    }

    /// <summary>
    /// Activates the ability of this card for a given player.
    /// Uses a visitor design pattern to handle the card's effect
    /// </summary>
    /// <param name="choice">Index of the card</param>
    /// <param name="player">Player that activated the ability</param>
    /// <param name="visitor">Visitor for the design pattern</param>
    public void ActivateAbility(int choice, IPlayer player, IAbilityVisitor visitor)
    {
        abilities[choice].Accept(visitor);
        abilities[choice].DoAbility(player);
    }

    /// <summary>
    /// Returns the card id
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
    /// Checks if an ability requires additional input
    /// </summary>
    /// <param name="index">Index of ability to check</param>
    /// <returns>boolean</returns>
    public bool RequireAdditionalInput(int index)
    {
        return abilities[index].RequireAdditionalInput();
    }

    /// <summary>
    /// Initializes the abilities of the card
    /// </summary>
    /// <param name="newAbilities">Abilities array</param>
    public void SetAbilities(IPlayerAbility[] newAbilities)
    {
        abilities = newAbilities;
    }

    /// <summary>
    /// Sets the card's id
    /// </summary>
    /// <param name="newId">New card id</param>
    public void SetCardId(int newId)
    {
        id = newId;
    }

}

using UnityEngine;

public interface IPlayerCard: IDrawCard
{
    public void ActivateAbility(int choice, IPlayer player, IAbilityVisitor visitor); // This method is used to activate the ability of the player card.

    public int AbilityCount(); // This method is used to get the number of abilities the player card has.

    public bool RequireAdditionalInput(int index); // This method is used to check if the ability requires additional input.

    public void SetCardId(int newId);

    public void SetAbilities(IPlayerAbility[] newAbilities);
}

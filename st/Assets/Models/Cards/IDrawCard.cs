using UnityEngine;

public interface IDrawCard
{
    public int GetCardID(); // This method is used to get the card id.

    public void Look(Visitor visitor);  // This method is used to look at the card.
}

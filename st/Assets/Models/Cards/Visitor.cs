using UnityEngine;

public interface Visitor
{
    public void Visit(IPlayerCard card);

    public void Visit(NightmareCard card);
}

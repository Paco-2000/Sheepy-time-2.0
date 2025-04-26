using System;
using UnityEngine;

public interface IPlayerAbility
{
    public void Accept(IAbilityVisitor visitor);

    public void DoAbility(IPlayer player);

    public bool RequireAdditionalInput();
}

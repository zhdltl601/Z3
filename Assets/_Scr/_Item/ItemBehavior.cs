using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBehavior : MonoBehaviour
{
    public virtual void Equip()
    {
        gameObject.SetActive(true);
    }
    public virtual void Unequip()
    {
        gameObject.SetActive(false);
    }
}

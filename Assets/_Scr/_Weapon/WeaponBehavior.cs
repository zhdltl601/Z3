using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public abstract class WeaponBehavior : ItemBehavior
{
    public UnityAction OnM1;
    public UnityAction OnM2;
    public UnityAction OnZoom;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<WeaponBehavior> weapons;
    public List<ItemBehavior> items;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapons[0].OnM1?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            weapons[0].OnM2();
        }
    }

}

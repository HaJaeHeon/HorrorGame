using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTyep
{

    Equipment,
    Consumabies,
    Etc

}

[System.Serializable]
public class Item : MonoBehaviour
{

    public ItemTyep itemTyep;
    public string itemName;
    public Sprite itemImage;

    public bool Use()
    {

        return false;

    }

}

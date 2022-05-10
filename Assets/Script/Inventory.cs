using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if(instance!=null)
        {

            Destroy(gameObject);
            return;

        }
        instance = this;
    }
    #endregion

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangItem;

    public List<Item> items = new List<Item>();

    private int slotCnt;
    public int SlotCnt
    { 
        get => slotCnt;
        set{
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    void Start()
    {
        SlotCnt = 8;
    }

    public bool AddItem(Item _item)
    {
        if(items.Count<SlotCnt)
        {
            items.Add(_item);
            if(onChangItem != null)
            onChangItem.Invoke();
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("FieldItem"))
        {
            FieldItems fieldItems = collision.GetComponent<FieldItems>();
            if (AddItem(fieldItems.GetItem()))
                fieldItems.DestroyItem();
        }
    }
}

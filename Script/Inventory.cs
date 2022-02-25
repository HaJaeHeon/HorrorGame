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

    void Update()
    {
        
    }
}

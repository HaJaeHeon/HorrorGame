using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    Inventory inven;

    public GameObject inventoryPanel;
    bool activelnventory = false;

    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
        inven.onChangItem += RedrawSlotUI;
        inventoryPanel.SetActive(activelnventory);
    }

    private void SlotChange(int val)
    {
        for (int i = 0;i<slots.Length; i++)
        {
            if (i < inven.SlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            activelnventory = !activelnventory;
            inventoryPanel.SetActive(activelnventory);
        }
    }

    public void AddSlot()
    {
        inven.SlotCnt++;
    }

    void RedrawSlotUI()
    {
        for(int i = 0; i<slots.Length;i++)
        {
            slots[i].RemoveSlot();
        }
        for(int i=0;i<inven.items.Count;i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }
    }
}

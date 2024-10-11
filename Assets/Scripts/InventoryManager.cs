using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Inventory<IItem> playerInventory;

    private void Start()
    {
        playerInventory = new Inventory<IItem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) playerInventory.AddItem(new Weapon("Sword", 1, 10));
        if (Input.GetKeyDown(KeyCode.W)) playerInventory.AddItem(new HealthPotion("Potion", 1, 10));
        if (Input.GetKeyDown(KeyCode.Space)) playerInventory.Listitems();
        if (Input.GetKeyDown(KeyCode.Alpha1)) playerInventory.UseItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) playerInventory.UseItem(1);
    }

}

using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;
    public GameObject inventoryUI;
    public GameObject inventoryMenu;
    public GameObject statsMenu;
    public GameObject capacityMenu;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    public void ClicInventory() {
        inventoryMenu.SetActive(true);
        statsMenu.SetActive(false);
        capacityMenu.SetActive(false);
    }

    public void ClicStats() {
        inventoryMenu.SetActive(false);
        statsMenu.SetActive(true);
        capacityMenu.SetActive(false);
    }

    public void ClicCapacity() {
        inventoryMenu.SetActive(false);
        statsMenu.SetActive(false);
        capacityMenu.SetActive(true);
    }
    void UpdateUI() {
        Debug.Log("update UI");
        for (int i = 0; i < slots.Length ; i++) {
            if (i < inventory.items.Count) {
                slots[i].AddItem(inventory.items[i]);
            } else {
                slots[i].ClearSlot();
            }
        }
    }
}

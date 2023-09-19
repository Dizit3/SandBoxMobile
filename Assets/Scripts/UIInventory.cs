using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryItem;
    [SerializeField] private PlayerController playerController;

    private void Awake()
    {
        playerController.OnKeyAdded += InventoryInteractionHandler;
    }

    private void InventoryInteractionHandler()
    {
        AddItem();
    }

    public void AddItem()
    {
        var item = Instantiate(inventoryItem);

        item.transform.SetParent(transform, false);
    }

    private void OnDestroy()
    {
        playerController.OnKeyAdded -= InventoryInteractionHandler;

    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvevtoryController : MonoBehaviour
{
    [SerializeField] private RectTransform uiInventory;

    private List<Item> _itemsList = new List<Item>();
    private void OnEnable()
    {
        ItemPicker.Added += AddItem;
    }
    public void AddItem(Item item)
    {
        if (!_itemsList.Contains(item))
        {
            _itemsList.Add(item);
            Redraw(item);
        }
    }
    private void Redraw(Item item)
    {
        var icon = new GameObject(item.name);
        icon.transform.SetParent(uiInventory);
        icon.transform.localScale = Vector3.one;
        icon.AddComponent<RectTransform>().anchoredPosition = Vector3.zero;
        icon.AddComponent<Image>().sprite = item.Icon;
        icon.tag = "Item";
    }
    private void OnDisable()
    {
        ItemPicker.Added -= AddItem;
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite imteImage;
    public ItemTYpe itemType;
    public GameObject itemPrefab;

    public string weaponType;

    public enum ItemTYpe
    {
        Equipment,
        Used,
        Ingredient,
        ETC
    }


}

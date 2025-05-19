using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public enum ItemType { Banana, Strawberry, Blueberry}
    public ItemType itemType;

    public int GetScore()
    {
        switch (itemType)
        {
            case ItemType.Banana: return 10;
            case ItemType.Strawberry: return 5;
            case ItemType.Blueberry: return 15;
            default: return 0;
        }
    }
}

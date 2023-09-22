using UnityEngine;

public class GridPoints : MonoBehaviour
{
    [SerializeField] private UnitPos[] unitPositions;

    public GameObject AddFolower()
    {
        foreach (var pos in unitPositions)
        {
            if (pos.isEmpty == true)
            {
                pos.isEmpty = false;
                return pos.gameObject;
            }
        }
        return null;
    }
}

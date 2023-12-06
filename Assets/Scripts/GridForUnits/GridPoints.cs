using Unity.VisualScripting;
using UnityEngine;

public class GridPoints : MonoBehaviour
{

    public GameObject AddFolower()
    {
        foreach (Transform position in transform)
        {
            if (position.GetComponent<UnitPos>().isEmpty == true)
            {
                position.GetComponent<UnitPos>().isEmpty = false;
                return position.gameObject;
            }
        }
        return null;
    }
}

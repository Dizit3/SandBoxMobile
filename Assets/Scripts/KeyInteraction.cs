using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    [SerializeField] private CellProperties keyID;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.AddKey(keyID.requiredKeyID);

            Destroy(gameObject);
        }
    }
}

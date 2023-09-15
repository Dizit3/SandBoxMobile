using UnityEngine;

public class KeyInteraction : MonoBehaviour
{

    private string keyID = "Red";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.AddKey(keyID);

            Destroy(gameObject);
        }
    }
}

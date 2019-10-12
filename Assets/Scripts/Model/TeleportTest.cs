using UnityEngine;

public class TeleportTest : MonoBehaviour
{
    public Transform TO;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.AddComponent<Rigidbody>();

            other.gameObject.transform.position = TO.position;
            other.gameObject.GetComponent<CharacterController>().enabled = true;
            Destroy(other.GetComponent<Rigidbody>());
        }
    }

}

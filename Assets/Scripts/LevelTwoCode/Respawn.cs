using UnityEngine;

public class Respawn : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        MenuManager.instance.LoadCurrentScene();
    }
}

using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]private string sceneName;

    private void OnCollisionEnter(Collision collision)
    {
            MenuManager.instance.LoadSceneByName(sceneName);
    }
}

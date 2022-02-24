using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayPoint : MonoBehaviour
{
    [SerializeField]private Image waypoint;
    [SerializeField]private GameObject objectiveManager;
    public Transform target;

    private void Start()
    {
        target = GameObject.Find("Objective(Clone)").transform;
    }

    private void Update()
    {
        float minX = waypoint.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        
        float minY = waypoint.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);

        //check if target is behind player
        if (Vector3.Dot((target.position - transform.position),transform.forward) < 0)
        {
            if (pos.x < Screen.width /2 )
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y , minY , maxY);

        waypoint.transform.position = pos;
    }
}

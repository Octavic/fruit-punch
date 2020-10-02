using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var floorCheck = collision.gameObject.GetComponent<FloorCheck>();
        if (floorCheck != null)
        {
            floorCheck.Entity.OnEnterTerrain(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var floorCheck = collision.gameObject.GetComponent<FloorCheck>();
        if (floorCheck != null)
        {
            floorCheck.Entity.OnLeaveTerrain(this);
        }
    }
}

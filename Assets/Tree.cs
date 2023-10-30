using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;
public class Tree : MonoBehaviour
{
    public int health;
    public Tilemap Tilemap;

    public List<TileBase> tiles;
    // Start is called before the first frame update
    void Start()
    {
        if (tiles.Contains(Tilemap.GetTile(Vector3Int.FloorToInt(this.transform.localPosition))))
        {
            Destroy(this);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0)
        {

            Destroy(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Tree : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public TextMesh health_text;

    public Tilemap tilemap;
    public List<TileBase> tiles;
    void Start()
    {
        health_text = GetComponentInChildren<TextMesh>(); // Assuming the Text component is a child of the unit's GameObject		isMoving = false;
        if (tiles.Contains(tilemap.GetTile(Vector3Int.FloorToInt(this.transform.position))))
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        health_text.text = health.ToString() ;

        if (health <= 0)
        {
            Destroy(this);
            gameObject.SetActive(false);
        }
    }
}

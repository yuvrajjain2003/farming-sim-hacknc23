using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile interactedTile;

    [SerializeField] private Tile plantedTile;
    [SerializeField] private Tile growth1Tile;
    [SerializeField] private Tile growth2Tile;
    [SerializeField] private Tile harvestableTile;

    public Player player;

    public Item tomatoSeed;


    TileBase tile;
    void Start()
    {
        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);

            if (tile != null && tile.name == "Interactable_visible")
                interactableMap.SetTile(position, hiddenInteractableTile);
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        tile = interactableMap.GetTile(position);

        if (tile != null)
            if (tile.name == "Interactable" || tile.name == "Summer_Plowed" || tile.name == "planted" || tile.name == "free_102" || tile.name == "free_104" || tile.name == "free_105")
                return true;
        return false;
    }

    public void SetInteracted(Vector3Int position)
    {
        if (tile != null && tile.name == "Interactable")
        {
            interactableMap.SetTile(position, interactedTile);
        }

        if (tile != null && tile.name == "Summer_Plowed")
        {
            interactableMap.SetTile(position, plantedTile);
        }

        if (tile != null && tile.name == "planted")
        {
            interactableMap.SetTile(position, growth1Tile);
        }

        if (tile != null && tile.name == "free_102")
        {
            interactableMap.SetTile(position, growth2Tile);
        }

        if (tile != null && tile.name == "free_104")
        {
            interactableMap.SetTile(position, harvestableTile);
        }

        if (tile != null && tile.name == "free_105")
        {
            interactableMap.SetTile(position, hiddenInteractableTile);
            player.DropItem(tomatoSeed);
            player.DropItem(tomatoSeed);
        }
    }

    public void SimulateGrowth(Vector3Int position)
    {
        return;
    }
}

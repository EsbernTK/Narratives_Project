using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BaseTile : MonoBehaviour{

    /*
    [System.Serializable]
    public enum TileLandscapeType
    {
        GrassLand,
        Forrest,
        
        Mountains,
        Hills,
        Desert,
        Desolate,
    }
    public TileLandscapeType landscapeType;
    public int regionAmount;
    public List<Region> regions = new List<Region>();
    public BaseTile[] neighbourTiles = new BaseTile[8]; //{North,South,West,East,North-West,North-East,South-West,South-East}
    public Vector2Int position;
    GameManagerSimulator GameManager;
    public Country owner = null;
    public void InitializeTile(Vector2Int position)
    {
        this.position = position;
    }
	// Use this for initialization
	void Start () {
        GameManager = GameManagerSimulator.instance;
        neighbourTiles = new BaseTile[8];
        landscapeType = (TileLandscapeType)Random.Range(0, 6);
        StartCoroutine(FindNeighbours());
        ChangeTileColour();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CreateRegions()
    {
        for (int i = 0; i < regionAmount; i++)
        {
            regions.Add(new Region());
        }
    }
    public IEnumerator FindNeighbours()
    {
        yield return new WaitForEndOfFrame();
        if(position.y + 1 < GameManager.WorldSize.y)
        {
            neighbourTiles[0] = GameManager.tiles[position.x][position.y + 1];
            if (position.x - 1 > 0)
            {
                neighbourTiles[4] = GameManager.tiles[position.x - 1][position.y+1];
            }
            if (position.x + 1 < GameManager.WorldSize.x)
            {
                neighbourTiles[5] = GameManager.tiles[position.x + 1][position.y+1];
            }
        }
        if (position.y - 1 > 0)
        {
            neighbourTiles[1] = GameManager.tiles[position.x][position.y - 1];
            if (position.x - 1 > 0)
            {
                neighbourTiles[6] = GameManager.tiles[position.x - 1][position.y - 1];
            }
            if (position.x + 1 < GameManager.WorldSize.x)
            {
                neighbourTiles[7] = GameManager.tiles[position.x + 1][position.y - 1];
            }
        }
        if (position.x - 1 > 0)
        {
            neighbourTiles[2] = GameManager.tiles[position.x-1][position.y];
        }
        if (position.x + 1 < GameManager.WorldSize.x)
        {
            neighbourTiles[3] = GameManager.tiles[position.x + 1][position.y ];
        }
    }
    
    public void ChangeTileColour()
    {
        Renderer renderer = GetComponent<Renderer>();
        switch (landscapeType)
        {
            case TileLandscapeType.GrassLand:
                renderer.material.color = Color.green;
                break;
            case TileLandscapeType.Hills:
                renderer.material.color = new Color(0,0.5f,0,1);
                break;
            case TileLandscapeType.Mountains:
                renderer.material.color = new Color(0.75f, 0.75f, 0.75f, 1);
                break;
            case TileLandscapeType.Desert:
                renderer.material.color = new Color(0.75f, 0.75f, 0, 1);
                break;
            case TileLandscapeType.Desolate:
                renderer.material.color = new Color(0.3f, 0.3f, 0.3f, 1);
                break;
            default:
                renderer.material.color = new Color(1f, 1f, 0.3f, 1);
                break;
        }
    }
    */
}

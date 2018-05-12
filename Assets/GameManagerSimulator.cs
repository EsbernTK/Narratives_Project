using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSimulator : MonoBehaviour {

    public static GameManagerSimulator instance;
    public StoryGenerator storyGenerator;
    public NameGenerator nameGenerator;
    public int countryAmount = 2;
    public int variation = 3;
    [SerializeField]
    public List<Country> countries = new List<Country>();
    int epoch = 0;
    // Use this for initialization

    [SerializeField]
    public List<WorldState> WorldEvents = new List<WorldState>();
    void Start () {
        instance = this;
        storyGenerator = new StoryGenerator();
        nameGenerator = new NameGenerator();
        Peace firstState = new Peace();
        WorldEvents.Add(firstState);
        for (int i = 0; i < countryAmount; i++)
        {
            countries.Add(new Country(firstState));
            countries[i].name = GenerateName();
        }
        countries[1].AllActions.Remove("DeclareWar");
        countries[1].AllActions.Remove("Battle");
        foreach(Country c in countries)
        {
            c.Countries = countries;
        }
	}
	
	// Update is called once per frame
	void Update () {
        epoch++;
        if (epoch % 1 == 0)
        {
            
            foreach (Country c in countries)
            {

                c.DecideOnAction();
            }
            
        }
        if (Input.anyKeyDown)
        {
            foreach(WorldState state in WorldEvents)
            {
                Debug.Log(storyGenerator.GenerateStateStory(state));
            }
        }
	}

    public string GenerateName()
    {
        string output = nameGenerator.GenerateName();
        return output;
    }

    //old code
    /*
    public int countryAmount = 10;
    public int variation = 3;
    public Vector2Int WorldSize = new Vector2Int(100,100);
    [SerializeField]
    public List<List<BaseTile>> tiles = new List<List<BaseTile>>();
    [SerializeField]
    public List<Country> countries = new List<Country>();
    public GameObject tilePrefab;

    void Start () {
        instance = this;
        for (int x = 0; x < WorldSize.x; x++)
        {
            tiles.Add(new List<BaseTile>());
            for (int y = 0; y < WorldSize.y; y++)
            {
                GameObject tempObject = Instantiate(tilePrefab, new Vector3(x, y, 0), tilePrefab.transform.rotation,transform) as GameObject;
                tempObject.name = "Tile (" + x + "," + y + ")";
                BaseTile temp = tempObject.GetComponent<BaseTile>();
                temp.InitializeTile(new Vector2Int(x, y));
                tiles[x].Add(temp);
            }
        }
        for (int i = 0; i < countryAmount + Random.Range(-variation,variation); i++)
        {
            int x = Random.Range(0, WorldSize.x);
            int y = Random.Range(0, WorldSize.y);
            int k = 0;
            while(tiles[x][y].owner != null && k < 1000)
            {
                k++;
                x = Random.Range(0, WorldSize.x);
                y = Random.Range(0, WorldSize.y);
                if (tiles[x][y].owner == null)
                    break;
            }
            countries.Add(new Country());
            tiles[x][y].owner = countries[i];
        }
	}
     */

}

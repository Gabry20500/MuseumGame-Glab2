using UnityEngine;
using System.Collections.Generic;

public class Tile
{
    public bool isEmpty = true;
    public bool isVase = false;
    public GameObject tile;
    public Vector3 position = new Vector3( 0f, 0f, 0f );
    public List<Tile> adiacent = new List<Tile>();
}
public class ExcavatorManager : MonoBehaviour
{
    public static ExcavatorManager instance = null;

    [SerializeField] GameObject mediumTile;
    [SerializeField] GameObject scorpioTile;
    [SerializeField] GameObject vaseTile;

    public int vaseNum = 5;
    public int vaseFounded = 0;
    public int lives = 3;

    [SerializeField] GameObject[] lifeHearth = new GameObject[2];

    public List<List<Tile>> tileMap = new List<List<Tile>>();

    private Touch touch;

  

    private void Awake()
    {
        if(instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
        }
        InitializeTileMap();
        InitializeGridPos();
        SpawnTile();
        SetAdiacent();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if(hit.transform.CompareTag("Tile"))
            {
                for (int row = 0; row <= 5; row++)
                {
                    for (int column = 0; column <= 4; column++)
                    {
                        if(hit.transform.gameObject == tileMap[row][column].tile)
                        {
                            tileMap[row][column].tile.GetComponent<TileScript>().SetExcavatedTile();
                            foreach(Tile tile in tileMap[row][column].adiacent)
                            {
                                tile.tile.GetComponent<TileScript>().SetFrontTile();
                            }
                        }
                    }                   
                }          
            }
        }
    }

    private void InitializeTileMap()
    {
        for (int i = 0; i < 6; i++)
        {
            tileMap.Add(new List<Tile>());
        }
        foreach (List<Tile> row in tileMap)
        {
            for (int j = 0; j < 6; j++)
            {
                row.Add(new Tile());
            }
        }
    }
    private void InitializeGridPos()
    {
        float xPos = -6;
        float yPos = 6;

        for (int row = 0; row <= 5; row++)
        {
            for (int column = 0; column <= 4; column++)
            {
                tileMap[row][column].position = new Vector3(xPos, yPos, 0f);
                Debug.Log(tileMap[row][column].position.ToString());
                xPos += 2.95f;
            }
            xPos = -6;
            yPos += -2.89f;
        }
        xPos = -6;
        yPos = -6;
    }
    private void SpawnTile()
    {
        SpawnVaseTile();
        SpawnMediumTile();
        SpawnScorpioTile();
    }
    private void SpawnScorpioTile()
    {
        for (int row = 0; row <= 5; row++)
        {
            for (int column = 0; column <= 4; column++)
            {
                if (tileMap[row][column].isEmpty == true)
                {
                    tileMap[row][column].isEmpty = false;
                    tileMap[row][column].tile = Instantiate(scorpioTile, tileMap[row][column].position, Quaternion.identity);
                }
            }
        }
    }
    private void SpawnVaseTile()
    {
        int column;
        int row;
        //Spawning vase tile
        for (int i = 0; i < vaseNum;)
        {
            row = Random.Range(0, 6);
            column = Random.Range(0, 5);
            if (tileMap[row][column].isEmpty == true)
            {
                tileMap[row][column].isEmpty = false;
                tileMap[row][column].isVase = true;
                tileMap[row][column].tile = Instantiate(vaseTile, tileMap[row][column].position, Quaternion.identity);
                i++;
            }
        }
    }
    private void SpawnMediumTile()
    {
        for (int row = 0; row < 6; row++)
        {
            for (int column = 0; column < 5; column++)
            {
                //Check if tile is empty
                if (tileMap[row][column].isEmpty == false)
                {
                    //Check if tile is vaseTile
                    if (tileMap[row][column].isVase == true)
                    {
                        //If is vaseTile start around control
                        if (!(row - 1 < 0))
                        {
                            if (tileMap[row - 1][column].isEmpty == true)
                            {
                                tileMap[row - 1][column].isEmpty = false;
                                tileMap[row - 1][column].tile = Instantiate(mediumTile, tileMap[row - 1][column].position, Quaternion.identity);
                            }
                        }
                        if (!(row + 1 > 5))
                        {
                            if (tileMap[row + 1][column].isEmpty == true)
                            {
                                tileMap[row + 1][column].isEmpty = false;
                                tileMap[row + 1][column].tile = Instantiate(mediumTile, tileMap[row + 1][column].position, Quaternion.identity);
                            }
                        }
                        if (!(column - 1 < 0))
                        {
                            if (tileMap[row][column - 1].isEmpty == true)
                            {
                                tileMap[row][column - 1].isEmpty = false;
                                tileMap[row][column - 1].tile = Instantiate(mediumTile, tileMap[row][column - 1].position, Quaternion.identity);
                            }
                        }
                        if (!(column + 1 > 4))
                        {
                            if (tileMap[row][column + 1].isEmpty == true)
                            {
                                tileMap[row][column + 1].isEmpty = false;
                                tileMap[row][column + 1].tile = Instantiate(mediumTile, tileMap[row][column + 1].position, Quaternion.identity);
                            }
                        }

                        if(!(row - 1 <0) && !(column - 1 < 0))
                        {
                            if (tileMap[row -1][column - 1].isEmpty == true)
                            {
                                tileMap[row -1][column - 1].isEmpty = false;
                                tileMap[row -1][column - 1].tile = Instantiate(mediumTile, tileMap[row - 1][column - 1].position, Quaternion.identity);
                            }
                        }

                        if (!(row + 1 > 5) && !(column + 1 > 4))
                        {
                            if (tileMap[row + 1][column + 1].isEmpty == true)
                            {
                                tileMap[row + 1][column + 1].isEmpty = false;
                                tileMap[row + 1][column + 1].tile = Instantiate(mediumTile, tileMap[row + 1][column + 1].position, Quaternion.identity);
                            }
                        }

                        if (!(row - 1 < 0) && !(column + 1 > 4))
                        {
                            if (tileMap[row - 1][column + 1].isEmpty == true)
                            {
                                tileMap[row - 1][column + 1].isEmpty = false;
                                tileMap[row - 1][column + 1].tile = Instantiate(mediumTile, tileMap[row - 1][column + 1].position, Quaternion.identity);
                            }
                        }

                        if (!(row + 1 > 5) && !(column - 1 < 0))
                        {
                            if (tileMap[row + 1][column - 1].isEmpty == true)
                            {
                                tileMap[row + 1][column - 1].isEmpty = false;
                                tileMap[row + 1][column - 1].tile = Instantiate(mediumTile, tileMap[row + 1][column - 1].position, Quaternion.identity);
                            }
                        }

                    }
                }
            }
        }
    }
    private void SetAdiacent()
    {
        for (int row = 0; row <= 5; row++)
        {
            for (int column = 0; column <= 4; column++)
            {
                if (!(row - 1 < 0))
                {
                    tileMap[row][column].adiacent.Add(tileMap[row - 1][column]);         
                }
                if (!(row + 1 > 5))
                {
                    tileMap[row][column].adiacent.Add(tileMap[row + 1][column]);
                }
                if (!(column - 1 < 0))
                {
                    tileMap[row][column].adiacent.Add(tileMap[row][column -1]);
                }
                if (!(column + 1 > 4))
                {
                    tileMap[row][column].adiacent.Add(tileMap[row][column +1]);
                }

                if (!(row - 1 < 0) && !(column - 1 < 0))
                {
                    tileMap[row][column].adiacent.Add(tileMap[row - 1][column -1]);
                }

                if (!(row + 1 > 5) && !(column + 1 > 4))
                {
                    tileMap[row][column].adiacent.Add(tileMap[row + 1][column + 1]);
                }

                if (!(row - 1 < 0) && !(column + 1 > 4))
                {
                    tileMap[row][column].adiacent.Add(tileMap[row - 1][column + 1]);
                }

                if (!(row + 1 > 5) && !(column - 1 < 0))
                {
                    tileMap[row][column].adiacent.Add(tileMap[row + 1][column -1]);
                }
            }
        }
    }



    public void LoseLife()
    {
        lifeHearth[lives - 1].GetComponent<HearthScript>().ChangeSprite();
        lives--;
        if(lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {

    }

    public void VaseFounded()
    {
        vaseFounded++;
        if(vaseFounded == vaseNum)
        {
            LevelWin();
        }
    }

    private void LevelWin()
    {
       
    }


}

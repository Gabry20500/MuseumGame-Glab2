using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Tile
{
    public bool isEmpty = true;
    public GameObject tile;
    public Vector3 position = new Vector3( 0f, 0f, 0f );
}
public class ExcavatorManager : MonoBehaviour
{
    [SerializeField] GameObject mediumTile;
    [SerializeField] GameObject scorpioTile;
    [SerializeField] GameObject vaseTile;

    public int vaseNum = 5;

    public List<List<Tile>> tileMap = new List<List<Tile>>();

  

    private void Awake()
    {
        for (int i = 0; i < 6; i++)
        {
            tileMap.Add(new List<Tile>());
        }
        foreach(List<Tile> row in tileMap)
        {
            for (int j = 0; j < 6; j++)
            {
                row.Add(new Tile());
            }
        }
        InitializeGridPos();
        SpawnTile();
    }

    private void SpawnTile()
    {
        int columnPos;
        int rowPos;
        //Spawning vase tile
        for (int i = 0; i < vaseNum;)
        {
            rowPos = Random.Range(0, 6);
            columnPos = Random.Range(0, 5);
            if (tileMap[rowPos][columnPos].isEmpty == true)
            {
                tileMap[rowPos][columnPos].isEmpty = false;
                tileMap[rowPos][columnPos].tile = Instantiate(vaseTile, tileMap[rowPos][columnPos].position, Quaternion.identity);
                i++;
            }
        }
    }

    private void InitializeGridPos()
    {
        float xPos = -6;
        float yPos = 6;

        for (int i = 0; i <= 5; i++)
        {
            for (int j = 0; j <= 4; j++)
            {
                tileMap[i][j].position = new Vector3(xPos, yPos, 0f);
                Debug.Log(tileMap[i][j].position.ToString());
                xPos += 2.97f;
            }
            xPos = -6;
            yPos += -2.87f;
        }

        xPos = -6;
        yPos = -6;
    }




}

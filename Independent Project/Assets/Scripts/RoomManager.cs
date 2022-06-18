using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//At the start of the game, this script arranges pre-made rooms in a random formation

public class RoomManager : MonoBehaviour
{
    //array of the room prefabs
    public GameObject[] rooms = new GameObject[5];

    //Tilemaps must be a child of the grid to show up
    public GameObject grid;

    //the rooms are arranged in a rectangle, this controls the amount of rooms.
    public int width;
    public int height;

    //the size of the rooms, so that they will be spaced correctly on the grid
    int room_size = 14;

    public void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //get a random room from the list
                GameObject room = rooms[Random.Range(0, rooms.Length)];

                //place it on the grid as a child of the grid
                Instantiate(room, new Vector3(x * room_size, y * room_size, 0), Quaternion.identity, grid.transform);
            }
        }
    }
}

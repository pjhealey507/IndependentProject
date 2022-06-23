using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//At the start of the game, this script arranges pre-made rooms in a random formation

public class RoomManager : MonoBehaviour
{
    //array of the room prefabs
    public GameObject[] rooms = new GameObject[5];
    public GameObject[] corners = new GameObject[5];
    public GameObject start;
    public GameObject end;

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
                //at the beginning and end of a row, do a corner room
                if (x == 0 || x == width - 1)
                {
                    GameObject room = corners[Random.Range(0, corners.Length)];

                    Vector3 rotation = new Vector3();
                    Vector3 translation = new Vector3();

                    if (y % 2 == 0) //even rows (row starts at 0)
                    {
                        if (x == 0) //even left
                        {
                            rotation.z = 0;
                            translation.x = 2;
                            translation.y = 2;
                        }
                        else //even right
                        {
                            rotation.z = 180;
                            translation.x = 2;
                            translation.y = -2;
                        }
                    }
                    else //odd rows
                    {
                        if (x == 0) //odd left
                        {
                            rotation.z = 90;
                        }
                        else //odd right
                        {
                            rotation.z = 270;
                            translation.x = 4;
                        }
                    }

                    //place it on the grid as a child of the grid
                    Instantiate(room, new Vector3((x * room_size) + translation.x, (y * room_size) + translation.y, 0), Quaternion.Euler(rotation), grid.transform);
                }

                //regular rooms for straight parts
                else
                {
                    //get a random room from the list
                    GameObject room = rooms[Random.Range(0, rooms.Length)];

                    //place it on the grid as a child of the grid
                    Instantiate(room, new Vector3(x * room_size, y * room_size, 0), Quaternion.Euler(new Vector3(0, 0, 90)), grid.transform);
                }
            }
        }

        //place starting room (hardcoded)
        Instantiate(start, new Vector3(-1, -12, 0), Quaternion.identity, grid.transform);
    }
}

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public float holep;
    public int w, h, x, y;
    public bool[,] hwalls, vwalls;
    public Transform Level, Player, Goal;
    public GameObject Floor, Wall;
    public CinemachineVirtualCamera cam;

    void Start()
    {
        foreach (Transform child in Level)
            Destroy(child.gameObject);

        hwalls = new bool[w + 1, h]; //PARA NI SA PABAROG NA WALLS
        vwalls = new bool[w, h + 1]; //PARA NI SA PAHIGDA NA WALLS
        var st = new int[w, h]; // PARA NI SA FLOOR POSITION

        void dfs(int x, int y)
        {
            st[x, y] = 1;
            Instantiate(Floor, new Vector3(x, y), Quaternion.identity, Level);

            var dirs = new[]
            {
                (x - 1, y, hwalls, x, y, Vector3.right, 90, KeyCode.A), 
                (x + 1, y, hwalls, x + 1, y, Vector3.right, 90, KeyCode.D),
                (x, y - 1, vwalls, x, y, Vector3.up, 0, KeyCode.S),
                (x, y + 1, vwalls, x, y + 1, Vector3.up, 0, KeyCode.W),
            };                                                              // KANI NA ARRAY PARA SA MOVEMENT SA PLAYER RESET POSTION TO ORIGINAL POS
            foreach (var (nx, ny, wall, wx, wy, sh, ang, k) in dirs.OrderBy(d => Random.value))
                if (!(0 <= nx && nx < w && 0 <= ny && ny < h) || (st[nx, ny] == 2 && Random.value > holep))
                {
                    wall[wx, wy] = true;
                    Instantiate(Wall, new Vector3(wx, wy) - sh / 2, Quaternion.Euler(0, 0, ang), Level);
                }
                else if (st[nx, ny] == 0) dfs(nx, ny);
            st[x, y] = 2;
        }
        dfs(0, 0);

        x = Random.Range(0, w);
        y = Random.Range(0, h);
        Player.position = new Vector3(x, y);
        do Goal.position = new Vector3(Random.Range(0, w), Random.Range(0, h)); //GENERATE THE RANDOM POSITION OF THE GOAL
        while (Vector3.Distance(Player.position, Goal.position) < (w + h) / 4); //GIBUHAT NI NATO PARA DILI MU SPAWN ANG GOAL UG ANG PLAYER NGA TUPAD
        cam.m_Lens.OrthographicSize = Mathf.Pow(w / 3 + h / 2, 0.7f) + 1;  // MAKE SURE ANG CAMERA IN A CORRECT DISTANCE REGARDLESS SA UNSA NA KADAKO ANG GENERATED MAP   
    }

    void Update()
    {
        // DIRE DAPITA MAO NI ANG MAGSIGE UG RUN IF NAG START NA ANG GAME
        var dirs = new[]
        {
            (x - 1, y, hwalls, x, y, Vector3.right, 90, KeyCode.A),
            (x + 1, y, hwalls, x + 1, y, Vector3.right, 90, KeyCode.D),
            (x, y - 1, vwalls, x, y, Vector3.up, 0, KeyCode.S),
            (x, y + 1, vwalls, x, y + 1, Vector3.up, 0, KeyCode.W),
        };
        foreach (var (nx, ny, wall, wx, wy, sh, ang, k) in dirs.OrderBy(d => Random.value)) //GENERATION SA WALLS
            if (Input.GetKeyDown(k))
            {
                if (wall[wx, wy])
                    Player.position = Vector3.Lerp(Player.position, new Vector3(nx, ny), 0.1f); //UPDATE
                else (x, y) = (nx, ny);
            }
                

        Player.position = Vector3.Lerp(Player.position, new Vector3(x, y), Time.deltaTime * 12);
        if (Vector3.Distance(Player.position, Goal.position) < 0.12f) // KANI IMPORTANTE NI PARA KUNG ANG PLAYER MA REACH NA NIYA ANG GOAL MU RESET SIYA UG MUHATAG SIYAG RANDOM RANGE
        {
            if (Random.Range(0, 5) < 3) w++;
            else h++;
            Start();
        }
    }
}

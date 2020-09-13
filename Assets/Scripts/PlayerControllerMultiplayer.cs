using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mirror;
using Assets.Scripts;

public class PlayerControllerMultiplayer : NetworkBehaviour
{
    public GameObject TailPrefab;
    public float DeadZone = 0.3f;
    public float Interval = 0.1f;
    public int StartLength = 10;
    public float ShrinkInterval = 1;
    public int FoodValue = 5;
    public int MaxMoveChain = 2;

    public int Score = 0;
    public bool IsAlive = true;

    [SerializeField]
    private List<Transform> tail = new List<Transform>();
    [SerializeField]
    private PlayerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shrink", 0, ShrinkInterval);
        InvokeRepeating("GameTick", 0, Interval);
        movement = new PlayerMovement(MaxMoveChain, DeadZone, StartLength, TailPrefab);
    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        movement.UpdateMove();
    }

    void GameTick()
    {
        if (!IsAlive)
        {
            return;
        }

        Move();
    }

    void Move()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        movement.Move(transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (collision.gameObject.tag == "MainCamera")
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isLocalPlayer)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Tail":
                GameOver();
                break;
            case "Food":
                movement.Length += FoodValue;
                Score++;
                Destroy(collision.gameObject);//.GetComponent<FoodLifetime>().Die();
                break;
            default:
                //Does Nothing
                break;
        }
    }

    private void GameOver()
    {
        IsAlive = false;
        Time.timeScale = 0;
    }

    private void Shrink ()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (--movement.Length < 0)
        {
            GameOver();
        }
    }
}

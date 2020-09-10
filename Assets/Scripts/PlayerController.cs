using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject TailPrefab;
    public double DeadZone = 0.3;
    public int Interval = 20;
    public int StartLength = 5;
    public float ShrinkInterval = 1;
    public int FoodValue = 5;

    public int Score = 0;
    public bool IsAlive = true;

    private BoxCollider2D world;
    private Vector2 direction = Vector2.right;
    private Vector2 nextDir = Vector2.right;
    private int lastMove = 0;
    private int length;
    private List<Transform> tail = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        world = Camera.main.GetComponent<BoxCollider2D>();
        length = StartLength;
        InvokeRepeating("Shrink", 0, ShrinkInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAlive)
        {
            return;
        }

        Vector2 tempDir = Vector2.zero;
        if (Math.Abs(Input.GetAxis("Horizontal")) > DeadZone)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                tempDir = Vector2.right;
            }
            else
            {
                tempDir = Vector2.left;
            }
        }
        else if (Math.Abs(Input.GetAxis("Vertical")) > DeadZone)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                tempDir = Vector2.up;
            }
            else
            {
                tempDir = Vector2.down;
            }
        }
        if (Math.Abs(tempDir.x) != Math.Abs(direction.x) && Math.Abs(tempDir.y) != Math.Abs(direction.y))
        {
            nextDir = tempDir;
        }

        if (lastMove++ > Interval)
        {
            lastMove = 0;
            if (direction != -nextDir)
                direction = nextDir;
            Move();
        }
    }

    void Move()
    {
        Vector2 v = transform.position;
        transform.position += (Vector3)direction * transform.localScale.x;

        if (tail.Count < length)
        {
            GameObject g = Instantiate(TailPrefab, v, Quaternion.identity);
            g.SetActive(true);
            // Keep track of it in our tail list
            tail.Add(g.transform);
        }

        if (tail.Count > length)
        {
            Destroy(tail.Last().gameObject);
            tail.Remove(tail.Last());
        }

        if (tail.Count > 0)
        {
            tail.Last().position = v;

            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Tail":
                GameOver();
                break;
            case "Food":
                length += FoodValue;
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
        if (--length < 0)
        {
            GameOver();
        }
    }
}

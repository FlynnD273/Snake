using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSingleplayer : MonoBehaviour
{
    private bool isTouchingSnake;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Randomize", 0.010000001f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food" || collision.gameObject.tag == "Player")
        {
            isTouchingSnake = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food" || collision.gameObject.tag == "Player")
        {
            isTouchingSnake = false;
        }
    }

    public void Randomize ()
    {
        do
        {
            BoxCollider2D world = Camera.main.GetComponent<BoxCollider2D>();
            float x = Random.Range(world.bounds.min.x, world.bounds.max.x);
            x -= x % transform.parent.localScale.x;
            float y = Random.Range(world.bounds.min.y, world.bounds.max.y);
            y -= y % transform.parent.localScale.x;
            Vector3 v = new Vector3(x, y);
            transform.position = v;
        }
        while (isTouchingSnake);
    }
}

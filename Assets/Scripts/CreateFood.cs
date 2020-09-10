using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFood : MonoBehaviour
{
    public float Interval = 1;
    public GameObject FoodPrefab;

    private BoxCollider2D world;

    // Start is called before the first frame update
    void Start()
    {
        world = Camera.main.gameObject.GetComponent<BoxCollider2D>();
        InvokeRepeating("MakeFood", 0, Interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MakeFood ()
    {
        float x = Random.Range(world.bounds.min.x, world.bounds.max.x);
        x -= x % transform.localScale.x;
        float y = Random.Range(world.bounds.min.y, world.bounds.max.y);
        y -= y % transform.localScale.x;
        Vector3 v = new Vector3(x, y);
        Instantiate(FoodPrefab, v, Quaternion.identity).SetActive(true);
    }
}

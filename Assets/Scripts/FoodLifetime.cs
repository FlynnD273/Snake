using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLifetime : MonoBehaviour
{
    public float Lifetime = 10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Die", Lifetime, float.PositiveInfinity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die ()
    {
        Destroy(gameObject);
    }
}

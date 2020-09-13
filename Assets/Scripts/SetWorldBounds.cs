using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWorldBounds : MonoBehaviour
{
    public GameObject Player;

    private BoxCollider2D b;
    private Camera camera;
    private float w, h;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        b = GetComponent<BoxCollider2D>();

        InvokeRepeating("SetBounds", 0.01f, 0.1f);
    }

    void SetBounds ()
    {
        float s = Player.transform.parent.transform.localScale.x;
        h = camera.orthographicSize * 2;
        w = h * camera.aspect;
        //h -= h % s;
        //w -= w % s;
        b.size = new Vector2(w - s, h - s);

        float m = s / 2;

        Vector3 dl = new Vector3(b.bounds.min.x - m, b.bounds.max.y + m);
        Vector3 ul = new Vector3(b.bounds.min.x - m, b.bounds.min.y - m);
        Vector3 dr = new Vector3(b.bounds.max.x + m, b.bounds.max.y + m);
        Vector3 ur = new Vector3(b.bounds.max.x + m, b.bounds.min.y - m);

        //LineRenderer l = GetComponent<LineRenderer>();
        //l.positionCount = 5;
        //l.SetPositions(new Vector3[] { dl, dr, ur, ul, dl });
    }
}

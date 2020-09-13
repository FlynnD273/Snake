using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class PlayerMovement : ScriptableObject
    {
        public int Length { get; set; }

        private Vector2 direction = Vector2.zero;
        private Queue<Vector2> dirs = new Queue<Vector2>();
        private List<Transform> tail = new List<Transform>();
        private GameObject tailPrefab;

        private bool l = false;
        private bool r = false;
        private bool u = false;
        private bool d = false;

        private int MaxMoveChain;
        private float DeadZone;
        public PlayerMovement (int maxMove, float deadZone, int startLength, GameObject tailPrefab)
        {
            MaxMoveChain = Math.Max(maxMove, 1);
            DeadZone = deadZone;
            Length = startLength;
            this.tailPrefab = tailPrefab;
        }

        private int RoundToZero (float v)
        {
            return (int)Math.Floor(Math.Abs(v)) * Math.Sign(v);
        }

        public void UpdateMove ()
        {
            Vector2 tempDir = Vector2.zero;
            Vector2 input = new Vector2(RoundToZero(Input.GetAxis("Horizontal") / DeadZone), RoundToZero(Input.GetAxis("Vertical") / DeadZone));

            if (input.x > 0 && !r)
            {
                tempDir = Vector2.right;
            }
            if (input.x < 0 && !l)
            {
                tempDir = Vector2.left;
            }
            if (input.y > 0 && !u)
            {
                tempDir = Vector2.up;
            }
            if (input.y < 0 && !d)
            {
                tempDir = Vector2.down;
            }

            if (input.x > 0)
            {
                r = true;
            }
            else
            {
                r = false;
                if (input.x < 0)
                {
                    l = true;
                }
                else
                {
                    l = false;
                }
            }
            if (input.y > 0)
            {
                u = true;
            }
            else
            {
                u = false;
                if (input.y < 0)
                {
                    d = true;
                }
                else
                {
                    d = false;
                }
            }

            if (tempDir == Vector2.zero)
            {
                return;
            }

            if (dirs.Count > 0)
            {
                if (Math.Abs(tempDir.x) != Math.Abs(dirs.Last().x) || Math.Abs(tempDir.y) != Math.Abs(dirs.Last().y))
                {
                    if (dirs.Count < MaxMoveChain)
                    {
                        dirs.Enqueue(tempDir);
                    }
                }
            }
            else
            {
                if (Math.Abs(tempDir.x) != Math.Abs(direction.x) || Math.Abs(tempDir.y) != Math.Abs(direction.y))
                {
                    dirs.Enqueue(tempDir);
                }
            }
        }

        public void Move (Transform transform)
        {
            if (dirs.Count > 0)
                direction = dirs.Dequeue();
            if (direction != Vector2.zero)
                UpdateTail(transform);

            transform.position += ((Vector3)direction * transform.parent.localScale.x);

            
        }

        private void UpdateTail (Transform transform)
        {
            if (tail.Count < Length)
            {
                GameObject g = Instantiate(tailPrefab, transform.position, Quaternion.identity);
                g.transform.parent = transform.parent.transform;
                g.transform.localScale = Vector3.one;

                g.SetActive(true);
                tail.Add(g.transform);
            }

            if (tail.Count > Length)
            {
                Destroy(tail.Last().gameObject);
                tail.Remove(tail.Last());
            }

            if (tail.Count > 0)
            {
                tail.Last().position = transform.position;

                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }
        }
    }
}

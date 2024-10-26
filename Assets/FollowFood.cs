using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFood : MonoBehaviour
{
    [SerializeField] GameObject dot, topLeft, bottomRight;
    public float fishSpeed = 3f;

    Queue<GameObject> positionsQ = new Queue<GameObject>();

    Vector3 sizeIncrease = new Vector3(0.03f, 0.03f, 0.03f);
    void Start()
    {


    }

    void Update()
    {
        
           Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (topLeft.transform.position.x <= mp.x && bottomRight.transform.position.x >= mp.x
                    && topLeft.transform.position.y >= mp.y && bottomRight.transform.position.y <= mp.y)
            {
                if(Input.GetMouseButtonDown(0)) {
                    GameObject currD = Instantiate(dot);
                    currD.transform.position = mp;
                    positionsQ.Enqueue(currD);
                }

            }
        
        
        if (positionsQ.Count >= 1)
        {
            Vector2 currTarget = positionsQ.Peek().transform.position;

            transform.right = new Vector2(currTarget.x - transform.position.x, currTarget.y - transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, currTarget, fishSpeed * Time.deltaTime);
            if (transform.position.x == currTarget.x && transform.position.y == currTarget.y)
            {
                positionsQ.Peek().GetComponent<DestroyAfter>().DestroyWrapper();
                positionsQ.Dequeue();
                if (transform.localScale.magnitude <= 6)
                {
                    transform.localScale += sizeIncrease;
                    if (fishSpeed >= 1) fishSpeed -= 0.1f;
                }
                
            }

        }
        else
        {
            if (transform.localScale.magnitude >= 0.6)
            {
                transform.localScale -= sizeIncrease * Time.deltaTime * 3;
                if (fishSpeed <= 5) fishSpeed += 0.1f;
            }
        }




    }

}

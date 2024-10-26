using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class followCursor : MonoBehaviour
{
    [SerializeField] GameObject dot, topLeft,bottomRight;
    public float fishSpeed = 3f;

    Queue<GameObject> positionsQ = new Queue<GameObject>();   
    

    void Start()
    {
        StartCoroutine(mainTask());
        
    }

    void Update()
    {
        if(positionsQ.Count >=1) {
        
        
            Vector2 currTarget = positionsQ.Peek().transform.position;

            transform.right = new Vector2(currTarget.x - transform.position.x, currTarget.y - transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, currTarget, fishSpeed * Time.deltaTime);
            if (transform.position.x == currTarget.x && transform.position.y == currTarget.y)
            {
                positionsQ.Peek().GetComponent<DestroyAfter>().DestroyWrapper();
                positionsQ.Dequeue();

            }
        }


    }

    IEnumerator mainTask()
    {
        Vector2 lastPos = new Vector2(0, 0);
        while (true)
        {
            Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mp, lastPos) > 1 && topLeft.transform.position.x <=  mp.x  && bottomRight.transform.position.x>= mp.x
                    && topLeft.transform.position.y >= mp.y && bottomRight.transform.position.y <= mp.y)
            {
                GameObject currD = Instantiate(dot);
                currD.transform.position = mp;
                positionsQ.Enqueue(currD);

                lastPos = mp;

            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}

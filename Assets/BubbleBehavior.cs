using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehavior : MonoBehaviour
{
    [SerializeField] int topY = 8;
    [SerializeField] float clickTolerance = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,1) * Time.deltaTime;
        if(transform.position.y > topY) {
            Destroy(gameObject); 
        }
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.SqrMagnitude(transform.position - mp) <= clickTolerance) Pop();
        }
    }
    public void Pop()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField] float waitTime;
    public void DestroyWrapper()
    {
        StartCoroutine(mainTask());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator mainTask()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBubbles : MonoBehaviour
{
    [SerializeField] GameObject bubbleGM;
    [SerializeField] GameObject LeftGM;
    [SerializeField] GameObject RightGM;

    public int cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(mainTask());
    }
    
    IEnumerator mainTask()
    {
        while (true)
        {
            float randomX = Random.Range(LeftGM.transform.position.x, RightGM.transform.position.x);
           
            Vector3 randPos = new Vector3(randomX, -8f, 0);
            GameObject b = Instantiate(bubbleGM,randPos,Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }

    }


}

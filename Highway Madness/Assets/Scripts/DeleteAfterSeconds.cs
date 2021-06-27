using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterSeconds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countDownToDie());
    }

    IEnumerator countDownToDie()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}

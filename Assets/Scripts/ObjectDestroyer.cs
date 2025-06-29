using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] private float DestoryTime;
    void Start()
    {
        StartCoroutine(DestroyObject(DestoryTime));
    }

    private IEnumerator DestroyObject(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}

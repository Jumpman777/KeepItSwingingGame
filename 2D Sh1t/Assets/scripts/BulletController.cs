using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed= 10f;
    public float lifetime= 3f;
    // Start is called before the first frame update

    void Start() => StartCoroutine(Destroy()); 
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right* speed* Time.deltaTime);
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(lifetime);
            Destroy(gameObject);
    }
}

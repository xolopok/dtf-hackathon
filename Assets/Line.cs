using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Rigidbody2D body;

    public float shrinkSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        this.body.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= Vector3.one * this.shrinkSpeed * Time.deltaTime;
        if (transform.localScale.x <= .5f)
        {
            Destroy(gameObject);
        }
    }
}

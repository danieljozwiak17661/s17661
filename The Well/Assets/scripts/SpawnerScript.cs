using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public float period = 1;
    private float SpawnDelay;

    public Enemy prefab;
    private SpriteRenderer SRenderer;

    void Start()
    {
        SRenderer = GetComponent<SpriteRenderer>();
        SpawnDelay = 0;
    }

    void Update()
    {
        SpawnDelay += Time.deltaTime;
        if (SRenderer.isVisible)
        {
            if (SpawnDelay >= period)
            {
                SpawnDelay = 0;
                Instantiate(prefab, transform.position, transform.rotation);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public GameObject CubePrefab;

    private float timeSinceLastSpawn = 0f;
    
    void Start()
    {
        transform.position = new Vector3(2, 3, -1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.9f, 1.0f, 0.8f, 0.9f);
    }
    
    void Update()
    {    
        transform.Rotate(10.0f * Time.deltaTime, 9f * Time.deltaTime, 0.0f);

        if(timeSinceLastSpawn >= 1f)
        {
           Instantiate(CubePrefab, new Vector3(2, 8, -1), CubePrefab.transform.rotation);
            timeSinceLastSpawn = 0f;
        }
        else
        {
            timeSinceLastSpawn += Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Renderer.material.color = Random.ColorHSV();
    }
}

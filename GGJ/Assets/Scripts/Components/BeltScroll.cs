using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltScroll : MonoBehaviour
{
    public float ScrollSpeed = 10f;
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = mat.GetTextureOffset("_MainTex");

        float yOffset = offset.y + (ScrollSpeed * Time.deltaTime);

        if(yOffset > 1)
        {
            yOffset = 0;
        }

        mat.SetTextureOffset("_MainTex", new Vector2(offset.x, yOffset));
    }
}

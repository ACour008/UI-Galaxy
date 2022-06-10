using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTests : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        LehmerRNG.Initialize(43);

        int sectorSizeX = Mathf.RoundToInt(Screen.width / 32);
        int sectorSizeY = Mathf.RoundToInt(Screen.height / 32);

        int maxRadius = Mathf.Min(sectorSizeY, sectorSizeX);

        for (int j = 0; j < 25; j++)
        {

            int offsetX = (j / 5) * 64;
            int offsetY = (j % 5) * 64;

            for (int i = 0; i < sectorSizeX * sectorSizeY; i++)
            {
                float radius = Mathf.Sqrt(LehmerRNG.NextFloat(0f, 1f)) * maxRadius; ;
                float angle = LehmerRNG.NextFloat(0f, Mathf.PI * 2);

                int x = (int)(offsetX + Mathf.Cos(angle) * radius);
                int y = (int)(offsetY + Mathf.Sin(angle) * radius);

                if (LehmerRNG.Next(0, 20) == 1)
                {
                    GameObject.Instantiate<GameObject>(prefab, new Vector3(x, y, 0), Quaternion.identity, this.transform);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

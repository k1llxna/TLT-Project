using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : MonoBehaviour
{
    public static Bench instance;
    [SerializeField] private Hex[] hexArray;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    [SerializeField] private float xSpacing;
    [SerializeField] private float zSpacing;
    [SerializeField] private float increment;
    [SerializeField] private int benchArray = 8;
    [SerializeField] private Vector3 pos;

    public GameObject hex;

    public void CreateBench(int length) // 1 dimensional
    {
        this.benchArray = length;
        hexArray = new Hex[length];
        increment = xSpacing;
        for (int x = 0; x < benchArray; x++)
        {
            pos.x = this.transform.position.x + xSpacing;
            pos.z = this.transform.position.z + zSpacing;
            pos.y = this.transform.position.y;

            hexArray[x] = Instantiate(hex, pos, this.transform.rotation, this.transform).GetComponent<Hex>();
            hexArray[x].gameObject.GetComponent<Hex>().SetBenchHex();
            // hexArray[x].gameObject.GetComponent<Hex>().SetNumberID(x, 0);

            xSpacing += increment;
        }
    }

    public float SetXSpacing(float x) { return xSpacing = x; }
    public float SetZSpacing(float z) { return zSpacing = z; }

    public int GetBenchLength() { return benchArray; }
    public Hex[] GetBenchHexes() { return hexArray; }
}

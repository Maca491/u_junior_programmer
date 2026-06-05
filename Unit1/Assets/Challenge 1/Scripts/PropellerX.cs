using UnityEngine;

public class PropellerX : MonoBehaviour
{
    public Vector3 rotation = new Vector3(0,0,6);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation); 
    }
}

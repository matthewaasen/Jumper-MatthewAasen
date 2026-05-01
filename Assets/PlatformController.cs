using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public bool landed;
    public float platformSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        landed = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.SetPositionAndRotation(new Vector3(gameObject.transform.position.x,gameObject.transform.position.y + (-platformSpeed*Time.deltaTime),gameObject.transform.position.z), Quaternion.identity);
    }
}

using UnityEngine;

public class PositionHoop : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
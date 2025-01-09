using UnityEngine;

public class PositionHoop : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Fix the rotation of the object to (0, 0, 0)
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
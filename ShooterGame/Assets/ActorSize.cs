using UnityEngine;

public class ActorSize : MonoBehaviour
{
    void Start()
    {
        Renderer rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            Vector3 size = rend.bounds.size;
            Debug.Log($"Actor size: {size} (Width: {size.x}, Height: {size.y}, Length/Depth: {size.z})");
        }
    }
}

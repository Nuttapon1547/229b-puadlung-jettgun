using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset = new Vector3(0f, 0f, -10f); 
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
        
    private void Update()
    {
            Vector3 targetposition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothTime);
    }
}

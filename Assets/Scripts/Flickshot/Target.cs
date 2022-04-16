using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] AudioClip destroySFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Hit()
    {
        AudioSource.PlayClipAtPoint(destroySFX, Camera.main.transform.position);
        transform.position = TargetBounds.Instance.GetRandomPosition();
    }
}

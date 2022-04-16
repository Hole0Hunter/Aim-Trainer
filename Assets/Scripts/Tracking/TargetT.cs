using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetT : MonoBehaviour
{
    [SerializeField] float maxHitPoints = 100f;
    [SerializeField] float rotationSpeed;
    [SerializeField] int rotationDirection;
    [SerializeField] Transform cam;
    Vector3 pivot;
    [SerializeField] float hitPoints;

    [SerializeField] AudioClip destroySFX;

    // Rotation angle bounds
    [SerializeField] float angleBound = 25f;
    public float angle;

    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        SetupGeneralParameters();
        healthBar.SetMaxHealth(maxHitPoints);

        Vector3 projectionOnXZPlane = new Vector3(transform.position.x, 0, transform.position.z);
        angle = Vector3.Angle(projectionOnXZPlane - cam.position, new Vector3(0, 0, 1));
        Debug.Log("TargetName: " + gameObject.name + " TargetAngle: " + angle);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the target
        transform.RotateAround(pivot, Vector3.up, rotationSpeed * rotationDirection * Time.deltaTime);

        // The targets should rotate between the specified rotation bounds
        // measure the angle between the target and the vertical plane of the camera
        Vector3 projectionOnXZPlane = new Vector3(transform.position.x, 0, transform.position.z);
        angle = Vector3.Angle(projectionOnXZPlane - cam.position, new Vector3(0, 0, 1));
        // Debug.Log(angle);
        if (angle > angleBound)
        {
            rotationDirection *= -1;
        }
    }

    public void Destroyed()
    {
        TargetShooterT.numOfTargetsDestroyed++;
        AudioSource.PlayClipAtPoint(destroySFX, Camera.main.transform.position);
        transform.position = TargetBoundsT.Instance.GetRandomPosition();
        float scale = Random.Range(1f, 2f);
        transform.localScale = new Vector3(scale, scale, scale);
        SetupGeneralParameters();
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints);
        if (hitPoints <= 0)
        {
            Destroyed();
        }
    }

    public void SetupGeneralParameters()
    {
        // Set random rotation speed between 15 to 20
        rotationSpeed = Random.Range(15f, 20f);
        // Set random rotation direction
        rotationDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        // Cam position
        pivot = cam.position;
        // Setting up the health bar
        hitPoints = maxHitPoints;
    }
}

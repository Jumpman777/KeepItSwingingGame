using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class shoot : MonoBehaviour
{


    Camera _mainCamera;
    Vector2 previousMousePos;
    Rigidbody2D rb2D;


    public float forceRecoil = 10f;
    public float minWeaponRotation = -90;
    public float maxWeaponRotation = 90;

    [SerializeField] Transform weaponHandle;
    [SerializeField] Transform weapon;

    [SerializeField] Transform bullet;
    [SerializeField] Transform bulletHolder;


    // Start is called before the first frame update
    void Start()
    {
        _mainCamera= Camera.main;
        rb2D= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 mousePos = Input.mousePosition;
        // if current position isn't the same as previous 
        if(mousePos != previousMousePos)
        {
            float  angle = Mathf.Clamp(GetDistanceAngle(weaponHandle, mousePos), minWeaponRotation, maxWeaponRotation);
            
            RotateTransform(weaponHandle, angle);

            previousMousePos = mousePos;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(weaponHandle.eulerAngles.z);
        }
    }

    // calculates the angle between the gun & mousePos
    public float GetDistanceAngle(Transform transform, Vector2 screenToMousePos)
    {
        Vector2 mousePosToWorld= _mainCamera.ScreenToWorldPoint(screenToMousePos);
        Vector2 offset= mousePosToWorld- (Vector2)transform.position;

        return  Mathf.Atan2(offset.x, offset.y)* Mathf.Rad2Deg;

    }

    //Rotates my transform around the z axis
    private void RotateTransform(Transform transform, float angle) =>
      transform.rotation = Quaternion.Euler(Vector3.forward * angle);

    public void Shoot(float direction)
    {
        
        Transform newBullet = Instantiate(bullet, bulletHolder);
        Vector2 offset= GetBulletOffset(bullet, direction);

        newBullet.position= (Vector2)weapon.position + offset;
        RotateTransform(newBullet, direction);

        AddRecoilForce(offset);
        Debug.Log("Bam!");

    }

    private Vector2 GetBulletOffset(Transform bullet, float direction)
    {
        float angle= direction* Mathf.Rad2Deg;

        float diagonal = (weapon.lossyScale.x + bullet.lossyScale.x) * .5f;

        return new Vector2 (Mathf.Cos(angle), Mathf.Sin(angle))* diagonal;
    }

    private void AddRecoilForce(Vector2 direction) => rb2D.AddForce(10f * forceRecoil * -direction.normalized);
    
}

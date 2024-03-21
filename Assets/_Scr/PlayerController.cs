using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    #region var
    [Header("General")]
    public float speedWalk;
    public float speedRun;
    public float speedMax;
    private float speed;
    private bool isAiming = false;

    [Header("Fuck")]
    public Vector3 gay;
    private Quaternion originalPosition;
    private Vector3 objectPosition;
    #endregion
    #region comp
    [Header("Mouse")]
    public GameObject mouse;
    public GameObject vis;

    private Rigidbody rigidBody;
    private Vector3 dir;
    private Camera cam;
    private Transform camTransform;
    private Transform visual;
    #endregion
    private void Start()
    {
        visual = transform.Find("Vis");
        speed = speedWalk;
        rigidBody = GetComponent<Rigidbody>();
        cam = Camera.main;
        camTransform = cam.transform.parent.transform;
        originalPosition = camTransform.rotation;
    }

    private void Update()
    {
        PlayerInput();
        PlayerMouse();
        PlayerMove();
        //camTransform.rotation = Quaternion.RotateTowards(camTransform.rotation, originalPosition, Time.deltaTime * 5); //recoil beta
    }

    private void FixedUpdate()
    {
        PlayerLook();
        if (isAiming)
        {
            camTransform.position += visual.forward * Time.deltaTime * 7f;
        }
    }

    private void LateUpdate()
    {
        if (isAiming) return;
        camTransform.position = transform.position;
    }

    private void PlayerInput()
    {
        dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift)) PlayerAim();
        else isAiming = false;

        if (Input.GetKeyDown(KeyCode.R)) Reload();
    }
    private void PlayerMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouse.transform.position = objectPosition;
    }
    private void PlayerLook()
    {    
        //vis
        Vector3 playerLookDirection = mouse.transform.position - transform.position;
        playerLookDirection = playerLookDirection.normalized;

        float needToRotateDeg = Mathf.Atan2(playerLookDirection.z,
            playerLookDirection.x) * Mathf.Rad2Deg;

        vis.transform.rotation = Quaternion.Euler(0, -(needToRotateDeg + 270f), 0);
    }
    private void PlayerMove()
    {
        if (isAiming)
        {
            rigidBody.velocity = dir * speed * 0.3f;
        }
        else
        {
            rigidBody.velocity = dir * speed;
        }
    }
    private void PlayerAim()
    {
        isAiming = true;
        rigidBody.velocity = Vector3.zero;
    }
    private void Reload()
    {

    }
    public void Shoot(float force)
    {
        Vector3 a = mouse.transform.position - vis.transform.position;
        a.Normalize();
        a *= 10;
        Debug.DrawRay(vis.transform.position, a, Color.red, 0.5f);

        //camTransform.rotation *= Quaternion.Euler(gay);
        Recoil(force);
    }
    private void Recoil(float shootForce)
    {
        StopAllCoroutines();
        StartCoroutine(Reco(shootForce));
    }
    private IEnumerator Reco(float shootForce)
    {
        float timer = 0;
        while(timer <= 0.1f)
        {
            yield return null;
            timer += Time.deltaTime;
            Vector3 ra = Random.insideUnitSphere * shootForce;
            ra.y = 10;
            cam.transform.localPosition = ra;
        }
        cam.transform.localPosition = new Vector3(0,10,0);
        yield return new WaitForSeconds(0.5f);
        isAiming = false;
    }
}

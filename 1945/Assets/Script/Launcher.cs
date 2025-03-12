using System.Collections;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bullet;
    private Coroutine shootingCoroutine;
    //void Start()
    //{
    //    StartCoroutine(ShootCoroutine());
    //}

    //IEnumerator ShootCoroutine()
    //{
    //    yield return new WaitForSeconds(0.5f);

    //    while (true)
    //    {
    //        Shoot();
    //        yield return new WaitForSeconds(0.5f);
    //    }
    //}

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Z))
    //        Shoot();
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (shootingCoroutine == null)
                shootingCoroutine = StartCoroutine(ShootCoroutine());
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            if (shootingCoroutine != null)
            {
                StopCoroutine(shootingCoroutine);
                shootingCoroutine = null;
            }
        }
    }

    IEnumerator ShootCoroutine()
    {
        yield return new WaitForSeconds(0.1f);

        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(0.2f);
        }
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}

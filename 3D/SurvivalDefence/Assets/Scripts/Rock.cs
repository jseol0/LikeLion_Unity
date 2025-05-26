using System.Security.Cryptography;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private int hp;

    [SerializeField]
    private float DestroyTime;

    [SerializeField]
    private SphereCollider col;

    [SerializeField]
    private GameObject go_rock;
    [SerializeField]
    private GameObject go_debris;
    [SerializeField]
    private GameObject go_effect_prefab;
    [SerializeField]
    private GameObject go_rock_item_prefab;

    [SerializeField]
    private int count;

    [SerializeField]
    private string strike_Sound;
    [SerializeField]
    private string destroy_Sound;

    public void Mining()
    {
        SoundManager.Instance.PlaySE(strike_Sound);

        var clone = Instantiate(go_effect_prefab, col.bounds.center, Quaternion.identity);
        Destroy(clone, DestroyTime);

        hp--;
        if (hp <= 0)
            Destruction();
    }

    private void Destruction()
    {
        SoundManager.Instance.PlaySE(destroy_Sound);
        
        col.enabled = false;
        
        for (int i = 0; i < count; i++)
        {
            Instantiate(go_rock_item_prefab, new Vector3(go_rock.transform.position.x, go_rock.transform.position.y + 0.5f, go_rock.transform.position.z), Quaternion.identity);
        }
        Destroy(go_rock);

        go_debris.SetActive(true);
        Destroy(go_debris, DestroyTime);
    }
}

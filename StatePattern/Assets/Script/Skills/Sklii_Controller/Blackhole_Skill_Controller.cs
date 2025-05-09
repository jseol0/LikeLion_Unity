using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole_Skill_Controller : MonoBehaviour
{
    [SerializeField] private GameObject hotkeyPrefab;
    [SerializeField] private List<KeyCode> keyCodeList;

    public float maxSize;
    public float growSpeed;
    public float shrinkSpeed;
    public bool canShrink;
    public bool canGrow = true;

    private bool canCreateHotKeys = true;
    private bool cloneAttackReleased;
    public int amountOfAttack = 4;
    private float cloneAttackCooldown = 0.3f;
    private float cloneAttackTimer;

    public List<Transform> targets = new List<Transform>();
    public List<GameObject> createHotKey = new List<GameObject>();

    public void SetupBlackhole(float _maxSize, float _growSpeed, float _shinkSpeed, int _amountOfAttacks, float _cloneAttackCooldown)
    {
        maxSize = _maxSize;
        growSpeed = _growSpeed;
        shrinkSpeed = _shinkSpeed;
        amountOfAttack = _amountOfAttacks;
        cloneAttackCooldown = _cloneAttackCooldown;
    }

    private void Update()
    {
        cloneAttackTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E))
        {
            ReleaseCloneAttack();
        }

        CloneAttackLogic();

        if (canGrow && !canShrink)
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(maxSize, maxSize), growSpeed * Time.deltaTime);

        if (canShrink)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(-1, -1), shrinkSpeed * Time.deltaTime);

            if (transform.localScale.x < 0)
                Destroy(gameObject);
        }
    }

    private void ReleaseCloneAttack()
    {
        DestroyHotKey();
        canCreateHotKeys = false;
        cloneAttackReleased = true;
    }

    private void CloneAttackLogic()
    {
        if (cloneAttackTimer < 0 && cloneAttackReleased)
        {
            cloneAttackTimer = cloneAttackCooldown;

            int randomIndex = Random.Range(0, targets.Count);

            float xOffset;
            if (Random.Range(0, 100) > 50)
                xOffset = 1;
            else
                xOffset = -1;

            SkillManager.instance.clone.CreateClone(targets[randomIndex], new Vector3(xOffset, 0));

            amountOfAttack--;
            if (amountOfAttack <= 0)
            {
                PlayerManager.instance.player.ExitBlackHoleAbillity();

                canShrink = true;
                cloneAttackReleased = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().FreezeTime(true);
            CreateHotKey(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().FreezeTime(false);
        }
    }

    private void DestroyHotKey()
    {
        if (createHotKey.Count <= 0)
            return;

        for (int i = 0; i < createHotKey.Count; i++)
        {
            Destroy(createHotKey[i]);
        }
    }

    private void CreateHotKey(Collider2D collision)
    {
        if (keyCodeList.Count <= 0)
        {
            Debug.LogWarning("키 등록 체크");
            return;
        }


        GameObject newHotKey = Instantiate(hotkeyPrefab, collision.transform.position + new Vector3(0, 2), Quaternion.identity);

        createHotKey.Add(newHotKey);

        KeyCode choosenKey = keyCodeList[Random.Range(0, keyCodeList.Count)];
        keyCodeList.Remove(choosenKey);

        Blackhole_HotKey_Controller newHotKeyScript = newHotKey.GetComponent<Blackhole_HotKey_Controller>();

        newHotKeyScript.SetupHotKey(choosenKey, collision.transform, this);
    }

    public void AddEnemyToList(Transform _enemyTransform) => targets.Add(_enemyTransform);
}

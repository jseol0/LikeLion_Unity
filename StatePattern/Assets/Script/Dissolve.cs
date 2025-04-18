using System.Collections;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] private float _dissolveTime = 0.75f;

    private SpriteRenderer _spriteRenderer;
    private Material _material;

    private int _dissolveAmount = Shader.PropertyToID("_DissolveAmount");
    private int _verticalDissolveAmount = Shader.PropertyToID("_VerticalDissolve");

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _material = _spriteRenderer.material;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            StartCoroutine(Vanish(true, false));
        if (Input.GetKeyDown(KeyCode.Alpha2))
            StartCoroutine(Appear(true, false));
    }

    private IEnumerator Vanish(bool useDissolve, bool useVertical)
    {
        float elapsedTime = 0f;
        while (elapsedTime < _dissolveTime)
        {
            elapsedTime += Time.deltaTime;

            float lerpedDissolve = Mathf.Lerp(0f, 1.1f, elapsedTime / _dissolveTime);
            float lerpedVerticalDissolve = Mathf.Lerp(0f, 1.1f, elapsedTime / _dissolveTime);

            if (useDissolve)
                _material.SetFloat(_dissolveAmount, lerpedDissolve);
            if (useVertical)
                _material.SetFloat(_verticalDissolveAmount, lerpedVerticalDissolve);

            yield return null;
        }
    }

    private IEnumerator Appear(bool useDissolve, bool useVertical)
    {
        float elapsedTime = 0f;
        while (elapsedTime < _dissolveTime)
        {
            elapsedTime += Time.deltaTime;

            float lerpedDissolve = Mathf.Lerp(1.1f, 0f, elapsedTime / _dissolveTime);
            float lerpedVerticalDissolve = Mathf.Lerp(1.1f, 0f, elapsedTime / _dissolveTime);

            if (useDissolve)
                _material.SetFloat(_dissolveAmount, lerpedDissolve);
            if (useVertical)
                _material.SetFloat(_verticalDissolveAmount, lerpedVerticalDissolve);

            yield return null;
        }
    }
}

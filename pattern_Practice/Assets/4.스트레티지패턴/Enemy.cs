using TreeEditor;
using UnityEngine;


// 4. 스트래티지 패턴
// 스트레티지 패턴은 객체의 행위를 클래스로 캡슐화하여 동적으로 행위를 자유롭게 바꿀 수 있게 해주는 패턴이다.
// Unity에서는 스트레티지 패턴을 사용하여 AI행동, 캐릭터의 움직임을 구현할 수 있다.

// 이동 전략 인터페이스
public interface IMovementStrategy
{
    void Move(Transform transform, float speed);
}

// 직선 이동 전략
public class StraightMovemnet : IMovementStrategy
{
    public void Move(Transform transform, float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

// 지그재그 이동 전략
public class ZigzagMovement : IMovementStrategy
{
    private float _amplitude = 2f;
    private float _frequency = 2f;
    private float _time = 0;

    public void Move(Transform transform, float speed)
    {
        _time += Time.deltaTime;

        // 직선이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // 좌우 움직임 추가
        float xOffsset = Mathf.Sin(_time * _frequency) * _amplitude;
        transform.position = new Vector3(xOffsset, transform.position.y, transform.position.z);
    }
}

// 원형 이동 전략
public class CircularMovement : IMovementStrategy
{
    private float _radius = 5f;
    private float _angularSpeed = 50f;
    private float _angle = 0;
    private Vector3 _center;
    private bool _isInitialized = false;

    public void Move(Transform transform, float speed)
    {
        if (!_isInitialized)
        {
            _center = transform.position;
            _isInitialized = true;
        }

        _angle += _angularSpeed * Time.deltaTime;

        float x = _center.x + Mathf.Cos(_angle * Mathf.Deg2Rad) * _radius;
        float z = _center.z + Mathf.Sin(_angle * Mathf.Deg2Rad) * _radius;

        transform.position = new Vector3(x, transform.position.y, z);

        transform.LookAt(new Vector3(_center.x + Mathf.Cos((_angle + 90) * Mathf.Deg2Rad) * _radius,
            transform.position.y,
            _center.z + Mathf.Sin(_angle + 90) * Mathf.Deg2Rad * _radius));
    }
}

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;

    private IMovementStrategy _movementStrategy;

    void Start()
    {
        //기본이동전략
        _movementStrategy = new StraightMovemnet();
    }

    //이동전략 변경 메서드
    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        _movementStrategy = strategy;
    }

    void Update()
    {
        if (_movementStrategy != null)
            _movementStrategy.Move(transform, moveSpeed);
    }
}

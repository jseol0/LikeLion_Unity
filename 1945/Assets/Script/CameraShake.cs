using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    //Impulse Source컴포넌트 참조
    private CinemachineImpulseSource impulseSource;

    void Start()
    {
        instance = this;
        impulseSource = GetComponent<CinemachineImpulseSource>();

    }

    public void CameraShakeShow()
    {
        if (impulseSource != null)
        {
            impulseSource.GenerateImpulse();
        }
    }
}

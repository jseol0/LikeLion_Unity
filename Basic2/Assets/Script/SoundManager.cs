using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //싱글톤
    public static SoundManager instance;    //자기 자신을 변수로 담기

    private AudioSource myAudio;            //AudioSource 컴포넌트를 변수로 담는다
    public AudioClip soundBullet;           //재생할 소리
    public AudioClip soundDie;

    private void Awake()
    {
        if (SoundManager.instance == null)
            SoundManager.instance = this;
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayBulletSound()
    {
        myAudio.PlayOneShot(soundBullet);
    }

    public void PlayDieSound()
    {
        myAudio.PlayOneShot(soundDie);
    }
}

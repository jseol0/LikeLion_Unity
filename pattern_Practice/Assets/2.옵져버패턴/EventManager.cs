using System;
using System.Collections.Generic;
using UnityEngine;


//## 2. 옵저버(Observer) 패턴

//옵저버 패턴은 객체 간 일대다 의존성을 정의하여, 한 객체의 상태가 변경되면
//의존하는 모든 객체에 통보하여 자동으로 업데이트되는 방식입니다.

//이벤트 관리자(Subject)
public class EventManager : MonoBehaviour
{
    //싱글톤 구현
    private static EventManager _instance;

    public static EventManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("EventManager");
                _instance = go.AddComponent<EventManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }


    //이벤트와 옵저버를 연결하는 딕셔너리
    private Dictionary<string, Action<object>> _eventDictionary = new Dictionary<string, Action<object>>();

    //이벤트에 옵저버 추가
    public void AddListener(string eventName, Action<object> listener)
    {
        if(_eventDictionary.TryGetValue(eventName,out Action<object> thisEvent))
        {
            thisEvent += listener;
            _eventDictionary[eventName] = thisEvent;
        }
        else
        {
            _eventDictionary.Add(eventName, listener);
        }
    }

    //이벤트에서 옵저버 제거
    public void RemoveListener(string eventName, Action<object> listener)
    {
        if(_eventDictionary.TryGetValue(eventName,out Action<object> thisEvent))
        {
            thisEvent -= listener;
            _eventDictionary[eventName] = thisEvent;
        }
    }

    //이벤트발생(모든 옵저버에게 알림)
    public void TriggerEvent(string eventName,object data = null)
    {
        if(_eventDictionary.TryGetValue(eventName,out Action<object> thisEvent))
        {
            thisEvent?.Invoke(data);
        }
    }

    
}

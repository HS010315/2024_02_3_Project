using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCallback : MonoBehaviour
{
    private Action greetingAction;

    // Start is called before the first frame update
    void Start()
    {
        greetingAction = SayHello;                  //액션 함수 등록    
        PerformGreeting(greetingAction);            //액션을 인수로 함수 호출
    }

    void SayHello()
    {
        Debug.Log("Hello, world");
    }

    void PerformGreeting(Action greetingFunc)
    {
        greetingFunc?.Invoke();                     //액션 호출
    }
}

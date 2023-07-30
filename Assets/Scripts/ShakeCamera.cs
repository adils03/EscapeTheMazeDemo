using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    [SerializeField] float shakeDuration=1f;
    [SerializeField] float shakeMagnitude=0.5f;

    

    Vector3 initialPosition;
    private void Awake() {
    }
    void Start()
    {
        initialPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(){
        StartCoroutine(shake());
    }
    IEnumerator shake(){
        float elapsedTime = 0;
        while(elapsedTime<shakeDuration){
            transform.position=initialPosition+(Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime+=Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position=initialPosition;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class PipeCreator : MonoBehaviour
    {
        public GameObject Pipe;
        private Coroutine generator;

        public void OnEnterGame()
        {
            generator = StartCoroutine(GeneratePipes());
        }   

        public void OnExitGame() 
        {
            StopCoroutine(generator);
        }

        IEnumerator GeneratePipes() 
        {
            while(true)
            {
                GameObject pipe = Instantiate(Pipe, this.transform);
                Destroy(pipe, 5.0f);
                yield return new WaitForSeconds(2.0f);
            }
        }

        public void clearAllPipes()
        {
            int size = transform.childCount;
            for (int i = 0; i < size; i++){
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
    }
}
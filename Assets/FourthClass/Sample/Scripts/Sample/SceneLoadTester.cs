using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class SceneLoadTester : MonoBehaviour
    {


        public void StartButton()
        {
            Loading.LoadScene("SampleScene");
        }
    } 
}

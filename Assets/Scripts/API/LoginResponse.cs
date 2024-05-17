using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LoginReponse
{
    [field: SerializeField] public int status { get; set; }
    [field: SerializeField] public string message { get; set; }
   
}

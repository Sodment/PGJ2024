#if UNITY_EDITOR //By�by przypa� jakby wlecia�o do builda

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Welp nie mam kamery, ale mam klawiatur� spacja b�dzie moim u�miechem
/// instrukcja:
/// - Spacja to u�mie�
/// - Strza�ka w gh�r� to gapi�cy si� NPCt
/// </summary>
public class FakeSmileGen : MonoBehaviour
{ 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.SetSmileState(true);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            Player.SetSmileState(false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Player.TakeSus(5.0f);
        }
    }
}

#endif
#if UNITY_EDITOR //By³by przypa³ jakby wlecia³o do builda

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Welp nie mam kamery, ale mam klawiaturê spacja bêdzie moim uœmiechem
/// instrukcja:
/// - Spacja to uœmieæ
/// - Strza³ka w ghórê to gapi¹cy siê NPCt
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Og�lny koleszka trzymaj�cy dane o graczu.
/// No i jest jeden static no bo hurr durr jeden gracz.
/// </summary>

public static class Player
{
    const float MAX_HP = 10;
    const float HP_REGEN = 1;
    const float MAX_SUS = 5;
    const float SUS_REGEN = 1;

    static float hp = MAX_HP;
    static float sus = MAX_SUS;
    static bool isSmiled = false;

    public static UnityEvent OnLastHPLost;
    public static UnityEvent OnLastSusLost;

    public static void SetSmileState(bool smile)
    {
        isSmiled = smile;
    }

    public static void Update()
    {
        if(isSmiled)
        {
            hp -= Time.deltaTime;
            if(hp < 0)
            {
                OnLastHPLost?.Invoke();
            }
        }
        else if(hp<MAX_HP)
        {
            hp += Time.deltaTime*HP_REGEN;
        }

        if(sus < MAX_SUS)
        {
            sus += Time.deltaTime * SUS_REGEN;
        }
    }

    public static void TakeSus(float susPower)
    {
        if (isSmiled) { return; }

        sus-=susPower*Time.deltaTime;
        if(sus < 0) { OnLastSusLost?.Invoke(); }
    }

    public static float GetHPPercentage()
    {
        return hp / MAX_HP;
    }

    public static float GetSusPercentage()
    {
        return sus / MAX_SUS;
    }

    public static float GetOneMinusSusPercentage() //PG Welp, nie wiem czy w UI pasek sus ma rosn�� czy male� wi�c dam obie opcj�
    {
        return 1.0f - GetSusPercentage();
    }
}
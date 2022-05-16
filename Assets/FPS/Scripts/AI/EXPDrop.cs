using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.AI
{
    public class EXPDrop : MonoBehaviour
    {
        public int exp;
        public void ButtonPress()
        {
            EXPManager.expManager.addXP(exp);
            Debug.Log("XP +" + exp);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using TMPro;

namespace Unity.FPS.AI
{
    public class EXPManager : MonoBehaviour
    {
        public TextMeshProUGUI currentXP_Text, targetXP_Text, currentLevel;
        public int currentXP, targetXP, level;

        public float healBonus = 10;



        public static EXPManager expManager;

        public RectTransform rectTrans;

        public PlayerCharacterController player;

        private void Awake()
        {
            if (expManager == null)
            {
                expManager = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }


        public void addXP(int xp)
        {
            currentXP += xp;
            if (currentXP >= targetXP)
            {
                currentXP = currentXP - targetXP;
                targetXP += targetXP / 10;
                level++;
                targetXP_Text.text = targetXP.ToString();
                currentLevel.text = "Level: " + level.ToString();
                Debug.Log("Level up!");

                LevelUp();
            }
            currentXP_Text.text = currentXP.ToString();
        }

        public void LevelUp()
        {
            Health playerHealth = player.GetComponent<Health>();
            playerHealth.HealBonus(healBonus);
            Debug.Log("Test size");
            rectTrans.sizeDelta = new Vector2(rectTrans.sizeDelta.x + healBonus, rectTrans.sizeDelta.y);
            Debug.Log("Bonus: " + healBonus +" HP");
        }


        private void Start()
        {
            currentXP_Text.text = currentXP.ToString();
            targetXP_Text.text = targetXP.ToString();
            currentLevel.text = "Level: " + level.ToString();
            player = FindObjectOfType<PlayerCharacterController>();
        }

    }
}
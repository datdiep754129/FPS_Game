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
        public TextMeshProUGUI currentLevel;
        public int currentXP, targetXP, level;

        public float healBonus = 15;
        public float Heal = 150;



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
            while (currentXP >= targetXP)
            {
                currentXP = currentXP - targetXP;
                targetXP += targetXP / 10;
                level++;
                currentLevel.text = "Level: " + level.ToString();
                Debug.Log("Level up!");

                LevelUp();
            }
        }

        public void LevelUp()
        {
            Health playerHealth = player.GetComponent<Health>();
            playerHealth.HealBonus(healBonus);
            playerHealth.Heal(Heal);
            //rectTrans.sizeDelta = new Vector2(rectTrans.sizeDelta.x + healBonus, rectTrans.sizeDelta.y);
            Debug.Log("Bonus: " + healBonus +" HP");
        }


        private void Start()
        {
            currentLevel.text = "Level: " + level.ToString();
            player = FindObjectOfType<PlayerCharacterController>();
        }

    }
}
using System;
using System.Collections;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using UnityEngine.UI;
namespace Platformer.Mechanics
{
    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    /// 
    public class Health : MonoBehaviour
    {

       // public Slider slider;
        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP = 1;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        int currentHP;



        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }

        /// <summary>
        /// Decrement the HP of the entity. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        public void Decrement(int val)
        {
            currentHP = Mathf.Clamp(currentHP - val, 0, maxHP);
            //slider.value = currentHP;
            StartCoroutine(DamageAnimation());
            if (currentHP == 0)
            {
                var ev = Schedule<HealthIsZero>();
                ev.health = this;
            }
        }

        /// <summary>
        /// Decrement the HP of the entitiy until HP reaches 0.
        /// </summary>
        public void Die()
        {
            while (currentHP > 0) Decrement(100);
        }

        void Awake()
        {
            currentHP = maxHP;
            //slider.value = currentHP;
        }

        IEnumerator DamageAnimation()
        {
            SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

            for (int i = 0; i < 3; i++)
            {
                foreach (SpriteRenderer sr in srs)
                {
                    Color c = sr.color;
                    c.a = 0;
                    sr.color = c;
                }

                yield return new WaitForSeconds(.1f);

                foreach (SpriteRenderer sr in srs)
                {
                    Color c = sr.color;
                    c.a = 1;
                    sr.color = c;
                }

                yield return new WaitForSeconds(.1f);
            }
        }
    }
}

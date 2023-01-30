using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use

        public float rotSpeed;
        public float speedMultiplier = 1;
        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        /// <summary>
        /// Checks if the car has fallen of the map.
        /// Makes he car move by checking the Horizontal input (a, d etc.) and always goes full speed.
        /// </summary>
        private void FixedUpdate()
        {
            if (transform.position.y < -5)
            {
                if (SceneManager.GetActiveScene().name == "EndlessMode")
                {
                    this.gameObject.GetComponent<EndlessTimeManager>().Finished();
                }
                else
                {
                    GameMenuScript.Restart();
                }
            }
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal") * rotSpeed;
            //float v = CrossPlatformInputManager.GetAxis("Vertical");
            float v = 1 * speedMultiplier;
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DoorScript
{
    [RequireComponent(typeof(AudioSource))]


    public class Door : MonoBehaviour
    {
        public bool open;
        public GameObject player;
        public float smooth = 1.0f;
        float DoorOpenAngle = -90.0f;
        float DoorCloseAngle = 0.0f;
        private AudioSource asource;
        public AudioClip openDoor;
        public AudioClip closeDoor;

        // Use this for initialization
        void Start()
        {
            asource = GetComponent<AudioSource>();
        }

        private bool wasOpen;

        void Update()
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            open = distance < 10;

            if (open)
            {
                var target = Quaternion.Euler(0, DoorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);

                // Only play open sound once when door just opened
                if (!wasOpen)
                {
                    asource.clip = openDoor;
                    asource.Play();
                    wasOpen = true;
                }
            }
            else
            {
                var target = Quaternion.Euler(0, DoorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);

                // Only play close sound once when door just closed
                if (wasOpen)
                {
                    asource.clip = closeDoor;
                    asource.Play();
                    wasOpen = false;
                }
            }
        }
    }
}
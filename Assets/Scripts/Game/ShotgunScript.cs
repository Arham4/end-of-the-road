﻿using UnityEngine;

namespace Game
{
    public class ShotgunScript : MonoBehaviour
    {
        private TriggerableTranslation _backseatTranslation;

        private void Start()
        {
            var backseatTransform = GameObject.Find("Backseat").transform;
            _backseatTranslation = new TriggerableTranslation(Camera.main.gameObject, 
                backseatTransform.position + new Vector3(0, backseatTransform.lossyScale.y * 0.65f, -5), 25);
        }

        private void Update()
        {
            if (GameSingleton.Instance.currentView != View.Shotgun)
            {
                return;
            }
            if (Input.GetKeyDown("space"))
            {
                _backseatTranslation.Trigger();
            }
            _backseatTranslation.Execute(then: () =>
            {
                _backseatTranslation.Reset();
                GameSingleton.Instance.currentView = View.Backseat;
                Debug.Log("current view is now Backseat");
            });
        }
    }
}

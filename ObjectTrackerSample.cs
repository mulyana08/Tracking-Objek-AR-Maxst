﻿/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System.Collections.Generic;
using System.Text;

using maxstAR;

public class ObjectTrackerSample : ARBehaviour
{
    public GameObject scane;
    public GameObject PanelA;
    public GameObject PanelB;
    public AudioSource audioSourceA;
    public AudioSource audioSourceB;

    private Dictionary<string, ObjectTrackableBehaviour> objectTrackablesMap =
    new Dictionary<string, ObjectTrackableBehaviour>();

    private CameraBackgroundBehaviour cameraBackgroundBehaviour = null;

    void Awake()
    {
        Init();

        cameraBackgroundBehaviour = FindObjectOfType<CameraBackgroundBehaviour>();
        if (cameraBackgroundBehaviour == null)
        {
            Debug.LogError("Can't find CameraBackgroundBehaviour.");
            return;
        }
    }

    void Start()
    {
        scane.gameObject.SetActive(true);
        PanelA.gameObject.SetActive(false);
        PanelB.gameObject.SetActive(false);
        objectTrackablesMap.Clear();

        ObjectTrackableBehaviour[] objectTrackables = FindObjectsOfType<ObjectTrackableBehaviour>();
        foreach (var trackable in objectTrackables)
        {
            objectTrackablesMap.Add(trackable.TrackableName, trackable);
            Debug.Log("Trackable add: " + trackable.TrackableName);
        }

        StartCamera();
        TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_OBJECT);
        AddTrackerData();

        // For see through smart glass setting
        if (ConfigurationScriptableObject.GetInstance().WearableType == WearableCalibration.WearableType.OpticalSeeThrough)
        {
            WearableManager.GetInstance().GetDeviceController().SetStereoMode(true);

            CameraBackgroundBehaviour cameraBackground = FindObjectOfType<CameraBackgroundBehaviour>();
            cameraBackground.gameObject.SetActive(false);

            WearableManager.GetInstance().GetCalibration().CreateWearableEye(Camera.main.transform);

            // BT-300 screen is splited in half size, but R-7 screen is doubled.
            if (WearableManager.GetInstance().GetDeviceController().IsSideBySideType() == true)
            {
                // Do something here. For example resize gui to fit ratio
            }
        }
    }

    private void AddTrackerData()
    {
        foreach (var trackable in objectTrackablesMap)
        {
            if (trackable.Value.TrackerDataFileName.Length == 0)
            {
                continue;
            }

            if (trackable.Value.StorageType == StorageType.AbsolutePath)
            {
                TrackerManager.GetInstance().AddTrackerData(trackable.Value.TrackerDataFileName);
            }
            else
            {
                if (Application.platform == RuntimePlatform.Android)
                {
                    Debug.Log("trackable.Value.TrackerDataFileName:" + trackable.Value.TrackerDataFileName);
                    TrackerManager.GetInstance().AddTrackerData(trackable.Value.TrackerDataFileName, true);
                }
                else
                {
                    Debug.Log("trackable.Value.TrackerDataFileName:" + trackable.Value.TrackerDataFileName);
                    TrackerManager.GetInstance().AddTrackerData(Application.streamingAssetsPath + "/" + trackable.Value.TrackerDataFileName);
                }
            }
        }

        TrackerManager.GetInstance().LoadTrackerData();
    }

    private void DisableAllTrackables()
    {
        foreach (var trackable in objectTrackablesMap)
        {
            trackable.Value.OnTrackFail();
        }
    }

    void Update()
    {
        DisableAllTrackables();

        TrackingState state = TrackerManager.GetInstance().UpdateTrackingState();

        cameraBackgroundBehaviour.UpdateCameraBackgroundImage(state);
        TrackingResult trackingResult = state.GetTrackingResult();

        if (trackingResult.GetCount() > 0)
        {
            Debug.Log("test");
            for (int i = 0; i < trackingResult.GetCount(); i++)
            {

                Trackable trackable = trackingResult.GetTrackable(i);
                scane.gameObject.SetActive(false);

                if (!objectTrackablesMap.ContainsKey(trackable.GetName()))
                {
                    return;
                }

                objectTrackablesMap[trackable.GetName()].OnTrackSuccess(trackable.GetId(), trackable.GetName(),
                                                                       trackable.GetPose());
            }

        }
        else
        {
            scane.gameObject.SetActive(true);
            PanelA.gameObject.SetActive(false);
            PanelB.gameObject.SetActive(false);
            audioSourceA.Stop();
            audioSourceB.Stop();
        }
    }

    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            TrackerManager.GetInstance().StopTracker();
            StopCamera();
        }
        else
        {
            StartCamera();
            TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_OBJECT);
            AddTrackerData();
        }
    }

    void OnDestroy()
    {
        objectTrackablesMap.Clear();
        TrackerManager.GetInstance().StopTracker();
        TrackerManager.GetInstance().DestroyTracker();
        StopCamera();
    }
}
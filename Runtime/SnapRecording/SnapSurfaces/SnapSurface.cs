﻿using UnityEngine;

namespace HandPosing.SnapSurfaces
{
    [System.Serializable]
    public abstract class SnapSurfaceData : System.ICloneable
    {
        public abstract System.Type SurfaceType { get; }
        public abstract object Clone();
        public abstract SnapSurfaceData Mirror();
    }

    [System.Serializable]
    public abstract class SnapSurface : MonoBehaviour
    {
        public virtual SnapSurfaceData Data { get => null; set { } }

        protected Transform GripPoint
        {
            get
            {
                return this.transform;
            }
        }

        public Transform relativeTo;

        public virtual Pose MirrorPose(Pose pose)
        {
            return pose;
        }

        public abstract HandPose InvertedPose(HandPose pose);
        public abstract Vector3 NearestPointInSurface(Vector3 targetPosition);

        public abstract Pose MinimalRotationPoseAtSurface(Pose userPose, Pose snapPose);
        public abstract Pose MinimalTranslationPoseAtSurface(Pose userPose, Pose snapPose);
    }
}

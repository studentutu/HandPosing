﻿
namespace HandPosing.TrackingData
{
    public class BasicTrackingCleaner : SkeletonDataDecorator
    {
        public override BoneRotation[] Fingers => _cleanFingers;
        public override BoneRotation Hand => _cleanHand;

        private BoneRotation[] _cleanFingers;
        private BoneRotation _cleanHand;

        private void OnEnable()
        {
            wrapee.OnInitialized += Initialize;
            wrapee.OnUpdated += UpdateBones;
        }

        private void OnDisable()
        {
            wrapee.OnInitialized -= Initialize;
            wrapee.OnUpdated -= UpdateBones;
        }

        private void Initialize()
        {
            _cleanFingers = (BoneRotation[])wrapee.Fingers.Clone();
            _cleanHand = wrapee.Hand;
        }

        private void UpdateBones(float deltaTime)
        {
            for(int i = 0; i < wrapee.Fingers.Length; i++)
            {
                BoneRotation rawBone = wrapee.Fingers[i];
                if (wrapee.IsFingerHighConfidence(rawBone.boneID))
                {
                    _cleanFingers[i] = rawBone;
                }
            }
            if(wrapee.IsHandHighConfidence())
            {
                _cleanHand = wrapee.Hand;
            }
        }
    }
}
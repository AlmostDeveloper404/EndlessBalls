using UnityEngine;

namespace Main
{
    public static class Animations
    {
        public static readonly int Finish = Animator.StringToHash("Finish");

        public static float GetAnimationTime(Animator animator, string animationName)
        {
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            foreach (AnimationClip clip in clips)
            {
                if (clip.name == animationName)
                {
                    return clip.length;
                }
            }
            return default(float);
        }
    }
}


using System;

namespace Spindle.Runtime {
    public class BoolBuffer {
        public bool Value => RemainingFrameCount > 0;
        public int RemainingFrameCount { get; private set; }
        public event Action<int> onTick;

        public void SetForFrames(int frameCount) => RemainingFrameCount = frameCount;

        public void Tick() {
            if (RemainingFrameCount <= 0) {
                return;
            }

            RemainingFrameCount -= 1;
            onTick?.Invoke(RemainingFrameCount);
        }

        public void Clear() => RemainingFrameCount = 0;
    }
}
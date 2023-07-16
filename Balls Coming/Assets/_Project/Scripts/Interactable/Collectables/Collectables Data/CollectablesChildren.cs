using UnityEngine;

namespace BallsComing.Interactable.Collectables.CollectablesData
{
    public class Coin : CollectablesParent
    {
        private Coin(GameObject coin, float speed) : base(coin, speed) { }

        private static Coin instance;
        public static Coin Instance(GameObject coin, float speed)
        {
            if (instance == null) instance = new(coin, speed);
            else instance.SetFields(coin, speed);

            return instance;
        }

        public static Coin GetInstance() { return instance; }

        public override bool IsCoin() { return true; }
    }

    public class Invincibility : CollectablesParent
    {
        private Invincibility(GameObject invincibility, float speed) : base(invincibility, speed) { }

        private static Invincibility instance;
        public static Invincibility Instance(GameObject invincibility, float speed)
        {
            if (instance == null) instance = new(invincibility, speed);
            else instance.SetFields(invincibility, speed);

            return instance;
        }

        public static Invincibility GetInstance() { return instance; }

        public override bool IsInvincibility() { return true; }
    }

    public class Destroyer : CollectablesParent
    {
        private Destroyer(GameObject destroyer, float speed) : base(destroyer, speed) { }

        private static Destroyer instance;
        public static Destroyer Instance(GameObject destroyer, float speed)
        {
            if (instance == null) instance = new(destroyer, speed);
            else instance.SetFields(destroyer, speed);

            return instance;
        }

        public static Destroyer GetInstance() { return instance; }

        public override bool IsDestroyer() { return true; }
    }

    public class Slowdown : CollectablesParent
    {
        private Slowdown(GameObject slow, float speed) : base(slow, speed) { }

        private static Slowdown instance;
        public static Slowdown Instance(GameObject slow, float speed)
        {
            if (instance == null) instance = new(slow, speed);
            else instance.SetFields(slow, speed);

            return instance;
        }

        public static Slowdown GetInstance() { return instance; }

        public override bool IsSlowedowner() { return true; }
    }
}
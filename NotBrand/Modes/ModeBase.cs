using System;
using EloBuddy;
using EloBuddy.SDK;

namespace NotBrand.Modes
{
    public abstract class ModeBase
    {
        protected Spell.Skillshot Q
        {
            get { return SpellManager.Q; }
        }

        protected Spell.Skillshot W
        {
            get { return SpellManager.W; }
        }

        protected Spell.Targeted E
        {
            get { return SpellManager.E; }
        }

        protected Spell.Targeted R
        {
            get { return SpellManager.R; }
        }

        protected int Time { get; private set; }

        public virtual int Delay
        {
            get { return Game.Ping; }
        }

        public bool IsReady()
        {
            return Environment.TickCount > Time + Delay;
        }

        public void SetDelay()
        {
            Time = Environment.TickCount;
        }

        public void RemoveDelay()
        {
            Time = 0;
        }

        public virtual void Draw()
        {
        }

        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
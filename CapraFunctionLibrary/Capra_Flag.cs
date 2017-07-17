using System;

#if !FLAG

namespace Cpr314Lib
{
    public interface ICprFlag
    {
        void Change();
        bool ON();
        bool OFF();
        bool Value { get; set; }
    }

    public class CprFlag : ICprFlag
    {
        protected bool myflag;

        public CprFlag(bool b)
        {
            myflag = b;
        }

        public CprFlag(int i)
        {
            if (i == 0) myflag = false;
            else if (i == 1) myflag = true;
            else throw new ArgumentException("\"i\" neither zero nor one.");
        }

        public void Change()
            => myflag = !myflag;

        public bool ON()
        {
            if (myflag) return false;
            return myflag = true;
        }

        public bool OFF()
        {
            if (!myflag) return false;
            myflag = false;
            return true;
        }

        public bool Value
        {
            get
            {
                return myflag;
            }
            set
            {
                myflag = value;
            }
        }

        public static implicit operator bool(CprFlag f)
            => f.Value;

        public static implicit operator CprFlag(bool b)
            => new CprFlag(b);
    }

    public class CprTrueFlag : CprFlag
    {
        public CprTrueFlag(bool b) : base(b)
        {
            myflag = b;
        }

        public CprTrueFlag(int i) : base(i)
        {
            if (i == 0) myflag = false;
            else if (i == 1) myflag = true;
            else throw new System.ArgumentException("\"i\" neither zero nor one.");
        }

        public new void Change()
        {
            if (!myflag) myflag = true;
        }

        public new bool OFF()
        {
            return false;
        }

        public new bool Value
        {
            get
            {
                return myflag;
            }
            set
            {
                if (value) myflag = true;
            }
        }

        public static implicit operator bool(CprTrueFlag f)
            => f.Value;

        public static implicit operator CprTrueFlag(bool b)
            => new CprTrueFlag(b);
    }

    public class CprFlagE : ICprFlag
    {
        protected bool myflag;

        public CprFlagE(bool b)
        {
            myflag = b;
        }

        public CprFlagE(int i)
        {
            if (i == 0) myflag = false;
            else if (i == 1) myflag = true;
            else throw new System.ArgumentException("\"i\" neither zero nor one.");
        }

        public void Change()
           => myflag = !myflag;

        public bool ON()
        {
            if (myflag) return false;
            return myflag = true;
        }

        public bool OFF()
        {
            if (!myflag) return false;
            myflag = false;
            return true;
        }

        public bool Value
        {
            get
            {
                return myflag;
            }
            set
            {
                myflag = value;
            }
        }

        public static explicit operator bool(CprFlagE f)
            => f.Value;

        public static explicit operator CprFlagE(bool b)
            => new CprFlagE(b);
    }
}

#endif
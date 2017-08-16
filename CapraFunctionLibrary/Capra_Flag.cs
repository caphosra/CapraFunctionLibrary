using System;

#if !FLAG

namespace Cpr314Lib
{
    /// <summary>
    /// CprFlagのInterfaceです。ここを元に作っています。
    /// </summary>
    public interface ICprFlag
    {
        void Change();
        bool ON();
        bool OFF();
        bool Value { get; set; }
    }

    /// <summary>
    /// boolの拡張機能といったところでしょうか。
    /// </summary>
    public class CprFlag : ICprFlag
    {
        protected bool myflag;

        public CprFlag(bool b)
        {
            Value = b;
        }
        public CprFlag(int i)
        {
            if (i == 0) Value = false;
            else if (i == 1) Value = true;
            else throw new ArgumentException("\"i\" neither zero nor one.");
        }

        public void Change()
            => Value = !Value;
        public bool ON()
        {
            if (Value) return false;
            return Value = true;
        }
        public bool OFF()
        {
            if (!Value) return false;
            Value = false;
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

    /// <summary>
    /// 一度Trueにしたら戻せないCprFlagです。
    /// </summary>
    public sealed class CprTrueFlag : CprFlag
    {
        public CprTrueFlag(bool b) : base(b)
        {
            Value = b;
        }
        public CprTrueFlag(int i) : base(i)
        {
            if (i == 0) Value = false;
            else if (i == 1) Value = true;
            else throw new System.ArgumentException("\"i\" neither zero nor one.");
        }

        public new void Change()
        {
            Value = !Value;
        }
        public new bool ON()
        {
            if (!Value) return Value = true;
            else return false;
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

    /// <summary>
    /// 自動でboolにキャストしないCprFlagです。
    /// </summary>
    public class CprFlagE : ICprFlag
    {
        protected bool myflag;

        public CprFlagE(bool b)
        {
            Value = b;
        }
        public CprFlagE(int i)
        {
            if (i == 0) Value = false;
            else if (i == 1) Value = true;
            else throw new System.ArgumentException("\"i\" neither zero nor one.");
        }

        public void Change()
           => Value = !Value;
        public bool ON()
        {
            if (Value) return false;
            return Value = true;
        }
        public bool OFF()
        {
            if (!Value) return false;
            Value = false;
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
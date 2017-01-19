using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Enum;

namespace CommonOperation.BaseClass
{
    public abstract class CommonClass
    {
        public delegate void deleItemChanged(CommonClass changedItem);

        private bool isWrong = false;

        public bool IsWrong
        {
            get { return isWrong; }
            set { isWrong = value; }
        }
        private string whyWrong = "";

        public string WhyWrong
        {
            get { return whyWrong; }
            set { whyWrong = value; }
        }

        public abstract string GetId();
        public abstract string GetTypeName();
        public abstract bool Update(out string err);
        public abstract bool Delete(out string err);
        public abstract void FillThisObject();
        public abstract CommonClass Clone();
        public bool EqualTo(CommonClass others)
        {
            if (others == null)
            {
                return false;
            }
            if (this.IsWrong == true && others.IsWrong == true)
            {
                return true;
            }
            if (this.isWrong == false && others.isWrong == false)
            {
                return this.GetId() == others.GetId() 
                    && !string.IsNullOrEmpty(this.GetId())
                    && !string.IsNullOrEmpty(this.GetId());
            }
            return false;
        }

        public FileBoundingTypes FileBoundingCode = FileBoundingTypes.NULL;
        public string FileBoudingStringShow="";
    }
}

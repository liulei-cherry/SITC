using System;
using System.Collections.Generic;
using System.Text;

namespace CommonOperation.BaseClass
{
    public class Authority
    {
        //string AuthorityId;
        string AuthorityName;
        //下级权限 (自动拥有的权限)
        //获取所有拥有此权限的人.
        //获取所有词权限的功能集合.

        public override string ToString()
        {
            return AuthorityName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return (AuthorityName.Equals(obj.ToString()));
        }

        public Authority()
        {
            
        }
        public Authority(string AuthorityNameIn)
        {
            AuthorityName = AuthorityNameIn;
        }
        /// <summary>
        /// 此权限与管理员权限并不冲突,管理员未必包含普通登录用户权限.
        /// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        /// %%%%%%%%%%%% 暂时处理方案,管理员不具备普通登录用户功能%%%%%%%%%%%%%%%%
        /// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        /// </summary>
        /// <returns></returns>
        public static Authority GetALoginUserAuthority()
        {
            return GetAnAuthority("普通登录用户"); 
        }
        public static Authority GetAnAdminAuthority()
        {
            return GetAnAuthority("系统管理员");
        }      

        //public static Authority GetALoginUserWithoutAdminAuthority()
        //{
        //  return  GetAnAuthority("除管理员外登录用户"); 
        //}

        public static List<Authority> AllAuthorities = new List<Authority>();

        public static Authority GetAnAuthority(string authorityName)
        {
            for (int i = 0; i < AllAuthorities.Count; i++)
            {
                if (AllAuthorities[i].AuthorityName.Equals(authorityName))
                {
                    return AllAuthorities[i];
                }
            }
            AllAuthorities.Add(new Authority(authorityName));
            return AllAuthorities[AllAuthorities.Count - 1];
        }
    }

}

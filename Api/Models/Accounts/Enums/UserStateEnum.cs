using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Models.Accounts.Enums
{
    public enum UserStateEnum
    {
        /// <summary>
        /// ثبت نام شده
        /// </summary>
        Registered=0,
        /// <summary>
        /// ثبت نام تکمیل شده
        /// </summary>
        RegisterCompleted=0,
        /// <summary>
        /// بن شده
        /// </summary>
        Banned=1,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicTools
{
    /// <summary>
    /// 异常类型枚举类
    /// </summary>
    [Serializable]
    public enum ErrorTypeEnum
    {
        /// <summary>
        /// 未知异常
        /// </summary>
        UnknownError,
        /// <summary>
        /// 逻辑异常
        /// </summary>
        BusinessError,
        /// <summary>
        /// 技术异常
        /// </summary>
        TechError
    }
}

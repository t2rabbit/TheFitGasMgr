//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GlareLedSysEfDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Log
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> LogDt { get; set; }
        public string Context { get; set; }
        public Nullable<int> UserType { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> LogType { get; set; }
    }
}

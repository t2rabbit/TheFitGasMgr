//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GlareSysEfDbAndModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class CmdLogs
    {
        public int Id { get; set; }
        public string CmdType { get; set; }
        public Nullable<int> CommDevId { get; set; }
        public Nullable<int> CardInfoId { get; set; }
        public string CmdInfo { get; set; }
        public Nullable<int> Result { get; set; }
        public string ResultInfo { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> IsDetele { get; set; }
    }
}
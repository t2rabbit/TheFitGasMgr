using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LmxPublic
{
    public class DTListFormat
    {
        #region  反射List To DataTable
        /// <summary>
        /// //将List集合类转换成DataTable 
        /// </summary>
        public static DataTable ListToDataTable(IList list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    //获取类型
                    Type colType = pi.PropertyType;
                    //当类型为Nullable<>时
                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        colType = colType.GetGenericArguments()[0];
                    }
                    //通常下,如果是用EF生成的类,都会自带EntityState和EntityKey这两个参数,但是数据里面用不到,故略去
                    //又因为一般ID都是自增长的,所以,ID也可以略去.
                    if (pi.Name != "EntityState" && pi.Name != "EntityKey" && pi.Name != "ID")
                    {
                        result.Columns.Add(pi.Name, colType);
                    }
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        //通常下,如果是用EF生成的类,都会自带EntityState和EntityKey这两个参数,但是数据里面用不到,故略去
                        //又因为一般ID都是自增长的,所以,ID也可以略去.
                        if (pi.Name != "EntityState" && pi.Name != "EntityKey" && pi.Name != "ID")
                        {
                            object obj = pi.GetValue(list[i], null);
                            tempList.Add(obj);
                        }
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
        #endregion

        public class ModelConvertHelper<T> where T : new()  // 此处一定要加上new()
        {

            public static IList<T> ConvertToModel(DataTable dt)
            {

                IList<T> ts = new List<T>();// 定义集合
                Type type = typeof(T); // 获得此模型的类型
                string tempName = "";
                foreach (DataRow dr in dt.Rows)
                {
                    T t = new T();
                    PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
                    foreach (PropertyInfo pi in propertys)
                    {
                        tempName = pi.Name;
                        if (dt.Columns.Contains(tempName))
                        {
                            if (!pi.CanWrite) continue;
                            object value = dr[tempName];
                            if (value != DBNull.Value)
                                pi.SetValue(t, value, null);
                        }
                    }
                    ts.Add(t);
                }
                return ts;
            }
        }
    }
}

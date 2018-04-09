using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace PiPublic
{
    public class ListViewColumnSorter : IComparer
    {
        private int ColumnToSort;// 指定按照哪个列排序      
        private SortOrder OrderOfSort;// 指定排序的方式               
        private CaseInsensitiveComparer ObjectCompare;// 声明CaseInsensitiveComparer类对象，
        public ListViewColumnSorter()// 构造函数
        {
            ColumnToSort = 0;// 默认按第一列排序            
            OrderOfSort = SortOrder.None;// 排序方式为不排序            
            ObjectCompare = new CaseInsensitiveComparer();// 初始化CaseInsensitiveComparer类对象
        }
        // 重写IComparer接口.        
        // <returns>比较的结果.如果相等返回0，如果x大于y返回1，如果x小于y返回-1</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;
            // 将比较对象转换为ListViewItem对象
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;
            // 比较
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            // 根据上面的比较结果返回正确的比较结果
            if (OrderOfSort == SortOrder.Ascending)
            {   // 因为是正序排序，所以直接返回结果
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {  // 如果是反序排序，所以要取负值再返回
                return (-compareResult);
            }
            else
            {
                // 如果相等返回0
                return 0;
            }
        }
        /// 获取或设置按照哪一列排序.        
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }
        /// 获取或设置排序方式.    
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }
}

//
// 用法
//

// 1.构造一个对象
//YD_PUBLIC.ListViewColumnSorter lstColSorter = new YD_PUBLIC.ListViewColumnSorter();
// 2.初始化的时候把LIST的排序对象 
           // listView1.ListViewItemSorter = lstColSorter;
// 3.添加list的列头单击事件



        //private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        //{
        //     if (e.Column == lstColSorter.SortColumn)
        //     {
        //         // 重新设置此列的排序方法.
        //         if (lstColSorter.Order == SortOrder.Ascending)
        //         {
        //             lstColSorter.Order = SortOrder.Descending;
        //         }
        //         else
        //         {
        //             lstColSorter.Order = SortOrder.Ascending;
        //         }
        //     }
        //     else
        //     {
        //         // 设置排序列，默认为正向排序
        //         lstColSorter.SortColumn = e.Column;
        //         lstColSorter.Order = SortOrder.Ascending;
        //     }
        //     // 用新的排序方法对ListView排序
        //     this.listView1.Sort();
        //}

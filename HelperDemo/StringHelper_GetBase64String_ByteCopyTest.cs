using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Diagnostics;  
  
namespace HelperDemo.StringHelper.GetBase64  
{  
    /// <summary>
    /// 暂时得出的结论(conclusion for now): List copy is the fastest
    /// </summary>
    class Program  
    {  
        static int RunCount = 10000;  
  
        static void Main(string[] args)  
        {  
            ArrayCopyTest();  
            BlockCopyTest();  
            ListTest();  
            Console.ReadKey();  
        }  
  
        static void ListTest()  
        {  
            List<byte> byteSource = new List<byte>();  
            byteSource.Add(11);  
            Stopwatch sw = new Stopwatch();  
            sw.Start();  
            for (int i = 0; i < RunCount; i++)  
            {  
                byte[] newData = new byte[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };  
                byteSource.AddRange(newData);  
            }  
            byte[] data = byteSource.ToArray();  
            //byte[] subData = byteSource.Take(100).ToArray();//获取前100个字节  
            //byteSource.RemoveRange(0, 100);//取出后删除  
            //byteSource.GetRange(100, 100);//从下标100开始取100个字节  
            sw.Stop();  
            Console.WriteLine("ListTest " + sw.ElapsedMilliseconds + " 毫秒,数组长度：" + data.Length);  
        }  
  
        static void ArrayCopyTest()  
        {  
            byte[] byteSource = new byte[1] { 11 };  
            Stopwatch sw = new Stopwatch();  
            sw.Start();  
            for (int i = 0; i < RunCount; i++)  
            {  
                byte[] newData = new byte[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };  
                byte[] tmp = new byte[byteSource.Length + newData.Length];  
                Array.Copy(byteSource, tmp, byteSource.Length);  
                Array.Copy(newData, 0, tmp, byteSource.Length, newData.Length);  
                byteSource = tmp;  
            }  
            sw.Stop();  
            Console.WriteLine("ArrayCopyTest " + sw.ElapsedMilliseconds + " 毫秒,数组长度：" + byteSource.Length);  
        }  
  
        static void BlockCopyTest()  
        {  
            byte[] byteSource = new byte[1] { 11 };  
            Stopwatch sw = new Stopwatch();  
            sw.Start();  
            for (int i = 0; i < RunCount; i++)  
            {  
                byte[] newData = new byte[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };  
                byte[] tmp = new byte[byteSource.Length + newData.Length];  
                System.Buffer.BlockCopy(byteSource, 0, tmp, 0, byteSource.Length);  
                System.Buffer.BlockCopy(newData, 0, tmp, byteSource.Length, newData.Length);  
                byteSource = tmp;  
            }  
            sw.Stop();  
            Console.WriteLine("BlockCopyTest " + sw.ElapsedMilliseconds + " 毫秒,数组长度：" + byteSource.Length);  
        }  
    }  
}  

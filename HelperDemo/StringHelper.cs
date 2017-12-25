using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperDemo
{
    public class StringHelper
    {
        public static string GetBase64String(FileStream fs)
        {
            int count = 200;
            int offset = 0;
            List<byte> data = new List<byte>();
            byte[] array = new byte[count];
            while (fs.Read(array, offset, count) > 0)
            {
                data.AddRange(array);
            }
            string base64Str = Convert.ToBase64String(data.ToArray());

            array = null;
            data.Clear();

            return base64Str;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Models
{
    class BanConverter
    {
        public byte[] ToBytes(Ban ban) {
            using (MemoryStream ms = new MemoryStream()) {
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write(ban.Id);
                bw.Write(ban.Status.ToString());
                return ms.ToArray();
            }
        }
        public static Ban FromBytes(byte[] buffer) {
            Ban ban = new Ban();
            using (MemoryStream ms = new MemoryStream(buffer)) {
                BinaryReader br = new BinaryReader(ms);
                ban.Id = br.ReadString();
                ban.Status = int.Parse(br.ReadString());
            }
            return ban;

        }
    }
}

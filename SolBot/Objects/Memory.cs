using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SolBot.Objects
{
    public class Memory
    {
        public Memory(Objects.Client c)
        {
            this.Client = c;
        }

        public Objects.Client Client { get; private set; }

        public byte[] ReadBytes(long address, uint bytesToRead)
        {
           
                IntPtr ptrBytesRead;
                byte[] buffer = new byte[bytesToRead];
                WinAPI.ReadProcessMemory(this.Client.TibiaHandle, new IntPtr(address), buffer, bytesToRead, out ptrBytesRead);
                return buffer;
            
          
        }
        public byte[] ReadBytes(long address, int bytesToRead)
        {
            return this.ReadBytes(address, (uint)bytesToRead);
        }

        public int ReadInt32(long address)
        {
            return BitConverter.ToInt32(this.ReadBytes(address, 4), 0);
        }

        public double ReadDouble(long address)
        {
            return BitConverter.ToDouble(this.ReadBytes(address, 8), 0);
        }

        public bool WriteBytes(long address, byte[] bytes, int length)
        {
            IntPtr bytesWritten;
            int result = WinAPI.WriteProcessMemory(this.Client.TibiaHandle, new IntPtr(address), bytes, length, out bytesWritten);
            return result != 0;
        }
        public bool WriteBytes(long address, byte[] bytes)
        {
            return this.WriteBytes(address, bytes, (int)bytes.Length);
        }
        public bool WriteInt32(long address, int value)
        {
            return this.WriteBytes(address, BitConverter.GetBytes(value), 4);
        }
        public short ReadInt16(long address)
        {
            return BitConverter.ToInt16(this.ReadBytes(address, 2), 0);
        }
        public uint ReadUInt32(long address)
        {
            return BitConverter.ToUInt32(this.ReadBytes(address, 4), 0);
        }
        public ushort ReadUInt16(long address)
        {
            return BitConverter.ToUInt16(this.ReadBytes(address, 2), 0);
        }


        public string ReadString(long address)
        {
            string stringRead = ASCIIEncoding.Default.GetString(this.ReadBytes(address, 32));
            
            int index = stringRead.IndexOf('\0');
            return index >= 0 ? stringRead.Substring(0, index) : stringRead;
        }
        public string ReadStdString(long address)
        {
            int offset = 0x10;
            int lenght = this.ReadUInt16(address + offset);
            if (lenght < 16)
            {
                string stringRead = ASCIIEncoding.Default.GetString(this.ReadBytes(address, 32));

                int index = stringRead.IndexOf('\0');
                return this.ReadString(address);
            }
            else
            {
                int strAddress = this.ReadInt32(address);
                return this.ReadString(strAddress);
                
            }
            
        }

        public int FindDMAAddy(int address, List<int> offsets)
        {
            int addr = address;
            
            for (int i = 0; i < offsets.Count; ++i)
            {
                
                addr += offsets[i];
                addr = ReadInt32(addr);

            }
            return addr;
        }
    }
}

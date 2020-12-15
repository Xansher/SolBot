using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolBot.Objects
{
    public partial class Client
    {
        public class StdString

        {

            public IntPtr StrPointer;
            public int Length;
            public string Str;

           // public int MaxLength;

            public IntPtr BasePointer;

            



            public StdString(string str)

            {

                Str = str;

                Length = str.Length;

                BasePointer = IntPtr.Zero;

                StrPointer = IntPtr.Zero;

            }



            public void Allocate(IntPtr handle)

            {



                IntPtr bytesWritten;

                //Alocate the base of the string which contains either a buffer or a pointer to the string aswell as 4 bytes length and 4 bytes maxLength
                
                BasePointer = WinAPI.VirtualAllocEx(handle, IntPtr.Zero, 0x18, WinAPI.AllocationType.Commit, WinAPI.MemoryProtection.ReadWrite);

               //StrPointer = WinAPI.VirtualAllocEx(handle, IntPtr.Zero, Str.Length, WinAPI.AllocationType.Commit, WinAPI.MemoryProtection.ReadWrite);

                
               


                if (Str.Length < 16)

                {
                    int ptr = (int)BasePointer + 0x8;
                    WinAPI.WriteProcessMemory(handle, BasePointer, BitConverter.GetBytes(ptr), Str.Length, out bytesWritten);
                    //Here we only need to write as "buffer" since the string fits in the base structure
                    WinAPI.WriteProcessMemory(handle, BasePointer + 0x4, BitConverter.GetBytes(Str.Length), 4, out bytesWritten);
                    WinAPI.WriteProcessMemory(handle, BasePointer+0x8, Encoding.ASCII.GetBytes(Str), Str.Length, out bytesWritten);

                }

                else

                {

                    //Here we need to allocate the string somewhere else since it exceeds 16 characters

                    StrPointer = WinAPI.VirtualAllocEx(handle, IntPtr.Zero, Str.Length, WinAPI.AllocationType.Commit, WinAPI.MemoryProtection.ReadWrite);

                    WinAPI.WriteProcessMemory(handle, StrPointer, Encoding.ASCII.GetBytes(Str), Str.Length, out bytesWritten);

                    WinAPI.WriteProcessMemory(handle, BasePointer, BitConverter.GetBytes(StrPointer.ToInt32()), 4, out bytesWritten);

                }





                //Write length and maxlength

               

                //WinAPI.WriteProcessMemory(handle, BasePointer + 0x14, BitConverter.GetBytes(MaxLength), 4, out bytesWritten);

            }



            public void Free(IntPtr handle)

            {

                WinAPI.VirtualFreeEx(handle, BasePointer, 0x18, WinAPI.FreeType.Release);



                //If we allocated another memory space for the pointer, make sure we free that aswell.

                if (StrPointer != IntPtr.Zero)

                    WinAPI.VirtualFreeEx(handle, StrPointer, Str.Length, WinAPI.FreeType.Release);

            }

        }
        static void CallCodeCave(IntPtr handle, byte[] codeCave)

        {

            //This is gonna be the address where we are gonna put our codecave

            IntPtr codeCaveAddress = WinAPI.VirtualAllocEx(handle, IntPtr.Zero, codeCave.Length, WinAPI.AllocationType.Commit, WinAPI.MemoryProtection.ExecuteReadWrite);



            //Write the codecave to the allocated memory space

            IntPtr bytesWritten;

            WinAPI.WriteProcessMemory(handle, codeCaveAddress, codeCave, codeCave.Length, out bytesWritten);



            //Execute the codecave

            IntPtr threadHandle = WinAPI.CreateRemoteThread(handle, IntPtr.Zero, 0, codeCaveAddress, IntPtr.Zero, 0, IntPtr.Zero);



            //Wait for the codecave to complete

            WinAPI.WaitForSingleObject(threadHandle, 0xFFFFFFFF);



            //Free the codecave memory and close the thread

            WinAPI.CloseHandle(threadHandle);

            WinAPI.VirtualFreeEx(handle, codeCaveAddress, codeCave.Length, WinAPI.FreeType.Release);

        }

        public class FunctionCollection
        {

           
            public FunctionCollection(Objects.Client c)
            {
                this.Client = c;
            }

            public Objects.Client Client { get; private set; }

            public void SendChangeFightModes(int fightMode, int chaseMode, int safeFight, int pvpMode) //0-no chase, 1-chase
            {
                int baseAddress = this.Client.TibiaProcess.MainModule.BaseAddress.ToInt32();
                int functionAddress = 0x287810 + baseAddress;

                int objectAddress = 0x48D524 + baseAddress;

                byte[] object_pointer = new byte[4];

                int getChaseMode = 0x48D574 + baseAddress;

                this.Client.Memory.WriteInt32(getChaseMode, 1);

                IntPtr bytesRead;

                WinAPI.ReadProcessMemory(this.Client.TibiaHandle, new IntPtr(objectAddress), object_pointer, 4, out bytesRead);

                /* byte[] cCave = {
                                       0xB9, 0x00, 0x00, 0x00, 0x00, //MOV ECX, objectPointer

                                       0xB8, 0x00, 0x00, 0x00, 0x00, //MOV EAX, functionAddress

                                       0xFF, 0xD0,                   //CALL EAX

                                       0xC2, 0x04, 0x00                          //RETN
                 };
                 Array.Copy(object_pointer, 0, codeCave, 21, 4);
                 Array.Copy(BitConverter.GetBytes(functionAddress), 0, codeCave, 26, 4);
                 */
                byte[] codeCave = {

                                      0x68, 0x00, 0x00, 0x00, 0x00, //PUSH fightMode

                                      0x68, 0x00, 0x00, 0x00, 0x00, //PUSH mode

                                      0x68, 0x00, 0x00, 0x00, 0x00, //PUSH mode

                                      0x68, 0x00, 0x00, 0x00, 0x00, //PUSH mode

                                      0xB9, 0x00, 0x00, 0x00, 0x00, //MOV ECX, objectPointer

                                      0xB8, 0x00, 0x00, 0x00, 0x00, //MOV EAX, functionAddress

                                      0xFF, 0xD0,                   //CALL EAX

                                      0xC2, 0x10, 0x00                          //RETN

                                  };

                Array.Copy(BitConverter.GetBytes(pvpMode), 0, codeCave, 1, 4);
                Array.Copy(BitConverter.GetBytes(safeFight), 0, codeCave, 6, 4);
                Array.Copy(BitConverter.GetBytes(chaseMode), 0, codeCave, 11, 4);
                Array.Copy(BitConverter.GetBytes(fightMode), 0, codeCave, 16, 4);
                Array.Copy(object_pointer, 0, codeCave, 21, 4);
                Array.Copy(BitConverter.GetBytes(functionAddress), 0, codeCave, 26, 4);
                CallCodeCave(this.Client.TibiaHandle, codeCave);

            }

            //public void SendChange(int chaseMode) //0-no chase, 1-chase
            //{
            //    int baseAddress = this.Client.TibiaProcess.MainModule.BaseAddress.ToInt32();
            //    int functionAddress = 0x240500 + baseAddress;

            //    int objectAddress = 0x48D510 + baseAddress;

            //    byte[] object_pointer = new byte[4];

            //    IntPtr bytesRead;

            //    WinAPI.ReadProcessMemory(this.Client.TibiaHandle, new IntPtr(objectAddress), object_pointer, 4, out bytesRead);
            //    int one = 0x9FF384;
            //        int two = 0x1336305;

            //    byte[] codeCave = {

            //                          //0x68, 0x00, 0x00, 0x00, 0x00, //PUSH mode

            //                         // 0x68, 0x00, 0x00, 0x00, 0x00, //PUSH mode

            //                          0x68, 0x00, 0x00, 0x00, 0x01, //PUSH mode

            //                          0xB9, 0x00, 0x00, 0x00, 0x00, //MOV ECX, objectPointer

            //                          0xB8, 0x00, 0x00, 0x00, 0x00, //MOV EAX, functionAddress

            //                          0xFF, 0xD0,                   //CALL EAX

            //                          0xC2, 0x04, 0x00                         //RETN

            //                      };

            //    Array.Copy(BitConverter.GetBytes(chaseMode), 0, codeCave, 1, 4);
            //   // Array.Copy(BitConverter.GetBytes(one), 0, codeCave, 6, 4);            
            //    //Array.Copy(BitConverter.GetBytes(two), 0, codeCave, 11, 4);
            //    Array.Copy(BitConverter.GetBytes(functionAddress), 0, codeCave, 5, 4);
            //    Array.Copy(BitConverter.GetBytes(functionAddress), 0, codeCave, 11, 4);
            //    CallCodeCave(this.Client.TibiaHandle, codeCave);

            //}

            public void SendTurn(int Direction) {
                int baseAddress = this.Client.TibiaProcess.MainModule.BaseAddress.ToInt32();
                int functionAddress = 0x244660 + baseAddress;

                int objectAddress = 0x48D510 + baseAddress;
                byte[] object_pointer = new byte[4];

                IntPtr bytesRead;

                WinAPI.ReadProcessMemory(this.Client.TibiaHandle, new IntPtr(objectAddress), object_pointer, 4, out bytesRead);

                byte[] codeCave = {
                                      0x68, 0x00, 0x00, 0x00, 0x00, //PUSH message
                                      0xB9, 0x00, 0x00, 0x00, 0x00, //MOV ECX, objectPointer

                                      0xB8, 0x00, 0x00, 0x00, 0x00, //MOV EAX, functionAddress

                                      0xFF, 0xD0,                   //CALL EAX

                                      0xC2,                          //RETN

                                  };

                Array.Copy(BitConverter.GetBytes(Direction), 0, codeCave, 1, 4);
                Array.Copy(object_pointer, 0, codeCave, 6, 4);

                Array.Copy(BitConverter.GetBytes(functionAddress), 0, codeCave, 11, 4);
                CallCodeCave(this.Client.TibiaHandle, codeCave);
            }



            public void SendAttack(int uid, int seq)
            {
                int baseAddress = this.Client.TibiaProcess.MainModule.BaseAddress.ToInt32();

                int functionAddress = 0x287660 + baseAddress;

                int objectAddress = 0x48D524 + baseAddress;
                /* Getting real object address by reading the static reference */

                byte[] object_pointer = new byte[4];

                IntPtr bytesRead;

                WinAPI.ReadProcessMemory(this.Client.TibiaHandle, new IntPtr(objectAddress), object_pointer, 4, out bytesRead);

                byte[] codeCave = {


                                      0x68, 0x00, 0x00, 0x00, 0x00, //PUSH seq

                                      0x68, 0x00, 0x00, 0x00, 0x00, //PUSH uid

                                      0xB9, 0x00, 0x00, 0x00, 0x00, //MOV ECX, objectPointer

                                      0xB8, 0x00, 0x00, 0x00, 0x00, //MOV EAX, functionAddress

                                      0xFF, 0xD0,                   //CALL EAX

                                      0xC2,                          //RETN

                                  };

                Array.Copy(BitConverter.GetBytes(seq), 0, codeCave, 1, 4);

                Array.Copy(BitConverter.GetBytes(uid), 0, codeCave, 6, 4);

                Array.Copy(object_pointer, 0, codeCave, 11, 4);

                Array.Copy(BitConverter.GetBytes(functionAddress), 0, codeCave, 16, 4);
                CallCodeCave(this.Client.TibiaHandle, codeCave);
            }

            //268448289

                public void SendTalk(StdString message, StdString receiver, int mode, int channel)
            {
                int baseAddress = this.Client.TibiaProcess.MainModule.BaseAddress.ToInt32();

                int functionAddress = 0x11E680 + baseAddress;

                int objectAddress = 0x687E8C + baseAddress;
                


                /* Getting real object address by reading the static reference */

                byte[] object_pointer = new byte[4];

                IntPtr bytesRead;

                WinAPI.ReadProcessMemory(this.Client.TibiaHandle, new IntPtr(objectAddress), object_pointer, 4, out bytesRead);



                //Allocate our strings in Medivias memory

                message.Allocate(this.Client.TibiaHandle);

                receiver.Allocate(this.Client.TibiaHandle);



                byte[] message_pointer = BitConverter.GetBytes(message.BasePointer.ToInt32());

                byte[] receiver_pointer = BitConverter.GetBytes(receiver.BasePointer.ToInt32());

                /* Constructing the skeleton of the codecave */



                byte[] codeCave = {

                                      0x68, 0x00, 0x00, 0x00, 0x00, //PUSH message

                                      0x68, 0x00, 0x00, 0x00, 0x00, //PUSH receiver

                                      0x68, 0x00, 0x00, 0x00, 0x00, //PUSH channel

                                      0x68, 0x00, 0x00, 0x00, 0x00, //PUSH mode

                                      0xB9, 0x00, 0x00, 0x00, 0x00, //MOV ECX, objectPointer

                                      0xB8, 0x00, 0x00, 0x00, 0x00, //MOV EAX, functionAddress

                                      0xFF, 0xD0,                   //CALL EAX

                                      0xC2,                          //RETN

                                  };







                //Copy our values to codeCave

                Array.Copy(message_pointer, 0, codeCave, 1, 4);

                Array.Copy(receiver_pointer, 0, codeCave, 6, 4);

                Array.Copy(BitConverter.GetBytes(channel), 0, codeCave, 11, 4);

                Array.Copy(BitConverter.GetBytes(mode), 0, codeCave, 16, 4);

                Array.Copy(object_pointer, 0, codeCave, 21, 4);

                Array.Copy(BitConverter.GetBytes(functionAddress), 0, codeCave, 26, 4);
                CallCodeCave(this.Client.TibiaHandle, codeCave);



                //Free the strings

                receiver.Free(this.Client.TibiaHandle);

                message.Free(this.Client.TibiaHandle);
            }
        }

        
    }
}

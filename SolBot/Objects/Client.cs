using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;

namespace SolBot.Objects
{
    public partial class Client
    {

        public Client(Process p, bool useThisClient = false)
        {
            this.CtrlPressed = false;
            this.TibiaProcess = p;
            this.TibiaHandle = p.Handle;
            if (useThisClient) this.LoadProperties();

        }
        #region properties 
        public Process TibiaProcess { get; private set; }
        public Boolean CtrlPressed { get;  set; }
        public IntPtr TibiaHandle { get; private set; }
        public Objects.Addresses Addresses { get; set; }
        public Objects.Memory Memory { get; private set; }
        public Objects.Player Player { get; private set; }
        public ModuleCollection Modules { get; private set; }
        public FunctionCollection Functions { get; private set; }
        #endregion

        public void LoadProperties(bool loadObjectProperties = true)
        {
            this.Modules = new ModuleCollection(this);
            this.Player = new Objects.Player(this);
            this.Memory = new Objects.Memory(this);
            this.Addresses = new Objects.Addresses(this);
            this.Functions = new Objects.Client.FunctionCollection(this);
            
        }


    }
   

}

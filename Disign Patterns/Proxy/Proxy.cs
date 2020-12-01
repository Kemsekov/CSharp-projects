using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

/*
Proxy призван имитировать поведение объекта.. Я пока не разичаю его от декоратора, 
но тут вроде правильно написано всё.
*/

namespace TemporaryProj.Proxy{
    interface IAcessor{
        string GetName();
    }
    class CurrentMachine : IAcessor{
        public string GetName(){
            return "I am here";
        }
    }

    class RemoteMachine : IAcessor, IDisposable{
        public Socket socket;
        public Socket RemoteSocket;
        IPEndPoint EndLocal;
        IPEndPoint EndRemote;
        public RemoteMachine(string ip = "",int port = 0)
        {
            //new socket with IPv4 TCP
            socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            
            //get local ip adress - by default is 0.0.0.0
            var addr = IPAddress.Parse("0.0.0.0");
            
            //create new EndPoint with local ip and hope that port 50001 is forwarded to current machine
            EndLocal = new IPEndPoint(addr,50001);

            //binding socket to local endpoint : 0.0.0.0:50001
            socket.Bind(EndLocal);

            //if we know remote device then we can create remote end point
            if(ip!="" && port>0)
            try{

            EndRemote = new IPEndPoint(IPAddress.Parse(ip),port);

            }
            catch(FormatException ex){
                System.Console.WriteLine("From RemoteMachine - FormatException\n",ip," must be IPv4");
            }
        }

        public void Dispose()
        {
            socket.Disconnect(true);
            socket.Dispose();
            if(RemoteSocket!=null){
            RemoteSocket.Disconnect(true);
            RemoteSocket.Dispose();
            }
        }

        public string GetName(){

            StringBuilder builder = new StringBuilder();

            //we create buffer for receiveiving data from remote device
            byte[] buff = new byte[256];

            //We say to socket how big our buffer is
            socket.ReceiveBufferSize = 256;

            //We say to socket that we can queue only 5 requests for connection at the same time
            //this method will freeze program until someone try to connect to us
            socket.Listen(5);
            //we accept everything and everyone that try to connect to us
            RemoteSocket = socket.Accept();
            
            //across RemoteSocket we can recive and send data from and to remote device

            string str="";

            //This will loop until command stop is send to us
            //why "stopo" in if statement? IDK but every "stop" message always transform in "stopo"
            while(true){
                RemoteSocket.Receive(buff);
                str = new string(Encoding.UTF8.GetChars(buff)).Trim('\0');
                builder.Append(str);
                if(RemoteSocket.Available==0)
                break;
            }

            return builder.ToString().Trim();
            }

        }
    
    class Machine : IAcessor
    {
        public IAcessor acessor;
        public Machine(IAcessor acessor)
        {
            this.acessor = acessor;
        }
        public string GetName()
        {
            System.Console.WriteLine("Hello from proxy!");
            return acessor.GetName();
        }
    }
}
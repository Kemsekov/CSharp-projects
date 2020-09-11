using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

/*
Proxy призван имитировать поведение объекта.. Я пока не разичаю его от декоратора, 
но тут вроде правильно написано всё.
*/

namespace TemporaryProj.Proxy{
    interface IAcessor{
        public string GetName();
    }
    class CurrentMachine : IAcessor{
        public string GetName(){
            return "I am here";
        }
    }

    class RemoteMachine : IAcessor{
        public Socket socket;
        Socket RemoteSocket;
        IPEndPoint EndLocal;
        IPEndPoint EndRemote;
        public RemoteMachine(string ip,int port)
        {
            socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            var addr = IPAddress.Parse("0.0.0.0");
            EndLocal = new IPEndPoint(addr,50001);
            socket.Bind(EndLocal);

            if(ip!="")
            try{

            EndRemote = new IPEndPoint(IPAddress.Parse(ip),port);

            }
            catch(FormatException ex){
                System.Console.WriteLine("From RemoteMachine - FormatException\n",ip," must be IPv4");
            }
            
            
        }
        public string GetName(){
            StringBuilder builder = new StringBuilder();
            byte[] buff = new byte[16];
            socket.Listen(5);
            socket.ReceiveBufferSize = 16;
            RemoteSocket = socket.Accept();
            
            var count = RemoteSocket.Receive(buff);
            string str="";
            while(true){
                
                str = new string(Encoding.UTF8.GetChars(buff)).Trim('\0');
                if(str=="stopo") break;
                builder.Append(str);
                count = RemoteSocket.Receive(buff);
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
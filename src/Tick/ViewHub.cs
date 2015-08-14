using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Tick.Repository;
using Tick.Response;
using Tick.Rx;

namespace Tick.Hubs
{
         [HubName("viewHub")]
        public class ViewHub : Hub
	{
                private StreamProvider _streamProvider;
        	public ViewHub()
        	{
                        Console.WriteLine("hub created!");
                        //Task.Factory.StartNew(Publish);
                        if (_streamProvider == null)
                        {
                                _streamProvider = new StreamProvider((res =>{
                                        Clients.All.updateStockPrice(new []{res});
                                }));
                                _streamProvider.Initialize();  
                        }
                        
        	}
                
                public override Task OnConnected()
                {
                    Console.WriteLine("Client Connected!");
                    return Task.Delay(1);
                }
                
                public void Notify(ViewResponse response)
                {
                        Clients.All.updateStockPrice(new []{response});
                }
	}
}
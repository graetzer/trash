//  
//  IACServer.cs
//  
//  Author:
//       Simon Grätzer <simon.graetzer@googlemail.com>
// 
//  Copyright (c) 2010 Simon Grätzer
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using IAC;

namespace IAC.CsHTTPServer
{
	public class IACServer : CsHTTPServer
	{
        public Messwertverwaltung mwv;
        RS232COM ComPort;

        public IACServer(int port, Messwertverwaltung mwv, RS232COM com) : base(port) { this.mwv = mwv; this.ComPort = com; }

		public override void OnResponse(ref HTTPRequestStruct request, ref HTTPResponseStruct rp){
			Console.WriteLine(request.URL);
			String[] urlParts = request.URL.Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
			Console.WriteLine(urlParts.Length);
            rp.Headers.Add("Content-Type", "text/plain; charset=utf-8");
			
            if (urlParts.Length == 0)
            {
                MemoryStream o = new MemoryStream();
                StreamWriter writer = new StreamWriter(o);
                //writer.WriteLine("\tTemperatur:\n");
                //writer.Write(mwv.GetTemperaturList());

                //writer.WriteLine("\tLichtstärke:\n");
                //writer.Write(mwv.GetLichtList());
                //writer.Write("1\n2\n3\n4\n5\n6\n7\n8\n9\n10");
                //writer.Close();
                //rp.BodyData = o.GetBuffer();
                //o.Close();

                char [] chars = mwv.GetLichtList().ToCharArray();
                byte [] bytes = new byte [chars.Length];
                for(int i = 0; i < chars.Length; i++) {
                    bytes[i] = (byte) chars[i];
                }

                rp.BodyData = bytes;
                //writer.WriteLine("\tFeuchtigkeit:\n");
                //writer.Write(mwv.GetFeuchtigkeitList());

                //writer.WriteLine("\tDünger:\n");
                //writer.Write(mwv.GetDüngerList());
            }
            else if (urlParts.Length >= 4)
            {
                //http://ip/action/duration/movement/width
                String action = urlParts[0];
                String duration = urlParts[1];
                String movement = urlParts[2];
                String width = urlParts[3];

                byte send = (byte)((Convert.ToInt16(duration) >> 1) & 0x1F);
                if (action == "false")
                    send |= 0x20;
                this.ComPort.WriteData(send);
                Thread.Sleep(100);
                this.ComPort.WriteData((byte)((Convert.ToInt16(movement) * 256) / 360));
                Thread.Sleep(100);
                this.ComPort.WriteData((byte)(Convert.ToInt16(width) >> 1));

            }
		}
	}
}


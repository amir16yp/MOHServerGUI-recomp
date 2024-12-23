using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;

namespace MOHServer
{
    public class UPnPPortMapper
    {
        private const string SEARCH_MESSAGE =
            "M-SEARCH * HTTP/1.1\r\n" +
            "HOST: 239.255.255.250:1900\r\n" +
            "ST: upnp:rootdevice\r\n" +
            "MAN: \"ssdp:discover\"\r\n" +
            "MX: 3\r\n\r\n";

        private string controlURL;
        private string serviceType;
        private string confirmedIPAddress;

        public class PortMapping
        {
            public string RemoteHost { get; set; }
            public int ExternalPort { get; set; }
            public string Protocol { get; set; }
            public int InternalPort { get; set; }
            public string InternalClient { get; set; }
            public bool Enabled { get; set; }
            public string Description { get; set; }
            public int LeaseDuration { get; set; }

            public override string ToString()
            {
                return $"Port Mapping Details:\n" +
                       $"Remote Host: {RemoteHost}\n" +
                       $"External Port: {ExternalPort}\n" +
                       $"Protocol: {Protocol}\n" +
                       $"Internal Port: {InternalPort}\n" +
                       $"Internal Client: {InternalClient}\n" +
                       $"Enabled: {Enabled}\n" +
                       $"Description: {Description}\n" +
                       $"Lease Duration: {LeaseDuration} seconds\n";
            }
        }

        public bool Initialize()
        {
            if (!DiscoverRouter())
                return false;

            string detectedIP = GetLocalIPAddress();

            using (Form ipDialog = new Form())
            {
                ipDialog.Text = "Confirm IP Address";
                ipDialog.Size = new Size(300, 150);
                ipDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                ipDialog.StartPosition = FormStartPosition.CenterScreen;
                ipDialog.MaximizeBox = false;
                ipDialog.MinimizeBox = false;

                TextBox ipTextBox = new TextBox
                {
                    Text = detectedIP,
                    Location = new Point(20, 40),
                    Size = new Size(240, 20)
                };

                Label label = new Label
                {
                    Text = "Is this your correct local IP address?",
                    Location = new Point(20, 15),
                    Size = new Size(240, 20)
                };

                Button okButton = new Button
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new Point(95, 70),
                    Size = new Size(75, 23)
                };

                Button cancelButton = new Button
                {
                    Text = "Cancel",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(185, 70),
                    Size = new Size(75, 23)
                };

                ipDialog.Controls.AddRange(new Control[] { label, ipTextBox, okButton, cancelButton });
                ipDialog.AcceptButton = okButton;
                ipDialog.CancelButton = cancelButton;

                if (ipDialog.ShowDialog() == DialogResult.OK)
                {
                    confirmedIPAddress = ipTextBox.Text.Trim();
                    return true;
                }
                return false;
            }
        }

        private bool DiscoverRouter()
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);

                byte[] data = Encoding.ASCII.GetBytes(SEARCH_MESSAGE);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("239.255.255.250"), 1900);

                socket.SendTo(data, endPoint);

                byte[] buffer = new byte[8192];
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint senderEP = (EndPoint)sender;

                while (true)
                {
                    int recv = socket.ReceiveFrom(buffer, ref senderEP);
                    string response = Encoding.ASCII.GetString(buffer, 0, recv);

                    if (response.Contains("upnp:rootdevice"))
                    {
                        string location = GetHeaderValue(response, "LOCATION");
                        if (!string.IsNullOrEmpty(location))
                        {
                            return ParseDeviceDescription(location);
                        }
                    }
                }
            }
            catch (SocketException)
            {
                return false;
            }
        }

        private string GetHeaderValue(string response, string header)
        {
            foreach (string line in response.Split(new[] { "\r\n" }, StringSplitOptions.None))
            {
                if (line.StartsWith(header + ":"))
                {
                    return line.Substring(header.Length + 1).Trim();
                }
            }
            return null;
        }

        private bool ParseDeviceDescription(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string description = client.DownloadString(url);

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(description);

                    XmlNamespaceManager nsMgr = new XmlNamespaceManager(doc.NameTable);
                    nsMgr.AddNamespace("ns", "urn:schemas-upnp-org:device-1-0");

                    XmlNode serviceNode = doc.SelectSingleNode("//ns:service[ns:serviceType='urn:schemas-upnp-org:service:WANIPConnection:1']", nsMgr);
                    if (serviceNode != null)
                    {
                        serviceType = serviceNode.SelectSingleNode("ns:serviceType", nsMgr).InnerText;
                        controlURL = serviceNode.SelectSingleNode("ns:controlURL", nsMgr).InnerText;

                        if (!controlURL.StartsWith("http"))
                        {
                            Uri uri = new Uri(url);
                            controlURL = new Uri(uri, controlURL).ToString();
                        }
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool AddPortMapping(int externalPort, int internalPort, string protocol, string description)
        {
            if (string.IsNullOrEmpty(controlURL) || string.IsNullOrEmpty(serviceType) || string.IsNullOrEmpty(confirmedIPAddress))
                return false;

            string action =
                "<?xml version=\"1.0\"?>" +
                "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" s:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">" +
                "<s:Body>" +
                "<u:AddPortMapping xmlns:u=\"" + serviceType + "\">" +
                "<NewRemoteHost></NewRemoteHost>" +
                "<NewExternalPort>" + externalPort + "</NewExternalPort>" +
                "<NewProtocol>" + protocol + "</NewProtocol>" +
                "<NewInternalPort>" + internalPort + "</NewInternalPort>" +
                "<NewInternalClient>" + confirmedIPAddress + "</NewInternalClient>" +
                "<NewEnabled>1</NewEnabled>" +
                "<NewPortMappingDescription>" + description + "</NewPortMappingDescription>" +
                "<NewLeaseDuration>0</NewLeaseDuration>" +
                "</u:AddPortMapping>" +
                "</s:Body>" +
                "</s:Envelope>";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(controlURL);
                request.Method = "POST";
                request.ContentType = "text/xml";
                request.Headers.Add("SOAPACTION", "\"" + serviceType + "#AddPortMapping\"");

                using (Stream stream = request.GetRequestStream())
                {
                    byte[] data = Encoding.UTF8.GetBytes(action);
                    stream.Write(data, 0, data.Length);
                }

                using (WebResponse response = request.GetResponse())
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<PortMapping> GetPortMappings()
        {
            List<PortMapping> mappings = new List<PortMapping>();
            int index = 0;

            while (true)
            {
                try
                {
                    string action =
                        "<?xml version=\"1.0\"?>" +
                        "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" s:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">" +
                        "<s:Body>" +
                        "<u:GetGenericPortMappingEntry xmlns:u=\"" + serviceType + "\">" +
                        "<NewPortMappingIndex>" + index + "</NewPortMappingIndex>" +
                        "</u:GetGenericPortMappingEntry>" +
                        "</s:Body>" +
                        "</s:Envelope>";

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(controlURL);
                    request.Method = "POST";
                    request.ContentType = "text/xml";
                    request.Headers.Add("SOAPACTION", "\"" + serviceType + "#GetGenericPortMappingEntry\"");

                    using (Stream stream = request.GetRequestStream())
                    {
                        byte[] data = Encoding.UTF8.GetBytes(action);
                        stream.Write(data, 0, data.Length);
                    }

                    using (WebResponse response = request.GetResponse())
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string responseXml = reader.ReadToEnd();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(responseXml);

                        XmlNamespaceManager nsMgr = new XmlNamespaceManager(doc.NameTable);
                        nsMgr.AddNamespace("s", "http://schemas.xmlsoap.org/soap/envelope/");
                        nsMgr.AddNamespace("u", "urn:schemas-upnp-org:service:WANIPConnection:1");

                        string basePath = "//u:GetGenericPortMappingEntryResponse/";

                        int externalPort = 0;
                        int.TryParse(GetXmlValue(doc, basePath + "NewExternalPort", nsMgr), out externalPort);

                        int internalPort = 0;
                        int.TryParse(GetXmlValue(doc, basePath + "NewInternalPort", nsMgr), out internalPort);

                        int leaseDuration = 0;
                        int.TryParse(GetXmlValue(doc, basePath + "NewLeaseDuration", nsMgr), out leaseDuration);

                        mappings.Add(new PortMapping
                        {
                            RemoteHost = GetXmlValue(doc, basePath + "NewRemoteHost", nsMgr),
                            ExternalPort = externalPort,
                            Protocol = GetXmlValue(doc, basePath + "NewProtocol", nsMgr),
                            InternalPort = internalPort,
                            InternalClient = GetXmlValue(doc, basePath + "NewInternalClient", nsMgr),
                            Enabled = GetXmlValue(doc, basePath + "NewEnabled", nsMgr) == "1",
                            Description = GetXmlValue(doc, basePath + "NewPortMappingDescription", nsMgr),
                            LeaseDuration = leaseDuration
                        });
                    }

                    index++;
                }
                catch (WebException e)
                {
                    if (!(e.Response is HttpWebResponse response && response.StatusCode == HttpStatusCode.NotFound))
                    {
                        MessageBox.Show("Error retrieving port mappings: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unexpected error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            return mappings;
        }

        private string GetXmlValue(XmlDocument doc, string xpath, XmlNamespaceManager nsMgr)
        {
            XmlNode node = doc.SelectSingleNode(xpath, nsMgr);
            return node != null ? node.InnerText : string.Empty;
        }

        private string GetLocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }
    }
}
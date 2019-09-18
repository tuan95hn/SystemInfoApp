using System;
using System.Management;
using CodePoints;
using System.IO;

namespace SystemInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\tuan95hn\Documents\Visual Studio 2015\Projects\SystemInfoApp\SystemInfoApp\bin\Debug\version.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("\n*Current version : 1.0.0");
            }
            string readText = File.ReadAllText(path);
            Console.WriteLine("\n*Current version : " + readText);
            ManagementObjectSearcher searcher;
            int c = 0;
            while ((c = GetOpt.GetOptions(args, "i:")) != (-1))
            {
                switch ((char)c)
                {
                    case 'i':
                        switch ((String)args[1])
                        {
                            case "serialmainboard":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    Console.WriteLine(queryObj["SerialNumber"]);
                                }
                                break;
                            case "computername":
                                Console.WriteLine(Environment.MachineName);
                                break;
                            case "accountlogin":
                                Console.WriteLine(Environment.UserName);
                                break;
                            case "bios":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    Console.WriteLine("Name:" + queryObj["Name"] + "\n" + "SerialNumBer :" + queryObj["SerialNumber"] + "\n" + "Version: " + queryObj["Version"]
                                            + "\n" + "Caption: " + queryObj["Caption"] + "\n" + "CurrentLanguage: " + queryObj["CurrentLanguage"]
                                            + "\n" + "Description: " + queryObj["Description"] + "\n" + "EmbeddedControllerMajorVersion: " + queryObj["EmbeddedControllerMajorVersion"]
                                            + "\n" + "ReleaseDate: " + queryObj["ReleaseDate"] + "\n" + "Install Date: " + queryObj["InstallDate"]);
                                }
                                break;
                            case "network":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_NetworkAdapterConfiguration");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    Console.WriteLine("IPAddress: " + queryObj["IPAddress"] + "\n" + "DNSHostName: " + queryObj["DNSHostName"]
                                         + "\n" + "IPConnectionMetric: " + queryObj["IPConnectionMetric"] + "\n" + "DefaultTTL: " + queryObj["DefaultTTL"]
                                         + "\n" + "Description: " + queryObj["Description"] + "\n" + "SettingID: " + queryObj["SettingID"] + "\n" 
                                         + "MACAddress: " + queryObj["MACAddress"] + "\n" + "Caption: " + queryObj["Caption"] + "\n" + "DatabasePath: " + queryObj["DatabasePath"]);

                                }
                                break;
                            case "cpu":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    Console.WriteLine("Name:" + queryObj["Name"] + "\n"
                                        + "Number of core: " + queryObj["NumberOfCores"] + "\n" + "Number Of LogicalProcessors: " + queryObj["NumberOfLogicalProcessors"]
                                        + "\n" + "ThreadCount: " + queryObj["ThreadCount"] + "\n" + "Caption: " + queryObj["Caption"] + "\n" +
                                        "AddressWidth: " + queryObj["AddressWidth"] + "\n" + "ProcessorId: " + queryObj["ProcessorId"] + "\n"
                                        + "Role: " + queryObj["Role"] + "\n" + "SocketDesignation: " + queryObj["SocketDesignation"] + "\n" +
                                        "SystemCreationClassName: " + queryObj["SystemCreationClassName"]);
                                }
                                break;
                            case "main":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    Console.WriteLine("SerialNumber: " + queryObj["SerialNumber"] + "\n" + "Product: " + queryObj["Product"]
                                        + "\n" + "CreationClassName: " + queryObj["CreationClassName"] + "\n" + "Version: " + queryObj["Version"]);
                                }
                                break;
                            case "graphic":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    Console.WriteLine("AdapterCompatibility: " + queryObj["AdapterCompatibility"] + "\n" +
                                        "AdapterRAM: " + queryObj["AdapterRAM"] + "\n" + "CurrentBitsPerPixel: " + queryObj["CurrentBitsPerPixel"]
                                        + "\n" + "CurrentRefreshRate: " + queryObj["CurrentRefreshRate"] + "\n" +
                                        "CurrentNumberOfColors: " + queryObj["CurrentNumberOfColors"] + "\n" + "Name: " + queryObj["Name"] + "\n" +
                                        "VideoModeDescription: " + queryObj["VideoModeDescription"]);
                                }
                                break;
                            case "memory":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    Console.WriteLine("Capacity: " + queryObj["Capacity"] + "\n" + "DataWidth: " + queryObj["DataWidth"]
                                        + "\n" + "MemoryType: " + queryObj["MemoryType"] + "\n" + "SMBIOSMemoryType: " + queryObj["SMBIOSMemoryType"]
                                        + "\n" + "TotalWidth: " + queryObj["TotalWidth"] + "\n" + "TypeDetail: " + queryObj["TypeDetail"]);
                                }
                                break;
                            case "battery":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Battery");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    Console.WriteLine("Name: " + queryObj["Name"] + "\n" + "Caption: " + queryObj["Caption"] + "\n" +
                                                   "Status: " + queryObj["Status"] + "\n" + "Availability: " + queryObj["Availability"] + "\n" + "Chemistry: " + queryObj["Chemistry"]
                                                   + "\n" + "CreationClassName: " + queryObj["CreationClassName"] + "\n" + "EstimatedRunTime(ms): " + queryObj["EstimatedRunTime"]);
                                }
                                break;
                            case "registry":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Registry");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    Console.WriteLine("Caption: " + queryObj["Caption"] + "\n" +
                                        "CurrentSize: " + queryObj["CurrentSize"] + "\n" + "Description: " + queryObj["Description"]
                                        + "\n" + "InstallDate: " + queryObj["InstallDate"] + "\n" + "MaximumSize: " + queryObj["MaximumSize"]
                                        + "\n" + "Name: " + queryObj["Name"] + "\n" + "ProposedSize: " + queryObj["ProposedSize"]
                                        + "\n" + "Status: " + queryObj["Status"]);
                                }
                                break;
                            case "?":
                                Console.WriteLine("*serialmainboard  " + "--This argument to show Serial mainboard of pc.");
                                Console.WriteLine("*computername  " + "--This argument to show information Computer name");
                                Console.WriteLine("*accountlogin  " + "--This argument to show information Account login pc.");
                                Console.WriteLine("*bios  " + "--This argument to show information BIOS of pc.");
                                Console.WriteLine("*network  " + "--This argument to show information Network adapter of pc.");
                                Console.WriteLine("*cpu  " + "--This argument to show information Processor of pc.");
                                Console.WriteLine("*main  " + "--This argument to show information BaseBoard of pc.");
                                Console.WriteLine("*graphic  " + "--This argument to show information Video controller of pc.");
                                Console.WriteLine("*memory  " + "--This argument to show information Physical memory ofs pc.");
                                Console.WriteLine("*battery  " + "--This argument to show information Battery of pc.");
                                Console.WriteLine("*registry  " + "--This argument to show information Registry of pc.");
                                break;
                            default:
                                Console.WriteLine("Not found information for argument " + args[1] +" !!!");
                                break;
                        }
                        
                        break;
   
                    case '?':
                        Console.WriteLine("-i  " + "This option to show information for argument.");
                        break;

                    default:
                        Console.WriteLine("Not found argument option " + c + " !!!");
                        break;
                }
            }
            

        }
    }
}

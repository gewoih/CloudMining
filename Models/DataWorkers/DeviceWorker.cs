using CloudMining.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CloudMining.Models.DataWorkers
{
	internal static class DeviceWorker
	{
		public static void CreateDevice(Device newDevice)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				db.Devices.Add(newDevice);
				db.SaveChanges();
			}
		}

		public static List<Device> GetDevices()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				var devices = db.Devices.Include(d => d.Currency).ToList();
				return devices;
			}
		}
	}
}

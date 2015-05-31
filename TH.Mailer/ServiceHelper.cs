using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml.Serialization;
using System.Xml;
using System.Collections;
using System.Net;
using System.Configuration.Install;
using System.ServiceProcess;

namespace TH.Mailer {
	public class ServiceHelper {
		/// <summary>
		/// 服务是否存在
		/// </summary>
		/// <param name="serviceName"></param>
		/// <returns></returns>
		public static bool ServiceIsInstalled(string serviceName) {
			ServiceController[] services = ServiceController.GetServices();
			foreach (ServiceController s in services) {
				if (s.ServiceName.ToLower() == serviceName.ToLower()) return true;
			}
			return false;
		}
		/// <summary>
		/// 安装卸载服务
		/// </summary>
		/// <param name="serviceArgs"></param>
		/// <returns></returns>
		public static bool ServiceInstall(params string[] serviceArgs) {
			try {
				ManagedInstallerClass.InstallHelper(serviceArgs);
				return true;
			} catch (Exception ex) {
				return false;
			}
		}
		/// <summary>
		/// 获取服务
		/// </summary>
		/// <param name="serviceName"></param>
		/// <returns></returns>
		public static ServiceController GetServiceController(string serviceName) {
			ServiceController[] services = ServiceController.GetServices();
			foreach (ServiceController s in services) {
				if (s.ServiceName.ToLower() == serviceName.ToLower()) return s;
			}
			return null;
		}
		/// <summary>
		/// 启动服务
		/// </summary>
		/// <param name="serviceName"></param>
		/// <returns></returns>
		public static bool ServiceStart(string serviceName) {
			ServiceController c = GetServiceController(serviceName);
			if (c == null) return false;
			if (c.Status != ServiceControllerStatus.Running) c.Start();
			return true;
		}
		/// <summary>
		/// 停止服务
		/// </summary>
		/// <param name="serviceName"></param>
		/// <returns></returns>
		public static bool ServiceStop(string serviceName) {
			ServiceController c = GetServiceController(serviceName);
			if (c == null) return false;
			if (c.Status != ServiceControllerStatus.Stopped) c.Stop();
			return true;
		}
		/// <summary>
		/// 是否启动
		/// </summary>
		/// <param name="serviceName"></param>
		/// <returns></returns>
		public static bool ServiceIsStarted(string serviceName) {
			ServiceController c = GetServiceController(serviceName);
			if (c == null) return false;
			if (c.Status == ServiceControllerStatus.Running) return true;
			return false;
		}
		/// <summary>
		/// 是否停止
		/// </summary>
		/// <param name="serviceName"></param>
		/// <returns></returns>
		public static bool ServiceIsStoped(string serviceName) {
			ServiceController c = GetServiceController(serviceName);
			if (c == null) return false;
			if (c.Status == ServiceControllerStatus.Stopped) return true;
			return false;
		}
	}

}
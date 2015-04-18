namespace MailerService {
    partial class MailerServiceInstaller {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            System.ServiceProcess.ServiceProcessInstaller servicePocessInstaller1;
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            servicePocessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();

            servicePocessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            servicePocessInstaller1.Password = null;
            servicePocessInstaller1.Username = null;

            serviceInstaller1.Description = "MailerService";
            serviceInstaller1.DisplayName = "MailerService";
            serviceInstaller1.ServiceName = "MailerService";
            serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;

            Installers.AddRange(new System.Configuration.Install.Installer[] { servicePocessInstaller1, serviceInstaller1 });
        }

        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
        #endregion
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;


namespace MailerService {
    [RunInstaller(true)]
    public partial class MailerServiceInstaller : System.Configuration.Install.Installer {
        public MailerServiceInstaller() {
            InitializeComponent();
        }
    }
}

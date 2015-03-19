using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharkbite.Irc;

namespace TPPSimulator
{
    [DefaultEvent("Command")]
    public partial class IrcCommandListener : Component
    {
        private Connection con = null;

        public IrcCommandListener()
        {
            InitializeComponent();
        }

        public IrcCommandListener(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public event EventHandler<IrcCommandEventArgs> Command;

        protected virtual void OnCommand(IrcCommandEventArgs e)
        {
            if (Command != null) Command(this, e);
        }

        protected void OnCommand(string command, string argument)
        {
            OnCommand(new IrcCommandEventArgs(command, argument));
        }

        [Browsable(false)]
        public Connection Connection
        {
            get { return con; }
        }

        public void PerformLogin()
        {
            string username, oauth;
            if (OAuthPromptForm.PromptForLogin(out username, out oauth) == System.Windows.Forms.DialogResult.OK) {
                ConnectionArgs ca = new ConnectionArgs(username, "irc.twitch.tv");
                ca.UserName = username;
                ca.ServerPassword = oauth;
                con = new Connection(ca, false, true);
                con.Listener.OnPublic += Listener_OnPublic;
                con.Connect();
                con.Sender.Join("#twitchspeaks");
            }
        }

        void Listener_OnPublic(UserInfo user, string channel, string message)
        {
            if (message.Length > 1) {
                if (message[0] == '!') {
                    string rest = message.Substring(1);
                    string command, argument;
                    rest.SplitOnce(' ', out command, out argument);
                    OnCommand(command, argument);
                }
            }
        }
    }

    public class IrcCommandEventArgs : EventArgs
    {
        private string command, argument;

        public IrcCommandEventArgs(string command, string argument)
        {
            this.command = command;
            this.argument = argument;
        }

        public string Command
        {
            get { return command; }
        }

        public string Argument
        {
            get { return argument; }
        }
    }
}

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

        protected void OnCommand(string command, string argument, string user)
        {
            OnCommand(new IrcCommandEventArgs(command, argument, user));
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
            if (message.Length > 0) {
                string command, argument;
                message.SplitOnce(' ', out command, out argument);
                OnCommand(command, argument, user.Nick);
            }
        }
    }

    public class IrcCommandEventArgs : EventArgs
    {
        private string command, argument, user;

        public IrcCommandEventArgs(string command, string argument, string user)
        {
            this.command = command;
            this.argument = argument;
            this.user = user;
        }

        public string Command
        {
            get { return command; }
        }

        public string Argument
        {
            get { return argument; }
        }

        public string User
        {
            get { return user; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPPSimulator
{
    [DefaultEvent("TitleChanged")]
    public partial class DocumentManager : Component
    {
        private bool dirty = false;
        private string appTitle = "";
        private string documentTitle = "Untitled";
        private string documentPath = "";
        private string defaultDocTitle = "Untitled";

        public class AttemptOpenFileEventArgs : EventArgs
        {
            private bool cancel = false;
            private string path = null;

            public bool Cancel
            {
                get { return cancel; }
                set { cancel = value; }
            }

            public string Path
            {
                get { return path; }
                set { path = value; }
            }
        }

        public DocumentManager()
        {
            InitializeComponent();
            PerformInitialization();
        }

        public DocumentManager(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            PerformInitialization();
        }

        public event EventHandler<AttemptOpenFileEventArgs> AttemptOpenFile;
        public event EventHandler<AttemptOpenFileEventArgs> AttemptSaveFile;

        protected virtual void OnAttemptOpenFile(AttemptOpenFileEventArgs e)
        {
            if (AttemptOpenFile != null) AttemptOpenFile(this, e);
        }

        protected bool OnAttemptOpenFile(string path)
        {
            AttemptOpenFileEventArgs e = new AttemptOpenFileEventArgs { Path = path };
            OnAttemptOpenFile(e);
            return e.Cancel;
        }

        protected virtual void OnAttemptSaveFile(AttemptOpenFileEventArgs e)
        {
            if (AttemptSaveFile != null) AttemptSaveFile(this, e);
        }

        protected bool OnAttemptSaveFile(string path)
        {
            AttemptOpenFileEventArgs e = new AttemptOpenFileEventArgs { Path = path };
            OnAttemptSaveFile(e);
            return e.Cancel;
        }

        private void PerformInitialization()
        {
            OnTitleChanged();
        }

        public event EventHandler TitleChanged;

        protected void OnTitleChanged()
        {
            OnTitleChanged(EventArgs.Empty);
        }

        protected virtual void OnTitleChanged(EventArgs e)
        {
            if (TitleChanged != null) TitleChanged(this, e);
        }

        [DefaultValue(""), Category("Appearance")]
        [Description("Indicates the name of the application as should be shown in the title bar.")]
        public string AppTitle
        {
            get { return appTitle; }
            set { appTitle = value; OnTitleChanged(); }
        }

        [DefaultValue("Untitled"), Category("Behavior")]
        [Description("Indicates the name of the current document.")]
        public string DocumentTitle
        {
            get { return documentTitle; }
            set { documentTitle = openDlg.FileName = saveDlg.FileName = value; OnTitleChanged(); }
        }

        [DefaultValue(""), Category("Behavior")]
        [Description("Indicates the location of the current document in the file system, if it has one.")]
        public string DocumentPath
        {
            get { return documentPath; }
            set { documentPath = value; }
        }

        [DefaultValue("Untitled"), Category("Behavior")]
        [Description("Indicates the name that should be given to a new document.")]
        public string DefaultDocTitle
        {
            get { return defaultDocTitle; }
            set { defaultDocTitle = value; }
        }

        [Browsable(false)]
        public string WindowTitle
        {
            get { return String.Format("{0}{1} - {2}", dirty ? "*" : "", DocumentTitle, AppTitle); }
        }

        [DefaultValue(false), Category("Behavior")]
        [Description("Indicates whether the current document has (or should be treated as having) unsaved changes.")]
        public bool Dirty
        {
            get { return dirty; }
            set { dirty = value; OnTitleChanged(); }
        }

        [DefaultValue(""), Category("Behavior")]
        [Description("The file filters to display in the Open dialog box.")]
        public string OpenFilter
        {
            get { return openDlg.Filter; }
            set { openDlg.Filter = value; }
        }

        [DefaultValue(""), Category("Behavior")]
        [Description("The file filters to display in the Save dialog box.")]
        public string SaveFilter
        {
            get { return saveDlg.Filter; }
            set { saveDlg.Filter = value; }
        }

        [Browsable(false)]
        public OpenFileDialog OpenDialog
        {
            get { return openDlg; }
        }

        [Browsable(false)]
        public SaveFileDialog SaveDialog
        {
            get { return saveDlg; }
        }

        public bool NewDocument()
        {
            if (PromptBeforeExit()) {
                Dirty = false;
                DocumentTitle = DefaultDocTitle;
                return true;
            } else {
                return false;
            }
        }

        public bool Open()
        {
            if (openDlg.ShowDialog() == DialogResult.OK) {
                if (PromptBeforeExit()) {
                    if (!OnAttemptOpenFile(openDlg.FileName)) { //that is, if "Cancel" is false...
                        DocumentPath = openDlg.FileName;
                        DocumentTitle = System.IO.Path.GetFileName(DocumentPath);
                        Dirty = false;
                        return true;
                    }
                }
            }
            
            return false; //if it hasn't already returned true
        }

        public bool Save()
        {
            if (DocumentPath == "") {
                return SaveAs();
            } else {
                if (!OnAttemptSaveFile(DocumentPath)) {
                    Dirty = false;
                    return true;
                } else {
                    return false;
                }
            }
        }

        public bool SaveAs()
        {
            if (saveDlg.ShowDialog() == DialogResult.OK) {
                if (!OnAttemptSaveFile(saveDlg.FileName)) {
                    DocumentPath = saveDlg.FileName;
                    DocumentTitle = System.IO.Path.GetFileName(DocumentPath);
                    Dirty = false;
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public bool PromptBeforeExit()
        {
            if (Dirty) {
                DialogResult choice = MessageBox.Show(String.Format("Save changes to {0}?", DocumentTitle), AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (choice) {
                    case DialogResult.Yes:
                        return Save();
                    case DialogResult.Cancel:
                        return false;
                    default: //includes No
                        return true;
                }
            } else {
                return true;
            }
        }
    }
}

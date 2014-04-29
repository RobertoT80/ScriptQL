using System;

namespace ScriptQL
{
    public class EventArgsFactory
    {
        public class BackupEventArgs : EventArgs
        {
            public bool format = false;
            public bool compress = false;
        }
    }
}

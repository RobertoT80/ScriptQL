using System;

namespace ScriptQL
{
    public class EventArgsFactory
    {
        public class BackupEventArgs : EventArgs
        {
            public bool Format = false;
            public bool Compress = false;
        }
    }
}

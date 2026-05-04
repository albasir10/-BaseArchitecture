using System;
using UnityEngine;

namespace albatroneer.Core
{
    public struct EventerMessageWithGuid
    {
        public int Priority;
        public Delegate Delegates;
        public Guid Guid;
    }
}
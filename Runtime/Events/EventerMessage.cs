using System;
using UnityEngine;

namespace albatroneer.Core
{
    public struct EventerMessage
    {
        public int Priority;
        public Delegate Delegates;
    }
}

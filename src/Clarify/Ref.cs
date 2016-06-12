using System;

namespace Clarify
{

    [HalClass("Ref")]
    [Serializable]
    public class Ref :
        HalObject
    {



    }

    [Serializable]
    public class Ref<T> :
        Ref
    {



    }

}

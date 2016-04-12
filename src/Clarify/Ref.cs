using System.Runtime.Serialization;

namespace Clarify
{

    [HalClass("Ref")]
    [DataContract]
    public class Ref :
        HalObject
    {



    }

    [DataContract]
    public class Ref<T> :
        Ref
    {



    }

}

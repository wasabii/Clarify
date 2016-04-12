namespace Clarify
{

    public class HalLinks :
        HalObject
    {

        public HalLink Self
        {
            get { return GetPropertyValue<HalLink>("self"); }
        }

        public HalLink Parent
        {
            get { return GetPropertyValue<HalLink>("parent"); }
        }

        public HalLink[] Curies
        {
            get { return GetPropertyValue<HalLink[]>("curies"); }
        }

        public HalLink GetLink(string name)
        {
            return GetPropertyValue<HalLink>(name);
        }

        public HalLink<T> GetLink<T>(string name)
            where T : HalObject
        {
            return GetPropertyValue<HalLink>(name).As<T>();
        }

    }

}

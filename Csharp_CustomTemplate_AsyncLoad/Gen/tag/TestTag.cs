//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;



namespace cfg.tag
{ 

public sealed partial class TestTag :  Bright.Config.BeanBase 
{
    public TestTag(JSONNode _json) 
    {
        { if(!_json["id"].IsNumber) { throw new SerializationException(); }  Id = _json["id"]; }
        { if(!_json["value"].IsString) { throw new SerializationException(); }  Value = _json["value"]; }
        PostInit();
    }

    public TestTag(int id, string value ) 
    {
        this.Id = id;
        this.Value = value;
        PostInit();
    }

    public static TestTag DeserializeTestTag(JSONNode _json)
    {
        return new tag.TestTag(_json);
    }

    public int Id { get; private set; }
    public string Value { get; private set; }

    public const int __ID__ = 1742933812;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Value:" + Value + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}

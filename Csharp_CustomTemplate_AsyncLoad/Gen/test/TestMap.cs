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



namespace cfg.test
{ 

public sealed partial class TestMap :  Bright.Config.BeanBase 
{
    public TestMap(JSONNode _json) 
    {
        { if(!_json["id"].IsNumber) { throw new SerializationException(); }  Id = _json["id"]; }
        { var __json0 = _json["x1"]; if(!__json0.IsArray) { throw new SerializationException(); } X1 = new System.Collections.Generic.Dictionary<int, int>(__json0.Count); foreach(JSONNode __e0 in __json0.Children) { int _k0;  { if(!__e0[0].IsNumber) { throw new SerializationException(); }  _k0 = __e0[0]; } int _v0;  { if(!__e0[1].IsNumber) { throw new SerializationException(); }  _v0 = __e0[1]; }  X1.Add(_k0, _v0); }   }
        { var __json0 = _json["x2"]; if(!__json0.IsArray) { throw new SerializationException(); } X2 = new System.Collections.Generic.Dictionary<long, int>(__json0.Count); foreach(JSONNode __e0 in __json0.Children) { long _k0;  { if(!__e0[0].IsNumber) { throw new SerializationException(); }  _k0 = __e0[0]; } int _v0;  { if(!__e0[1].IsNumber) { throw new SerializationException(); }  _v0 = __e0[1]; }  X2.Add(_k0, _v0); }   }
        { var __json0 = _json["x3"]; if(!__json0.IsArray) { throw new SerializationException(); } X3 = new System.Collections.Generic.Dictionary<string, int>(__json0.Count); foreach(JSONNode __e0 in __json0.Children) { string _k0;  { if(!__e0[0].IsString) { throw new SerializationException(); }  _k0 = __e0[0]; } int _v0;  { if(!__e0[1].IsNumber) { throw new SerializationException(); }  _v0 = __e0[1]; }  X3.Add(_k0, _v0); }   }
        { var __json0 = _json["x4"]; if(!__json0.IsArray) { throw new SerializationException(); } X4 = new System.Collections.Generic.Dictionary<test.DemoEnum, int>(__json0.Count); foreach(JSONNode __e0 in __json0.Children) { test.DemoEnum _k0;  { if(!__e0[0].IsNumber) { throw new SerializationException(); }  _k0 = (test.DemoEnum)__e0[0].AsInt; } int _v0;  { if(!__e0[1].IsNumber) { throw new SerializationException(); }  _v0 = __e0[1]; }  X4.Add(_k0, _v0); }   }
        PostInit();
    }

    public TestMap(int id, System.Collections.Generic.Dictionary<int, int> x1, System.Collections.Generic.Dictionary<long, int> x2, System.Collections.Generic.Dictionary<string, int> x3, System.Collections.Generic.Dictionary<test.DemoEnum, int> x4 ) 
    {
        this.Id = id;
        this.X1 = x1;
        this.X2 = x2;
        this.X3 = x3;
        this.X4 = x4;
        PostInit();
    }

    public static TestMap DeserializeTestMap(JSONNode _json)
    {
        return new test.TestMap(_json);
    }

    public int Id { get; private set; }
    public test.TestIndex Id_Ref { get; private set; }
    public System.Collections.Generic.Dictionary<int, int> X1 { get; private set; }
    public System.Collections.Generic.Dictionary<long, int> X2 { get; private set; }
    public System.Collections.Generic.Dictionary<string, int> X3 { get; private set; }
    public System.Collections.Generic.Dictionary<test.DemoEnum, int> X4 { get; private set; }

    public const int __ID__ = -543227410;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        this.Id_Ref = (_tables["test.TbTestIndex"] as test.TbTestIndex).GetOrDefault(Id);
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "X1:" + Bright.Common.StringUtil.CollectionToString(X1) + ","
        + "X2:" + Bright.Common.StringUtil.CollectionToString(X2) + ","
        + "X3:" + Bright.Common.StringUtil.CollectionToString(X3) + ","
        + "X4:" + Bright.Common.StringUtil.CollectionToString(X4) + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}
